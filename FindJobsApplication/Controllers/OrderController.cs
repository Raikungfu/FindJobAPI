﻿using AutoMapper;
using FindJobsApplication.Library;
using FindJobsApplication.Models;
using FindJobsApplication.Models.ViewModel;
using FindJobsApplication.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FindJobsApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }


        // GET: OrderController
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var claimId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (claimId != null && int.TryParse(claimId, out int userId))
            {
                return Ok(_unitOfWork.Order.GetAll(x => x.UserId == userId, null, "Service"));
            }
            return Unauthorized(new { message = "User not logged in. Please log in to continue." });
        }

        // GET api/<OrderController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var claimId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (claimId != null && int.TryParse(claimId, out int userId))
            {
                return Ok(_unitOfWork.Order.GetFirstOrDefault(x => x.UserId == userId && x.OrderId == id, "Service"));
            }
            return Unauthorized(new { message = "User not logged in. Please log in to continue." });
        }

        // POST api/<OrderController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] OrderViewModel order)
        {
            var claimId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (claimId != null && int.TryParse(claimId, out int userId))
            {
                JobService jobService = _unitOfWork.JobService.GetFirstOrDefault(x => x.JobServiceId == order.JobServiceId);
                if (jobService == null)
                {
                    return BadRequest(new { message = "Job Service not found!" });
                }

                Order newOrder = _mapper.Map<Order>(order);

                newOrder.Description = "Pay for " + jobService.ServiceName;
                newOrder.Price = jobService.Price;

                if (jobService.Duration.HasValue)
                {
                    newOrder.DateFrom = DateTime.Now;
                    newOrder.DateTo = DateTime.Now.AddDays(jobService.Duration ?? 0.0);
                }

                newOrder.UserId = userId;

                _unitOfWork.Order.Add(newOrder);
                _unitOfWork.Save();

                return Ok(newOrder);
            }
            return Unauthorized(new { message = "User not logged in. Please log in to continue." });
        }


        [HttpPost("payment-vnpay")]
        public IActionResult createPaymentVNPayLink([FromBody] OrderPaymentViewModel orderPayment)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                string vnp_ReturnUrl = _configuration["VnPay:PaymentBackReturnUrl"];
                string vnp_Url = _configuration["VnPay:BaseURL"];
                string vnp_TmnCode = _configuration["VnPay:TmnCode"];
                string vnp_HashSecret = _configuration["VnPay:HashSecret"];

                VnPayLibrary vnpay = new VnPayLibrary();

                vnpay.AddRequestData("vnp_Version", "2.1.0");
                vnpay.AddRequestData("vnp_Command", "pay");
                vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
                vnpay.AddRequestData("vnp_Amount", ((double)orderPayment.TotalPrice * 100).ToString());

                if (orderPayment.paymentMethod == "DomesticCard")
                {
                    vnpay.AddRequestData("vnp_BankCode", "VNBANK");
                }
                else if (orderPayment.paymentMethod == "InternationalCard")
                {
                    vnpay.AddRequestData("vnp_BankCode", "INTCARD");
                }

                vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                vnpay.AddRequestData("vnp_CurrCode", "VND");
                vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(HttpContext));
                vnpay.AddRequestData("vnp_Locale", "vn");
                vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang: " + orderPayment.orderId);
                vnpay.AddRequestData("vnp_OrderType", "other");
                vnpay.AddRequestData("vnp_ReturnUrl", vnp_ReturnUrl);
                vnpay.AddRequestData("vnp_TxnRef", orderPayment.orderId);

                string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
                return Ok(new { paymentUrl });
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        // PUT api/<OrderController>/5
        [HttpGet("confirm-payment-vnpay")]
        public IActionResult ConfirmPayment()
        {
            try
            {
                var queryParams = Request.Query;

                var requiredParams = new[] { "vnp_TxnRef", "vnp_ResponseCode", "vnp_SecureHash", "vnp_Amount", "vnp_BankCode", "vnp_TransactionNo" };

                foreach (var param in requiredParams)
                {
                    if (!queryParams.ContainsKey(param))
                    {
                        return BadRequest($"Thiếu tham số: {param}");
                    }
                }

                var referer = Request.Headers["Referer"].ToString();
                if (!referer.StartsWith("https://sandbox.vnpayment.vn") && !referer.StartsWith("https://www.vnpayment.vn"))
                {
                    return BadRequest("Yêu cầu không hợp lệ.");
                }

                Dictionary<string, string> queryDictionary = queryParams.ToDictionary(q => q.Key, q => q.Value.ToString());

                string vnp_TxnRef = queryDictionary["vnp_TxnRef"];
                string vnp_ResponseCode = queryDictionary["vnp_ResponseCode"];
                string vnp_SecureHash = queryDictionary["vnp_SecureHash"];
                decimal amount = (decimal)Convert.ToDouble(queryDictionary["vnp_Amount"]);
                string paymentMethod = queryDictionary["vnp_BankCode"];
                string transactionNo = queryDictionary["vnp_TransactionNo"];

                if (!VerifySecureHash(vnp_SecureHash))
                {
                    return BadRequest("Secure hash không hợp lệ.");
                }

                var order = _unitOfWork.Order.GetFirstOrDefault(o => o.OrderId.ToString() == vnp_TxnRef);

                if (order == null)
                {
                    return BadRequest("Đơn hàng không tồn tại.");
                }

                if (order.Price != amount)
                {
                    return BadRequest("Số tiền không khớp.");
                }

                order.OrderStatus = vnp_ResponseCode == "00" ? OrderStatus.Accepted : OrderStatus.Rejected;
                order.PaymentMethod = PaymentMethod.VNPay;
                order.PaymentRef = transactionNo;
                order.PaymentDate = DateTime.Now;

                _unitOfWork.Order.Update(order);
                _unitOfWork.Save();

                return Ok(new { message = "Cập nhật đơn hàng thành công." });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });

            }
        }

        private bool VerifySecureHash(string secureHash)
        {
            string vnp_HashSecret = _configuration["VnPay:HashSecret"];
            VnPayLibrary vnpay = new VnPayLibrary();
            vnpay.ValidateSignature(secureHash, vnp_HashSecret);
            return true;
        }

        // DELETE api/<OrderController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.Order.Remove(id);
                _unitOfWork.Save();
                return NoContent();
            }catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
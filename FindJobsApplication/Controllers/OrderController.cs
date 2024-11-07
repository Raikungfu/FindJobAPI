using AutoMapper;
using FindJobsApplication.Library;
using FindJobsApplication.Models;
using FindJobsApplication.Models.Enum;
using FindJobsApplication.Models.ViewModel;
using FindJobsApplication.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace FindJobsApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly HttpClient _httpClient;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public OrderController(HttpClient httpClient, IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        // GET: OrderController
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var claimId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (claimId != null && int.TryParse(claimId, out int userId))
            {
                return Ok(_unitOfWork.Order.GetAll(x => x.UserId == userId, orderBy: query => query.OrderByDescending(job => job.OrderId), "JobService").Select(order => new
                {
                    order.OrderId,
                    order.Description,
                    order.Price,
                    order.OrderDate,
                    order.DateFrom,
                    order.DateTo,
                    JobService = order.JobService != null ? new
                    {
                        order.JobService.JobServiceId,
                        order.JobService.ServiceName
                    } : null,
                    order.OrderStatus,
                    order.PaymentMethod,
                    order.PaymentDate,
                    order.PaymentRef,
                    order.PaymentStatus
                }).ToList());
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
                return Ok(_unitOfWork.Order.GetFirstOrDefault(x => x.UserId == userId && x.OrderId == id, "JobService"));
            }
            return Unauthorized(new { message = "User not logged in. Please log in to continue." });
        }

        // POST api/<OrderController>
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

                Order order = _unitOfWork.Order.GetFirstOrDefault(x => x.OrderId.ToString() == orderPayment.OrderId);
                if (order == null)
                {
                    return BadRequest(new { message = "Order not found!" });
                }

                if (DateTime.Now.AddDays(1) < order.OrderDate)
                {
                    return BadRequest(new { message = "Order has expired!" });
                }

                var jobService = _unitOfWork.JobService.GetFirstOrDefault(x => x.JobServiceId == order.JobServiceId);
                if (jobService == null)
                {
                    return BadRequest(new { message = "Job Service not found!" });
                }

                string vnp_ReturnUrl = _configuration["VnPay:PaymentBackReturnUrl"];
                string vnp_Url = _configuration["VnPay:BaseURL"];
                string vnp_TmnCode = _configuration["VnPay:TmnCode"];
                string vnp_HashSecret = _configuration["VnPay:HashSecret"];

                VnPayLibrary vnpay = new VnPayLibrary();

                vnpay.AddRequestData("vnp_Version", "2.1.0");
                vnpay.AddRequestData("vnp_Command", "pay");
                vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
                vnpay.AddRequestData("vnp_Amount", ((double)order.Price * 100).ToString());

                if (orderPayment.PaymentMethod == "DomesticCard")
                {
                    vnpay.AddRequestData("vnp_BankCode", "VNBANK");
                }
                else if (orderPayment.PaymentMethod == "InternationalCard")
                {
                    vnpay.AddRequestData("vnp_BankCode", "INTCARD");
                }

                vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                vnpay.AddRequestData("vnp_CurrCode", "VND");
                vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(HttpContext));
                vnpay.AddRequestData("vnp_Locale", "vn");
                vnpay.AddRequestData("vnp_OrderInfo", "Don hang: " + orderPayment.OrderId + ". Thanh toan dich vu " + jobService.ServiceName + " tai Jobby");
                vnpay.AddRequestData("vnp_OrderType", "other");
                vnpay.AddRequestData("vnp_ReturnUrl", vnp_ReturnUrl);
                vnpay.AddRequestData("vnp_TxnRef", orderPayment.OrderId);

                string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
                return Ok(new { paymentUrl });
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        // PUT api/<OrderController>/5
        [AllowAnonymous]
        [HttpGet("confirm-payment-vnpay")]
        public async Task<IActionResult> ConfirmPayment()
        {
            string frontendLink = _configuration["FrontendLink"];
            try
            {
                var queryParams = Request.Query;

                var requiredParams = new[] { "vnp_TxnRef", "vnp_ResponseCode", "vnp_SecureHash", "vnp_Amount", "vnp_BankCode", "vnp_TransactionNo" };

                foreach (var param in requiredParams)
                {
                    if (!queryParams.ContainsKey(param))
                    {
                        string errorMessage = Uri.EscapeDataString($"Thiếu tham số: {param}");
                        return Redirect($"{frontendLink}/payment-fail?message={errorMessage}");
                    }
                }

                var referer = Request.Headers["Referer"].ToString();
                if (!referer.StartsWith("https://sandbox.vnpayment.vn") && !referer.StartsWith("https://www.vnpayment.vn"))
                {
                    string errorMessage = Uri.EscapeDataString("Yêu cầu không hợp lệ.");
                    return Redirect($"{frontendLink}/payment-fail?message={errorMessage}");
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
                    string errorMessage = Uri.EscapeDataString("Secure hash không hợp lệ.");
                    return Redirect($"{frontendLink}/payment-fail?message={errorMessage}");
                }

                var order = _unitOfWork.Order.GetFirstOrDefault(o => o.OrderId.ToString() == vnp_TxnRef);

                if (order == null)
                {
                    string errorMessage = Uri.EscapeDataString("Đơn hàng không tồn tại.");
                    return Redirect($"{frontendLink}/payment-fail?message={errorMessage}");
                }

                if (order.Price * 100 != amount)
                {
                    string errorMessage = Uri.EscapeDataString("Số tiền không khớp.");
                    return Redirect($"{frontendLink}/payment-fail?message={errorMessage}");
                }



                order.OrderStatus = vnp_ResponseCode == "00" ? OrderStatus.Accepted : OrderStatus.Rejected;
                order.PaymentMethod = PaymentMethod.VNPay;
                order.PaymentRef = transactionNo;
                order.PaymentDate = DateTime.Now;

                if (UpdateOrder(order))
                {
                    return Redirect($"{frontendLink}/payment-success");

                }
                else
                {
                    return Redirect($"{frontendLink}/payment-fail?message={"Payment failed!"}");
                }
            }
            catch (Exception e)
            {
                string errorMessage = Uri.EscapeDataString(e.Message);
                return Redirect($"{frontendLink}/payment-fail?message={errorMessage}");
            }
        }

        [AllowAnonymous]
        [HttpGet("confirm-payment-payos")]
        public async Task<IActionResult> ConfirmPaymentPayOS([FromQuery]string code, [FromQuery] string id, [FromQuery] bool cancel, [FromQuery] string status, [FromQuery] int orderCode)
        {
            string frontendLink = _configuration["FrontendLink"];
            try
            {
                var order = _unitOfWork.Order.GetFirstOrDefault(o => o.OrderId == orderCode);

                if (order == null)
                {
                    string errorMessage = Uri.EscapeDataString("Đơn hàng không tồn tại.");
                    return Redirect($"{frontendLink}/payment-fail?message={errorMessage}");
                }

                order.OrderStatus = status == "PAID" ? OrderStatus.Accepted : OrderStatus.Rejected;
                order.PaymentMethod = PaymentMethod.PayOS;
                order.PaymentRef = id;
                order.PaymentDate = DateTime.Now;

                if (UpdateOrder(order))
                {
                    return Redirect($"{frontendLink}/payment-success?message={"Update status order success!"}");
                }
                else
                {
                    return Redirect($"{frontendLink}/payment-fail?message={"Update status order failed!"}");
                }

            }catch (Exception e)
            {
                string errorMessage = Uri.EscapeDataString(e.Message);
                return Redirect($"{frontendLink}/payment-fail?message={errorMessage}");
            }
        }

        private bool UpdateOrder(Order order)
        {
            var jobService = _unitOfWork.JobService.GetFirstOrDefault(x => x.JobServiceId == order.JobServiceId);

            if (jobService.Duration.HasValue)
            {
                order.DateFrom = DateTime.Now;
                order.DateTo = DateTime.Now.AddDays(jobService.Duration ?? 0.0);
            }

            _unitOfWork.Order.Update(order);

            (DateTime? serviceFrom, DateTime? serviceTo) UpdateServiceDates(DateTime? serviceFrom, DateTime? serviceTo, int duration)
            {
                serviceFrom = (serviceTo == null || serviceTo < DateTime.Now) ? DateTime.Now : serviceFrom;
                serviceTo = (serviceTo == null || serviceTo < DateTime.Now) ? DateTime.Now.AddDays(duration) : serviceTo.Value.AddDays(duration);
                return (serviceFrom, serviceTo);
            }

            if (order.User.UserType == UserType.Employer)
            {
                var employer = _unitOfWork.Employer.GetFirstOrDefault(x => x.UserId == order.UserId);
                if (employer == null)
                {
                    return false;
                }

                switch (jobService.jobServiceType)
                {
                    case JobServiceType.FeaturePostJob:
                        if (jobService.Duration.HasValue)
                        {
                            var updatedDates = UpdateServiceDates(employer.FeaturePostJobServiceFrom, employer.FeaturePostJobServiceTo, jobService.Duration.Value);
                            employer.FeaturePostJobServiceFrom = updatedDates.serviceFrom;
                            employer.FeaturePostJobServiceTo = updatedDates.serviceTo;
                        }
                        else if (jobService.Count.HasValue)
                        {
                            employer.FeaturePostJobServiceCount = (employer.FeaturePostJobServiceCount ?? 0) + jobService.Count.Value;
                        }
                        break;

                    case JobServiceType.PostJob:
                        if (jobService.Duration.HasValue)
                        {
                            var updatedDates = UpdateServiceDates(employer.PostJobServiceFrom, employer.PostJobServiceTo, jobService.Duration.Value);
                            employer.PostJobServiceFrom = updatedDates.serviceFrom;
                            employer.PostJobServiceTo = updatedDates.serviceTo;
                        }
                        else if (jobService.Count.HasValue)
                        {
                            employer.PostJobServiceCount = (employer.PostJobServiceCount ?? 0) + jobService.Count.Value;
                        }
                        break;
                }

                _unitOfWork.Employer.Update(employer);
                _unitOfWork.SaveAsync();
            }

            _unitOfWork.Save();
            return true;
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


        [HttpPost("payment-payos")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderPaymentViewModel orderPayment)
        {
            try
            {
                var claimId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (claimId == null || !int.TryParse(claimId, out int userId))
                {
                    return Unauthorized(new { message = "User not logged in. Please log in to continue." });
                }

                var order = _unitOfWork.Order.GetFirstOrDefault(x => x.OrderId.ToString() == orderPayment.OrderId);
                if (order == null)
                {
                    return BadRequest(new { message = "Order not found!" });
                }

                if (DateTime.Now.AddDays(1) < order.OrderDate)
                {
                    return BadRequest(new { message = "Order has expired!" });
                }

                var jobService = _unitOfWork.JobService.GetFirstOrDefault(x => x.JobServiceId == order.JobServiceId);
                if (jobService == null)
                {
                    return BadRequest(new { message = "Job Service not found!" });
                }

                var payOS = new PayOS(
                    _configuration["PAYOS_CLIENT_ID"],
                    _configuration["PAYOS_API_KEY"],
                    _configuration["PAYOS_CHECKSUM_KEY"]
                );

                var paymentData = new PaymentData(
                    orderCode: order.OrderId,
                    amount: (int) Math.Round(order.Price),
                    description: $"Payment for Order ID: {order.OrderId}",
                    items: new List<ItemData> { new ItemData(jobService.ServiceName, 1, (int) jobService.Price)},
                    returnUrl: $"{_configuration["BackendLink"]}/confirm-payment-payos",
                    cancelUrl: $"{_configuration["BackendLink"]}/confirm-payment-payos"
                );

                var paymentResponse = await payOS.createPaymentLink(paymentData);
                if (paymentResponse == null || string.IsNullOrEmpty(paymentResponse.checkoutUrl))
                {
                    throw new Exception("Failed to create payment link");
                }

                return Ok(new
                {
                    message = "Order placed successfully",
                    paymentUrl = paymentResponse.checkoutUrl
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while processing the order",
                    error = ex.Message
                });
            }
        }
    }

    public class PayOSResponse
    {
        public bool loading { get; set; }
        public string code { get; set; }
        public string id { get; set; }
        public string cancel { get; set; }
        public int orderCode { get; set; }
        public string status { get; set; }
    }
}

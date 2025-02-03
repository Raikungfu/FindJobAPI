using FindJobsApplication.Models.Enum;
using FindJobsApplication.Models.ViewModel;
using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FindJobsApplication.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{userId}")]
        public IActionResult GetNotifications(int userId)
        {
            var notifications = _unitOfWork.Notification.GetAll(n => n.UserId == userId)
                .OrderByDescending(n => n.Date)
                .ToList();
            return Ok(notifications);
        }

        [HttpPost("mark-as-read/{notificationId}")]
        public IActionResult MarkAsRead(int notificationId)
        {
            var notification = _unitOfWork.Notification.GetFirstOrDefault(n => n.Id == notificationId);
            if (notification == null)
            {
                return NotFound("Notification not found");
            }

            notification.IsRead = true;
            _unitOfWork.Save();
            return Ok();
        }
    }
}

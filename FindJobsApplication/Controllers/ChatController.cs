/*using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FindJobsApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChatController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Chat/Employers
        [HttpGet("Employers")]
        public async Task<ActionResult<IEnumerable<User>>> GetEmployers()
        {
            var employers = await _unitOfWork.User.GetAll(u => u.UserType == UserType.).ToListAsync();

            if (employers == null || employers.Count == 0)
            {
                return NotFound("No employers found.");
            }

            return Ok(employers);
        }

        // POST: api/Chat/StartChat
        [HttpPost("StartChat")]
        public IActionResult StartChat([FromBody] StartChatRequest request)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int id))
            {
                return Unauthorized("User not logged in.");
            }

            var user = _unitOfWork.User.GetFirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            var claimRole = user.Role;
            if (claimRole != UserType.Employee.ToString())
            {
                return Unauthorized("You are not authorized to start a chat.");
            }

            var room = _unitOfWork.Room.GetFirstOrDefault(r =>
                (r.EmployeeId == userIdClaim && r.EmployerId == request.EmployerId) ||
                (r.EmployeeId == request.EmployerId && r.EmployerId == userIdClaim));

            if (room == null)
            {
                room = new Room
                {
                    Name = $"Chat with employer {request.EmployerId}",
                    EmployeeId = id,
                    EmployerId = request.EmployerId
                };

                _unitOfWork.Room.Add(room);
                _unitOfWork.SaveAsync();
            }

            return Ok(new { roomId = room.Id });
        }

        [HttpGet("ChatRoom/{roomId}")]
        public IActionResult GetChatRoom(int roomId)
        {
            var room = _unitOfWork.Room.GetFirstOrDefault(r => r.Id == roomId, include: r => r.Include(x => x.Messages).ThenInclude(m => m.FromUser));

            if (room == null)
            {
                return NotFound("Room not found.");
            }

            room.Messages = room.Messages.OrderByDescending(m => m.Timestamp).Take(20).ToList();
            return Ok(room);
        }

        // POST: api/Chat/SendMessage
        [HttpPost("SendMessage")]
        public IActionResult SendMessage([FromBody] SendMessageRequest request)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int id))
            {
                return Unauthorized("User not logged in.");
            }

            var room = _unitOfWork.Room.GetFirstOrDefault(r => r.Id == request.RoomId);
            if (room == null)
            {
                return BadRequest("Room not found.");
            }

            var message = new Message
            {
                Content = request.Content,
                FromUserId = id,
                ToRoomId = request.RoomId,
                Timestamp = DateTime.Now
            };

            room.Messages.Add(message);
            _unitOfWork.SaveAsync();

            var messageViewModel = new MessageViewModel
            {
                Id = message.MessageId,
                Content = message.Content,
                Timestamp = message.Timestamp,
                FromUserName = User.Identity?.Name ?? "Unknown User",
                Room = room.Name
            };

            return Ok(new { success = true, message = "Message sent successfully!", messageData = messageViewModel });
        }
    }

    public class SendMessageRequest
    {
        public int RoomId { get; set; }
        public string Content { get; set; }
    }

    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string FromUserName { get; set; }
        public string Room { get; set; }
    }

    public class StartChatRequest
    {
        public string EmployerId { get; set; }
    }
}
*/
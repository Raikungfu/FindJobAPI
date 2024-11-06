using FindJobsApplication.Models;
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

        // GET: api/Chat
        [HttpGet]
        public async Task<IActionResult> Get()
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

            var rooms = await _unitOfWork.Room.GetAllAsync(r => r.UserId1 == id || r.UserId2 == id, null, "Messages,Messages.FromUser");

            var result = rooms.Select(r => new
            {
                roomId = r.Id,
                lastMessage = r.Messages.OrderByDescending(m => m.Timestamp).FirstOrDefault()?.Content,
                lastMessageTimestamp = r.Messages.OrderByDescending(m => m.Timestamp).FirstOrDefault()?.Timestamp,
                withUser = r.UserId1 == id ? r.User2.Username : r.User1.Username,
                toUser = r.UserId1 == id ? r.User2.UserId : r.User1.UserId
            });

            return Ok(result);
        }

        // POST: api/Chat/StartChat
        [HttpPost("StartChat")]
        public async Task<IActionResult> StartChat([FromBody] StartChatRequest request)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int id))
            {
                return Unauthorized("User not logged in.");
            }

            var user = await _unitOfWork.User.GetFirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            var room = await _unitOfWork.Room.GetFirstOrDefaultAsync(r =>
                (r.UserId1 == id && r.UserId2 == request.ToUserId) ||
                (r.UserId1 == request.ToUserId && r.UserId2 == id));

            if (room == null)
            {
                int userId1 = id < request.ToUserId ? id : request.ToUserId;
                int userId2 = id < request.ToUserId ? request.ToUserId : id;

                room = new Room
                {
                    Name = $"privite_{userId1}_{userId2}",
                    UserId1 = userId1,
                    UserId2 = userId2
                };

                _unitOfWork.Room.Add(room);
                await _unitOfWork.SaveAsync();
            }

            return Ok(new { roomId = room.Id });
        }


        [HttpGet("ChatRoom/{roomId}")]
        public IActionResult GetChatRoom(int roomId)
        {
            var room = _unitOfWork.Room.GetFirstOrDefault(r => r.Id == roomId, "Messages,Messages.FromUser");

            if (room == null)
            {
                return NotFound("Room not found.");
            }

            room.Messages = room.Messages.OrderByDescending(m => m.Timestamp).Take(20).ToList();
            return Ok(room);
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
        public int ToUserId { get; set; }
    }
}

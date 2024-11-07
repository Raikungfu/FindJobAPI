using Azure.Messaging;
using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace FindJobsApplication.Hubs
{
    public class ChatHub : Hub
    {
        public readonly static List<UserViewModel> _Connections = new List<UserViewModel>();
        private readonly IUnitOfWork _unitOfWork;
        private static readonly Dictionary<string, List<int>> _userRooms = new Dictionary<string, List<int>>();

        public ChatHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Leave(int roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName.ToString());

            if (_userRooms.ContainsKey(Context.ConnectionId))
            {
                _userRooms[Context.ConnectionId].Remove(roomName);
            }
        }

        public override async Task OnConnectedAsync()
        {
            var userName = Context.User.Identity.Name;

            if (!_Connections.Any(u => u.UserName == userName))
            {
                var newUser = new UserViewModel
                {
                    UserName = userName,
                    ConnectionId = Context.ConnectionId
                };

                _Connections.Add(newUser);

                await Clients.All.SendAsync("UserConnected", userName);
            }

            if (!_userRooms.ContainsKey(Context.ConnectionId))
            {
                _userRooms[Context.ConnectionId] = new List<int>();
            }
            await base.OnConnectedAsync();
        }

        public async Task JoinRoom(int roomId, string name)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());

            if (_userRooms.ContainsKey(Context.ConnectionId))
            {
                _userRooms[Context.ConnectionId].Add(roomId);
            }

            await Clients.Group(roomId.ToString()).SendAsync("ReceiveNewUserNotification", name);
        }

        public async Task SendMessageToRoom(int roomId, string messageContent)
        {
            var claimId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (claimId == null || !int.TryParse(claimId, out int id))
            {
                return;
            }

            var user = await _unitOfWork.User.GetFirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return;
            }

            var room = await _unitOfWork.Room.GetFirstOrDefaultAsync(r => r.Id == roomId);

            if (room == null)
            {
                return;
            }

            var msg = new Message()
            {
                Content = Regex.Replace(messageContent, @"<.*?>", string.Empty),
                FromUserId = id,
                ToRoomId = room.Id,
                Timestamp = DateTime.Now
            };

            _unitOfWork.Message.Add(msg);
            _unitOfWork.Save();

            var createdMessage = new MessageViewModel
            {
                Id = msg.MessageId,
                Content = msg.Content,
                Timestamp = msg.Timestamp,
                FromName = claimId.ToString(),
                Room = room.Name,
            };

            await Clients.Group(roomId.ToString()).SendAsync("ReceiveMessage", createdMessage)
                 .ConfigureAwait(false);
        }

        public async Task NewMessage(NewMessageViewModel message)
        {
            var claimId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (claimId == null || int.TryParse(claimId, out int id))
            {
                return;
            }

            var user = await _unitOfWork.User.GetFirstOrDefaultAsync(u => u.UserId == id);
            if (user == null) {
                return;
            }

            var room = await _unitOfWork.Room.GetFirstOrDefaultAsync(r => r.Id == message.RoomId);

            if (room == null)
            {
                return;
            }

            var msg = new Message()
            {
                Content = Regex.Replace(message.Content, @"<.*?>", string.Empty),
                FromUserId = id,
                ToRoomId = room.Id,
                Timestamp = DateTime.Now
            };

            _unitOfWork.Message.Add(msg);
            _unitOfWork.Save();

            var createdMessage = new MessageViewModel
            {
                Id = msg.MessageId,
                Content = msg.Content,
                Timestamp = msg.Timestamp,
                FromName = claimId.ToString(),
                Room = room.Name,
            };

            await Clients.Group(room.Name).SendAsync("ReceiveMessage", createdMessage)
                 .ConfigureAwait(false);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = _Connections.FirstOrDefault(u => u.ConnectionId == Context.ConnectionId);

            if (user != null)
            {
                _Connections.Remove(user);

                await Clients.All.SendAsync("UserDisconnected", user.UserName);
            }

            if (_userRooms.ContainsKey(Context.ConnectionId))
            {
                foreach (var room in _userRooms[Context.ConnectionId])
                {
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, room.ToString());
                }

                _userRooms.Remove(Context.ConnectionId);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }


    public class UserViewModel
    {
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? CurrentRoom { get; set; }
        public string? Device { get; set; }
        public bool? IsOnline { get; set; }
        public string? ConnectionId { get; set; }

    }

    public class MessageViewModel
    {
        public int? Id { get; set; }
        public string? Content { get; set; }
        public DateTime? Timestamp { get; set; }
        public string? FromName { get; set; }
        public string? Room { get; set; }
    }

    public class NewMessageViewModel
    {
        public string? Content { get; set; }
        public int? RoomId { get; set; }
    }
}

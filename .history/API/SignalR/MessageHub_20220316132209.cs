using System.Threading.Tasks;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class MessageHub : Hub
    {
        private readonly IMessageRepository _messageRepositoty;
        private readonly IMapper _mapper;
        public MessageHub(IMessageRepository messageRepositoty, IMapper mapper)
        {
            _mapper = mapper;
            _messageRepositoty = messageRepositoty;
        }


        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var otherUser = httpContext.Request.Query["user"].ToString();
            var groupName = GetGroupName(Context.User.GetUsername(), otherUser);
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            var messages = await _messageRepositoty
                        .GetMessageThread(Context.User.GetUsername(), otherUser);

            await Clients
        }

        private string GetGroupName(string caller, string other)
        {
            var stringCompare = string.CompareOrdinal(caller, other) < 0 ;
            return stringCompare? $"{caller}-{other}": $"{other}-{caller}";
        }
    }
}
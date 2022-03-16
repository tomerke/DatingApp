using System.Threading.Tasks;
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
            var groupName
        }

        private string GetGroupName(string caller, string other)
        {
            var stringCompare = string.CompareOrdinal(caller, other) < 0 ;
            return stringCompare? $"{caller}-{other}": $"{other}-{caller}";
        }
    }
}
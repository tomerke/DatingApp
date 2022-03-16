using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class MessageHub : Hub
    {
        private readonly IMessageRepository _messageRepositoty;
        public MessageHub(IMessageRepository messageRepositoty, IMapper mapper)
        {
            _messageRepositoty = messageRepositoty;

        }
    }
}
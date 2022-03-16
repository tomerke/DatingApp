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


        public override async T
    }
}
using System;
using System.Threading.Tasks;
using API.DTOs;
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

            await Clients.Group(groupName).SendAsync("ReceiveMessageThread", messages);
        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        private string GetGroupName(string caller, string other)
        {
            var stringCompare = string.CompareOrdinal(caller, other) < 0 ;
            return stringCompare? $"{caller}-{other}": $"{other}-{caller}";
        }

        public async Task SendMessage(CreateMessageDto createMessageDto)
        {
             var username = Context.User.GetUsername();
           if(username == createMessageDto.RecipientUsername.ToLower())
            throw new Hub("You cannot send message to yourself");

            var sender = await _userRepository.GetUserByUserNameAsync(username);
            var recipient =  await _userRepository.GetUserByUserNameAsync(createMessageDto.RecipientUsername);

            if(recipient == null) return  NotFound();

            var message = new Message
            {
                Sender = sender,
                Recipient = recipient,
                SenderUserName = sender.UserName,
                RecipientUserName = recipient.UserName,
                Content = createMessageDto.Content
            };

            _messageRepository.AddMessage(message);

            if( await _messageRepository.SaveAllAsync()) return Ok(_mapper.Map<MessageDto>(message));

            return BadRequest("Failed to send message");
        }
    }
}
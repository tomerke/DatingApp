using System;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
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
        private readonly IUserRepository _userRepository;
        public MessageHub(IMessageRepository messageRepositoty, IMapper mapper,
                           IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

    private async Task<bool> AddToGroup(HubCallerContext context, string groupName)
    {
        var group = await _messageRepositoty.GetMessageGroup(groupName);
        var connection = new Connection(Context.ConnectionId, Context.User.GetUsername());

        if(group == null)
        {
            group = new Group(groupName);
            _messageRepositoty.AddGroup(group);
        }

        group.Connections.Add(connection);
        return _messageRepositoty.SaveAllAsync();
    }

    private string GetGroupName(string caller, string other)
    {
        var stringCompare = string.CompareOrdinal(caller, other) < 0;
        return stringCompare ? $"{caller}-{other}" : $"{other}-{caller}";
    }

    public async Task SendMessage(CreateMessageDto createMessageDto)
    {
        var username = Context.User.GetUsername();
        if (username == createMessageDto.RecipientUsername.ToLower())
            throw new HubException("You cannot send message to yourself");

        var sender = await _userRepository.GetUserByUserNameAsync(username);
        var recipient = await _userRepository.GetUserByUserNameAsync(createMessageDto.RecipientUsername);

        if (recipient == null) throw new HubException("not found user");

        var message = new Message
        {
            Sender = sender,
            Recipient = recipient,
            SenderUserName = sender.UserName,
            RecipientUserName = recipient.UserName,
            Content = createMessageDto.Content
        };

        _messageRepositoty.AddMessage(message);

        if (await _messageRepositoty.SaveAllAsync())
        {
            var group = GetGroupName(sender.UserName, recipient.UserName);
            await Clients.Group(group).SendAsync("NewMessage", _mapper.Map<MessageDto>(message));
        }
    }
}
}
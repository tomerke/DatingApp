using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MessageRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddGroup(Group group)
        {
           _context.Groups.Add(group);
        }

        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        public void DeletedMessage(Message message)
        {
            _context.Messages.Remove(message);
        }

        public async Task<Connection> GetConnection(string connectionId)
        {
           return await _context.Connections.FindAsync
        }

        public async Task<PageList<MessageDto>> GetessagesForUser(MessageParams messageParams)
        {
            var query = _context.Messages
            .OrderByDescending(m => m.MessageSent)
            .AsQueryable();

            query = messageParams.Container switch
            {
                "Inbox" => query.Where(u => u.Recipient.UserName == messageParams.Username && u.RecipientDeleted == false),
                "Outbox" => query.Where(u => u.Sender.UserName == messageParams.Username && u.SenderDeleted == false),
                _ => query.Where(u => u.Recipient.UserName == messageParams.Username && u.DateRead == null
                    && u.RecipientDeleted == false)
            };



            var messages = query.ProjectTo<MessageDto>(_mapper.ConfigurationProvider);
            return await PageList<MessageDto>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages
            .Include(u => u.Sender)
            .Include(u=> u.Recipient)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<Group> GetMessageGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MessageDto>> GetMessageThread(string currentUserName, string recipientUserName)
        {
            var messages = await _context.Messages
                .Include(u => u.Sender).ThenInclude(u => u.Photos)
                .Include(u => u.Recipient).ThenInclude(u => u.Photos)
                .Where(m => m.Recipient.UserName == currentUserName && m.RecipientDeleted == false
                    && m.Sender.UserName == recipientUserName
                    || m.Recipient.UserName == recipientUserName
                    && m.Sender.UserName == currentUserName && m.SenderDeleted == false
                )
                .OrderBy(m => m.MessageSent)
                .ToListAsync();

            var unreadMessage = messages.Where(m => m.DateRead == null
                                && m.Recipient.UserName == currentUserName).ToList();
            if (unreadMessage.Any())
            {
                foreach (var message in unreadMessage)
                {
                    message.DateRead = DateTime.Now;
                }
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<IEnumerable<MessageDto>>(messages);

        }

        public void RemoveConnection(Connection connection)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
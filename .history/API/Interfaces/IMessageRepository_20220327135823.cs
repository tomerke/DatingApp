using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IMessageRepository
    {
       void AddGroup(Gro)

        void AddMessage(Message message);
        void DeletedMessage(Message message);

        Task<Message> GetMessage(int id);

        Task<PageList<MessageDto>> GetessagesForUser(MessageParams messageParams);

        Task<IEnumerable<MessageDto>> GetMessageThread(string currentUserName, string recipientUserName);

        Task<bool> SaveAllAsync();
    }
}
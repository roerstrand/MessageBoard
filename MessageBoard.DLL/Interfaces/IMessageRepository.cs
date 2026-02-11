using MessageBoard.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.DLL.Interfaces
{
    internal interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAllMessagesAsync();
        Task AddMessageAsync(Message message);
        Task DeleteMessageAsync(Message message);
    }
}

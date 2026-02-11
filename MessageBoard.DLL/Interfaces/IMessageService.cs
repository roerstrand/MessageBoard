using MessageBoard.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.DLL.Interfaces
{
    internal interface IMessageService
    {
        Task<IEnumerable<Message>> GetMessagesAsync();
        Task CreateMessageAsync(string content, string userId);

    }
}

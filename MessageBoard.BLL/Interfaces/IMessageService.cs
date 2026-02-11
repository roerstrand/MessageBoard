using MessageBoard.BLL.DTOs;
using MessageBoard.DLL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.BLL.Interfaces
{

    public interface IMessageService
    {
        Task<List<MessageDto>> GetAllMessagesAsync();
        Task AddMessageAsync(MessageDto dto);
        Task UpdateMessageAsync(MessageDto dto);
        Task DeleteMessageAsync(int messageId);
        Task DeleteUserAsync(string userId);
        Task UpdateUserAsync(UserDto dto);
    }


}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace MessageBoard.BLL.Services
{
    internal class MessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public MessageService(
            IMessageRepository messageRepository,
            IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }
        public MessageService(UserManager<IdentityUser> userManager)
        {
        }

        public async Task GetAllMessagesAsync()
        {
            await _messageRepository.GetAllMessagesAsync();
        }

        public async Task AddMessageAsync(Message message)
        {
            await _messageRepository.AddMessageAsync(message);
        }

        public async Task UpdateMessageAsync(Message message)
        {
            await _messageRepository.UpdateMessageAsync(message);
        }

        public async Task DeleteMessageAsync(Message message)
        {
            await _messageRepository.DeleteMessageAsync(message);
        }

        public async Task DeleteUserAsync(IdentityUser user)
        {
            await DBService.DeleteAsync(user);
        }

        public async Task UpdateUserAsync(IdentityUser user)
        {
            await DBService.UpdateAsync(user);
        }

    }
}

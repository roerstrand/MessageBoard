using MessageBoard.BLL.DTOs;
using MessageBoard.BLL.Interfaces;
using MessageBoard.DLL.Entities;
using MessageBoard.DLL.Interfaces;

namespace MessageBoard.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        //private readonly IUserRepository _userRepository;

        public MessageService(
            IMessageRepository messageRepository,
            //IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            //_userRepository = userRepository;
        }

        public async Task<List<MessageDto>> GetAllMessagesAsync()
        {
            var messages = await _messageRepository.GetAllMessagesAsync();

            return messages.Select(m => new MessageDto
            {
                Id = m.Id,
                Content = m.Content,
                CreatedAt = m.CreatedAt,
                UserId = m.UserId,
                UserName = m.User != null ? m.User.FullName : ""
            }).ToList();
        }

        public async Task AddMessageAsync(MessageDto dto)
        {
            var message = new Message
            {
                Content = dto.Content,
                UserId = dto.UserId,
                CreatedAt = DateTime.UtcNow
            };

            await _messageRepository.AddMessageAsync(message);
        }

        public async Task UpdateMessageAsync(MessageDto dto)
        {
            var message = new Message
            {
                Id = dto.Id,
                Content = dto.Content,
                UserId = dto.UserId,
                CreatedAt = dto.CreatedAt
            };

            await _messageRepository.UpdateMessageAsync(message);
        }


        public async Task DeleteMessageAsync(int messageId)
        {
            await _messageRepository.DeleteMessageAsync(messageId);
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user != null)
            {
                user.IsDeleted = true;
                await _userRepository.UpdateUserAsync(user);
            }
        }


        public async Task UpdateUserAsync(UserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(dto.Id);

            if (user != null)
            {
                user.FullName = dto.FullName;
                user.City = dto.City;
                user.LastLogin = dto.LastLogin;

                await _userRepository.UpdateUserAsync(user);
            }
        }
    }
}

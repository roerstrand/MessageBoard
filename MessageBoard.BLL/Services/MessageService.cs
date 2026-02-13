using MessageBoard.BLL.DTOs;
using MessageBoard.BLL.Interfaces;
using MessageBoard.DLL.Entities;
using MessageBoard.DLL.Interfaces;

namespace MessageBoard.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
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
                UserName = m.User != null ? m.User.DisplayName : ""
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

        public async Task DeleteMessageAsync(MessageDto dto)
        {
            await _messageRepository.DeleteMessageAsync(dto.Id);
        }
    }
}

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

            try
            {
                await _messageRepository.UpdateMessageAsync(message);
            }
            catch (NotImplementedException)
            {
                throw new NotSupportedException(
                    "UpdateMessageAsync is not yet implemented in the data access layer.");
            }
        }

        public async Task DeleteMessageAsync(int messageId)
        {
            var message = new Message { Id = messageId };
            await _messageRepository.DeleteMessageAsync(message);
        }
    }
}

using MessageBoard.BLL.DTOs;

namespace MessageBoard.BLL.Interfaces
{
    public interface IMessageService
    {
        Task<List<MessageDto>> GetAllMessagesAsync();
        Task AddMessageAsync(MessageDto dto);
        Task UpdateMessageAsync(MessageDto dto);
        Task DeleteMessageAsync(MessageDto Dto);
    }
}

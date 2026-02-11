using MessageBoard.DLL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageBoard.DLL.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAllMessagesAsync();
        Task<Message?> GetMessageByIdAsync(int id);
        Task AddMessageAsync(Message message);
        Task UpdateMessageAsync(Message message);
        Task<bool> DeleteMessageAsync(int id); 
    }
}
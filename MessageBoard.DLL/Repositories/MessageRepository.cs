using MessageBoard.DLL.Data;
using MessageBoard.DLL.Entities;
using MessageBoard.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.DLL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;

        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            return await _context.Messages
                .Include(m => m.User)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();
        }

        public async Task AddMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(Message message)
        {
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }
    }
}

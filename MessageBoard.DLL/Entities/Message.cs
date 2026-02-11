using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.DLL.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}

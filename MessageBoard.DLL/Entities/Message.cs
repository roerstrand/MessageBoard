using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.DLL.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public required string UserId { get; set; } // Foreign key to ApplicationUser, Who created the message





        // Navigation property: Each message is created by one user(many-to-one) >> ok?
        public ApplicationUser? User { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace MessageBoard.DLL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsDeleted { get; set; } = false;


        // Rename to be explicit
        public required string DisplayName { get; set; }

        public DateTime? LastLogin { get; set; }

        // Navigation: one user -> many messages
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}


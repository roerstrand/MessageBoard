using Microsoft.AspNetCore.Identity;

namespace MessageBoard.DLL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsDeleted { get; set; } = false;
        public required string User { get; set; }
        public DateTime LastLogin { get; set; }




        // Add navigation property for messages(One user can have many messages) >> one-to-many
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}



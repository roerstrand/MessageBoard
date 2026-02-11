using Microsoft.AspNetCore.Identity;

namespace MessageBoard.DLL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsDeleted { get; set; } = false;
        public string User { get; set; }
        public DateTime LastLogin { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

    }
}


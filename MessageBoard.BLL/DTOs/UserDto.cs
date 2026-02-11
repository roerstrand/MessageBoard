using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.BLL.DTOs
{
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public DateTime LastLogin { get; set; }

        public bool IsDeleted { get; set; }
    }
}

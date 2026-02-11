using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.BLL.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;
    }
}

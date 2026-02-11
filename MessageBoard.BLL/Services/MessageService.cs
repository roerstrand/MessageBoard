using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.BLL.Services
{
    internal class MessageService
    {
        public void OnGet()
        {

        }

        public Task<IActionResult> OnPostCreateMessage(Message message) { }

        public Task<IActionResult> OnPostUpdateMessage(Message message){}

        public Task<IActionResult> OnPostDeleteMessage(Message message) { }

        public Task<IActionResult> OnPostDeleteUser(IdentityUser user) {}

        public Task<IActionResult> OnPostUpdateUser(IdentityUser)
        {
            DatabaseService.UpdateUser(IDentityUser user)
        }

        

    }
}

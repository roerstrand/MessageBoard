using MessageBoard.BLL.DTOs;
using MessageBoard.BLL.Interfaces;
using MessageBoard.DLL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessageBoard.UI.Pages
{
    public class MessagesModel : PageModel
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessagesModel(IMessageService messageService, UserManager<ApplicationUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        [BindProperty]
        public string NewMessage { get; set; }

        public List<MessageDto> Messages { get; set; } = new();
        public string CurrentUserId { get; set; }

        public async Task OnGetAsync()
        {
            CurrentUserId = _userManager.GetUserId(User);
            Messages = await _messageService.GetAllMessagesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(NewMessage))
            {
                ModelState.AddModelError(string.Empty, "Meddelandet får inte vara tomt.");
                await OnGetAsync();
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);

            var dto = new MessageDto
            {
                Content = NewMessage,
                UserId = user.Id,
                UserName = user.DisplayName
            };

            await _messageService.AddMessageAsync(dto);

            return RedirectToPage();
        }
    }
}

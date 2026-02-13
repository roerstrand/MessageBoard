using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard.UI.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [BindProperty, Required]
        public string Username { get; set; }


        [BindProperty, Required]
        public string Password { get; set; }


        [BindProperty, Compare(nameof(Password))]

        public string ConfirmPassword { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new IdentityUser { UserName = Username };
            var result = await _userManager.AddPasswordAsync(user, Password);

            if (result.Succeeded)
            {
                //await _signInManager.SignInAsync(user, false);
                return RedirectToPage("/Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();

            //public void OnGet()
            //{
            //}
        }
    }
}

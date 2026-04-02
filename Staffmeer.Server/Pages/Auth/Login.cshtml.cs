using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Staffmeer.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace Staffmeer.Server.Pages.Auth
{
    [AllowAnonymous]
    public class LoginModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");

            if (!ModelState.IsValid)
                return Page();

            var result = await signInManager.PasswordSignInAsync(Username, Password, RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
                return LocalRedirect(returnUrl);

            if (result.IsLockedOut)
                ModelState.AddModelError(string.Empty, "Account locked out.");
            else
                ModelState.AddModelError(string.Empty, "Invalid username or password.");

            return Page();
        }
    }
}
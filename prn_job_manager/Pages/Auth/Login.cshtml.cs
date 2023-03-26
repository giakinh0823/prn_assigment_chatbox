using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prn_job_manager.Models;

namespace prn_job_manager.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly cron_jobContext _context;
        public LoginModel(cron_jobContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User? User { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(User? user)
        {

            if (ModelState.IsValid)
            {
                User? p = _context.Users.FirstOrDefault(x => user != null && x.Email == user.Email && x.Password == user.Password);
                if (p != null)
                {
                    var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

                    if (p.Email != null)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, p.Email) }
                            , scheme);
                        var userModel = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(scheme, userModel, new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.UtcNow.AddDays(1),
                            AllowRefresh = true
                        });
                    }
                    HttpContext.Session.SetString("name", p.Name!);
                    HttpContext.Session.SetString("email", p.Email!);
                    return RedirectToPage("../Index");

                }
                else
                {
                    ViewData["Error"] = "Email đăng nhập hoặc mật khẩu không đúng";
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("../Index");
            }
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            HttpContext.Session.Remove("email");
            await HttpContext.SignOutAsync(scheme);
            return RedirectToPage("../Index");
        }
    }
}

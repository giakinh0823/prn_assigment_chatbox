using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prn_job_manager.Models;
using System;
using System.Security.Claims;

namespace prn_job_manager.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly cron_jobContext _context;
        public LoginModel(cron_jobContext _context)
        {
            this._context = _context;
        }

        [BindProperty]
        public User user { get; set; }
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
                User p = _context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
                if (p != null)
                {
                    var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, p.Email) }
                    , scheme);
                    var userModel = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(scheme, userModel, new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1),
                        AllowRefresh = true
                    });

                    HttpContext.Session.SetString("email", p.Email);
                    HttpContext.Session.SetString("name", p.Password);


                    return RedirectToPage("../Index");

                }
                else
                {
                    ViewData["wrongaccount"] = "Email đăng nhập hoặc mật khẩu không đúng";
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
            //var identity = (ClaimsIdentity)User.Identity;
            //IEnumerable<Claim> claims = identity.Claims;

            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            HttpContext.Session.Remove("email");
            await HttpContext.SignOutAsync(scheme);
            return RedirectToPage("../Index");

        }
    }


}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prn_job_manager.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using System;

namespace prn_job_manager.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly cron_jobContext _context;

        public RegisterModel(cron_jobContext _context)
        {
            this._context = _context;
        }

        [BindProperty]
        public User user { get; set; }
        public IActionResult OnGet()
        {
            
            if (HttpContext.Session.GetString("email") != null)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(User? user, string? confirmPass)
        {
            
            if (ModelState.IsValid)
            {


                var p = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
                if (p == null)
                {
                    
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("Login");
                }
                else
                {
                    ViewData["emailExist"] = "Email này đã tồn tại, Vui lòng lựa chọn email khác";
                    return Page();
                }

            }

            return Page();

        }
    }

}

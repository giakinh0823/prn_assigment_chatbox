﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prn_job_manager.Models;

namespace prn_job_manager.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly cron_jobContext _context;

        public RegisterModel(cron_jobContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public User? User { get; set; }
        
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
                var p = await _context.Users.FirstOrDefaultAsync(x => user != null && x.Email == user.Email);
                if (p == null)
                {
                    if (user != null)
                    {
                        user.CreatedAt = DateTime.Now;
                        user.UpdatedAt = DateTime.Now;
                        await _context.Users.AddAsync(user);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToPage("Login");
                }

                ViewData["EmailExist"] = "Email này đã tồn tại, Vui lòng lựa chọn email khác";
                return Page();

            }
            return Page();
        }
    }

}

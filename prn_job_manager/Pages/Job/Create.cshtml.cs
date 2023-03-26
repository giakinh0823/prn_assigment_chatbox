using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prn_job_manager.Models;

namespace prn_job_manager.Pages.Job
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly cron_jobContext _context;

        public CreateModel(cron_jobContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Models.Job Job { get; set; } = default!;
        public IActionResult OnPost()
        {
            Job.CreatedAt = DateTime.Now;
            Job.UpdatedAt = null;
            _context.Jobs.Add(Job);
            _context.SaveChanges();
            return RedirectToPage("./List");
        }
    }
}

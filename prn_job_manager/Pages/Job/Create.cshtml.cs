using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prn_job_manager.Models;

namespace prn_job_manager.Pages.Job
{
    public class CreateModel : PageModel
    {
        private readonly cron_jobContext context;

        public CreateModel(cron_jobContext _context)
        {
            context = _context;
        }
        [BindProperty]
        public Models.Job Job { get; set; } = default!;
        public IActionResult OnPost()
        {
            Job.CreatedAt = DateTime.Now;
            Job.UpdatedAt = null;
            context.Jobs.Add(Job);
            context.SaveChanges();
            return RedirectToPage("./List");
        }
    }
}

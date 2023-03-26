using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prn_job_manager.Models;
using Quartz;

namespace prn_job_manager.Pages.Job
{

    public class EditModel : PageModel
    {
        private readonly cron_jobContext _context;
        public EditModel(cron_jobContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Job Job { get; set; }
        public void OnGet(int? id)
        {
            Job = _context.Jobs.FirstOrDefault(x => x.JobId == id);
        }

        public IActionResult OnPost()
        {

            _context.Jobs.Update(Job);
            _context.SaveChanges();
            return RedirectToPage("./List");
        }
    }
}

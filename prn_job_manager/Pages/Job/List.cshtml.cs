using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prn_job_manager.Models;

namespace prn_job_manager.Pages.Job
{
    public class ListModel : PageModel
    {
        private readonly cron_jobContext context;

        public ListModel(cron_jobContext _context)
        {
            context = _context;
        }
        public List<Models.Job> list { get; set; } = default!;
        public void OnGet()
        {
            list = context.Jobs.ToList();
        }
    }
}

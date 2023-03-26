using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prn_job_manager.Models;

namespace prn_job_manager.Pages.Job
{
    [Authorize]
    public class ListModel : PageModel
    {
        private readonly cron_jobContext _context;

        public ListModel(cron_jobContext context)
        {
            _context = context;
        }
        public List<Models.Job> List { get; set; } = default!;
        
        public void OnGet()
        {
            List = _context.Jobs.ToList();
        }
    }
}

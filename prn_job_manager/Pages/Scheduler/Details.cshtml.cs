using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prn_job_manager.Models;

namespace prn_job_manager.Pages.Scheduler
{
    public class DetailsModel : PageModel
    {
        private readonly prn_job_manager.Models.cron_jobContext _context;

        public DetailsModel(prn_job_manager.Models.cron_jobContext context)
        {
            _context = context;
        }
        
        [BindProperty(Name = "id", SupportsGet = true)]
        public int? Id { get; set; } = default!;

        public Job Job { get; set; } = default!;
        public List<Log> Logs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id == null)
            {
                return NotFound();
            }
            var job = await _context.Jobs
                .Include(x => x.Logs.OrderByDescending(x => x.LogId))
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(m => m.JobId == Id);
            if (job == null)
            {
                return NotFound();
            }
            else 
            {
                Job = job;
            }
            Logs = job.Logs.ToList();
            return Page();
        }
    }
}

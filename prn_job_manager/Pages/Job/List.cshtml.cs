using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prn_job_manager.Models;
using Quartz;

namespace prn_job_manager.Pages.Job
{
    [FptAuthorize]
    public class ListModel : PageModel
    {
        private readonly cron_jobContext _context;
        private readonly ISchedulerFactory _schedulerFactory;

        public ListModel(cron_jobContext context, ISchedulerFactory schedulerFactory)
        {
            _context = context;
            _schedulerFactory = schedulerFactory;
        }
        public List<Models.Job> List { get; set; } = default!;
        
        public void OnGet()
        {
            List = _context.Jobs.ToList();
        }
        
        // delete
        public async Task<IActionResult> OnGetDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var job = _context.Jobs.Find(id);

            string? email = HttpContext.Session.GetString("email");
            if(email == null)
            {
                return Redirect("/auth/login");
            }
            User? user = _context.Users.FirstOrDefault(u => u.Email!.Equals(email));
            if(user == null)  return Redirect("/auth/login");
            
            if (job != null)
            {
                IScheduler scheduler = await _schedulerFactory.GetScheduler();
                await scheduler.DeleteJob(new JobKey(job.JobId.ToString(), user.UserId.ToString()));
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./List");
        }
    }
}

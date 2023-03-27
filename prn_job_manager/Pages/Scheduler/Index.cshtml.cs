using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prn_job_manager.Constant;
using prn_job_manager.Models;
using Quartz;

namespace prn_job_manager.Pages.Scheduler
{
    [FptAuthorize]
    public class IndexModel : PageModel
    {
        private readonly cron_jobContext _context;
        private readonly ISchedulerFactory _schedulerFactory;

        public IndexModel(cron_jobContext context, ISchedulerFactory schedulerFactory)
        {
            _context = context;
            _schedulerFactory = schedulerFactory;
        }
        public List<Models.Job> List { get; set; } = default!;
        
        public async Task<IActionResult> OnGet()
        {
            string? email = HttpContext.Session.GetString("email");
            if(email == null)
            {
                return Redirect("/auth/login");
            }
            User? user = _context.Users.FirstOrDefault(u => u.Email!.Equals(email));
            if(user == null)  return Redirect("/auth/login");
            
            List<Job> jobs = _context.Jobs.Where(j => j.UserId == user.UserId).ToList();
            PaymentInfo? paymentInfo = _context.PaymentInfos.FirstOrDefault(x => x.UserId == user.UserId);
            if (paymentInfo == null || !PaymentStatusConstant.ACTIVE.Equals(paymentInfo?.Status)
                                                       || paymentInfo.EndDate <= DateTime.Now)
            {
                ViewData["NewScheduler"] = "New Scheduler ("+jobs.Count+"/1)";
            } else
            {
                ViewData["NewScheduler"] = "New Scheduler";
            }

            List = jobs.ToList();
            return Page();
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
                List<Log> logs = _context.Logs.Where(l => l.JobId == job.JobId).ToList();
                foreach (Log log in logs)
                {
                    _context.Logs.Remove(log);
                }
                await _context.SaveChangesAsync();
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
            return new RedirectResult("/Scheduler");
        }
    }
}

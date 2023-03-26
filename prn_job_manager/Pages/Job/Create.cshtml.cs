using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prn_job_manager.Constant;
using prn_job_manager.CronJob;
using prn_job_manager.Models;
using Quartz;

namespace prn_job_manager.Pages.Job
{
    [FptAuthorize]
    public class CreateModel : PageModel
    {
        private readonly cron_jobContext _context;
        private readonly ISchedulerFactory _schedulerFactory;
        public CreateModel(cron_jobContext context, ISchedulerFactory schedulerFactory)
        {
            _context = context;
            _schedulerFactory = schedulerFactory;
        }
        [BindProperty]
        public Models.Job Job { get; set; } = default!;
        public async Task<IActionResult> OnPost()
        {
            if (Job.Status == null || (!JobConstant.Status.ACTIVE.Equals(Job.Status.ToUpper())
                                       && !JobConstant.Status.INACTIVE.Equals(Job.Status.ToUpper())))
            {
                ViewData["Error"] = "Status must be 'Active' or 'Inactive'";
                return Page();
            }
            if (Job.Expression == null || Job.Expression.Trim().Length == 0)
            {
                ViewData["Error"] = "Cron Expression must not be empty";
                return Page();
            }
            
            // validate regex cron expression
            if (!CronExpression.IsValidExpression(Job.Expression))
            {
                ViewData["Error"] = "Cron Expression is invalid";
                return Page();
            }
            
            if(Job.Method == null || Job.Method.Trim().Length == 0 
                                  || (!JobConstant.Method.GET.Equals(Job.Method.ToUpper())
                                      && !JobConstant.Method.POST.Equals(Job.Method.ToUpper())
                                      && !JobConstant.Method.PUT.Equals(Job.Method.ToUpper())
                                      && !JobConstant.Method.DELETE.Equals(Job.Method.ToUpper())))
            {
                ViewData["Error"] = "Method must not be empty or 'GET', 'POST', 'PUT', 'DELETE'";
                return Page();
            }

            Job.Method = Job.Method.ToUpper();
            Job.Status = Job.Status.ToUpper();
            Job.CreatedAt = DateTime.Now;
            Job.UpdatedAt = DateTime.Now;
            _context.Jobs.Add(Job);
            await _context.SaveChangesAsync();
            
            string? email = HttpContext.Session.GetString("email");
            if(email == null)
            {
                return Redirect("/auth/login");
            }
            User? user = _context.Users.FirstOrDefault(u => u.Email!.Equals(email));
            if(user == null)  return Redirect("/auth/login");
            
            if (JobConstant.Status.ACTIVE.Equals(Job.Status.ToUpper()))
            {
                if (Job.Expression != null)
                {
                    IScheduler scheduler = await _schedulerFactory.GetScheduler();

                    if (user.Email != null)
                    {
                        IJobDetail job = JobBuilder.Create<UserCronJob>()
                            .WithIdentity(Job.JobId.ToString(), user.Email)
                            .Build();
                    
                        ITrigger trigger = TriggerBuilder.Create()
                            .WithIdentity(Job.JobId.ToString(), user.Email)
                            .WithCronSchedule(Job.Expression)
                            .Build();
            
                        await scheduler.ScheduleJob(job, trigger);
                    }
                } 
            }
            return RedirectToPage("/job/list");
        }
    }
}

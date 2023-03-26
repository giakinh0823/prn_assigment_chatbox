using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prn_job_manager.Constant;
using prn_job_manager.CronJob;
using prn_job_manager.Models;
using Quartz;

namespace prn_job_manager.Pages.Scheduler
{
    public class EditModel : PageModel
    {
        private readonly cron_jobContext _context;
        private readonly ISchedulerFactory _schedulerFactory;

        public EditModel(cron_jobContext context,  ISchedulerFactory schedulerFactory)
        {
            _context = context;
            _schedulerFactory = schedulerFactory;
        }

        [BindProperty]
        public Job Job { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
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
            if (jobs.Count >= 1 && (paymentInfo == null || !PaymentStatusConstant.ACTIVE.Equals(paymentInfo?.Status)
                                                        || paymentInfo.EndDate <= DateTime.Now))
            {
                return new RedirectResult("/settings/billing");
            }
            
            if (id == null)
            {
                return NotFound();
            }

            var job =  await _context.Jobs.FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }
            Job = job;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            string? email = HttpContext.Session.GetString("email");
            if(email == null)
            {
                return Redirect("/auth/login");
            }
            User? user = _context.Users.FirstOrDefault(u => u.Email!.Equals(email));
            if(user == null)  return Redirect("/auth/login");
            
            try
            {
                IScheduler scheduler = await _schedulerFactory.GetScheduler();
                await scheduler.DeleteJob(new JobKey(Job.JobId.ToString(), user.UserId.ToString()));

                if (JobConstant.Status.ACTIVE.Equals(Job.Status))
                {
                    if (Job.Expression != null)
                    {
                        {
                            IJobDetail job = JobBuilder.Create<UserCronJob>()
                                .WithIdentity(Job.JobId.ToString(), user.UserId.ToString())
                                .Build();
                    
                            ITrigger trigger = TriggerBuilder.Create()
                                .WithIdentity(Job.JobId.ToString(), user.UserId.ToString())
                                .WithCronSchedule(Job.Expression)
                                .Build();
                        
                            await scheduler.ScheduleJob(job, trigger);
                        }
                    }   
                }
                Job.UpdatedAt = DateTime.Now;
                _context.Attach(Job).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(Job.JobId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobExists(int id)
        {
          return (_context.Jobs?.Any(e => e.JobId == id)).GetValueOrDefault();
        }
    }
}

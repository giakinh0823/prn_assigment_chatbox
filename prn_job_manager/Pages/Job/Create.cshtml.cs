using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using prn_job_manager.Constant;
using prn_job_manager.Models;

namespace prn_job_manager.Pages.Job
{
    [FptAuthorize]
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
            if(Job.Method == null || Job.Method.Trim().Length == 0 
                                  || (!JobConstant.Method.GET.Equals(Job.Method.ToUpper())
                                      && !JobConstant.Method.POST.Equals(Job.Method.ToUpper())
                                      && !JobConstant.Method.PUT.Equals(Job.Method.ToUpper())
                                      && !JobConstant.Method.DELETE.Equals(Job.Method.ToUpper())))
            {
                ViewData["Error"] = "Method must not be empty or 'GET', 'POST', 'PUT', 'DELETE'";
                return Page();
            }
            Job.CreatedAt = DateTime.Now;
            Job.UpdatedAt = DateTime.Now;
            _context.Jobs.Add(Job);
            _context.SaveChanges();
            return RedirectToPage("/job/list");
        }
    }
}

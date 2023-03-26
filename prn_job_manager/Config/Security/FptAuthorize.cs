using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using prn_job_manager.Models;

public class FptAuthorize : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var email = context.HttpContext.Session.GetString("email");
        if (email == null)
        {
            context.Result = new RedirectToPageResult("/Auth/Login");
        }
        var user = context.HttpContext.RequestServices.GetService(typeof(cron_jobContext)) as cron_jobContext;
        if (user == null)
        {
            context.Result = new RedirectToPageResult("/Auth/Login");
        }
        var u = user.Users.FirstOrDefault(x => x.Email == email);
        if (u == null)
        {
            context.Result = new RedirectToPageResult("/Auth/Login");
        }
    }
}
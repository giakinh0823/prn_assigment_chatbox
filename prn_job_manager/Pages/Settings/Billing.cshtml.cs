using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using prn_job_manager.Constant;
using prn_job_manager.Models;
using Quartz;
using Stripe.Checkout;

namespace prn_job_manager.Pages.Settings;

public class BillingModel : PageModel
{
    
    private readonly cron_jobContext _context;
    public BillingModel(cron_jobContext context)
    {
        _context = context;
    }
    public void OnGet()
    {
        var email = HttpContext.Session.GetString("email");
        if (email == null)
        {
            Response.Redirect("/auth/login");
        }

        User? user = _context.Users.FirstOrDefault(x => x.Email == email);
        
        ViewData["paymentInfo"] = "You're on Free Plan";

        PaymentInfo? paymentInfo = _context.PaymentInfos.FirstOrDefault(x => x.UserId == user.UserId);
        if (paymentInfo != null && PaymentStatusConstant.ACTIVE.Equals(paymentInfo?.Status)
            && paymentInfo.EndDate > DateTime.Now)
        {
            ViewData["paymentInfo"] = "Expire time " + paymentInfo?.EndDate.ToString("dd/MM/yyyy");
        }
    }
    
    public async Task<RedirectResult> OnPost(int? month)
    {
        var email = HttpContext.Session.GetString("email");
        if (email == null)
        {
            Response.Redirect("/auth/login");
        }

        User? user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        
        if(month == null) return new RedirectResult("/Settings/Billing");
        int price = (int)(month * 39000);

        PaymentInfo? paymentInfo = _context.PaymentInfos.FirstOrDefault(x => x.UserId == user.UserId);

        if (paymentInfo == null)
        {
            paymentInfo = new PaymentInfo()
            {
                UserId = user!.UserId,
                PaymentAmount = price,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths((int)month),
                Status = PaymentStatusConstant.PENDING,
            };
            _context.PaymentInfos.Add(paymentInfo);
            await _context.SaveChangesAsync();   
        }
        else
        {
            if (paymentInfo.EndDate > DateTime.Now && PaymentStatusConstant.ACTIVE.Equals(paymentInfo?.Status))
            {
                return new RedirectResult("/Settings/Billing");
            }
            paymentInfo.UserId = user!.UserId;
            paymentInfo.PaymentAmount = price;
            paymentInfo.StartDate = DateTime.Now;
            paymentInfo.EndDate = DateTime.Now.AddMonths((int)month);
            paymentInfo.Status = PaymentStatusConstant.PENDING;
            _context.PaymentInfos.Update(paymentInfo);
            await _context.SaveChangesAsync();   
        }

        var domain = "https://localhost:44315";
        
        var options = new SessionCreateOptions()
        {
            LineItems = new List<SessionLineItemOptions>
            {
                new()
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = price,
                        Currency = "vnd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Payment for " + month + " month for " + user!.Email,
                        },
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment",
            SuccessUrl = domain + "/api/settings/billing/success/" + paymentInfo.PaymentId,
            CancelUrl = domain + "/api/settings/billing/cancel/" + paymentInfo.PaymentId,
        };
        var service = new SessionService();
        Session session = service.Create(options);

        return new RedirectResult(session.Url);   
    }
}
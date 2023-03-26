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

        PaymentInfo paymentInfo = new PaymentInfo()
        {
            UserId = user!.UserId,
            PaymentAmount = price,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths((int)month),
            Status = PaymentStatusConstant.PENDING,
        };
        _context.PaymentInfos.Add(paymentInfo);
        
        var domain = "http://localhost:44315";
        
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
            SuccessUrl = domain + "/settings/billing/success",
            CancelUrl = domain + "/settings/billing/cancel",
            AutomaticTax = new SessionAutomaticTaxOptions { Enabled = true },
        };
        var service = new SessionService();
        Session session = service.Create(options);

        return new RedirectResult(session.Url);   
    }
}
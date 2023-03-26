using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prn_job_manager.Constant;
using prn_job_manager.Models;

namespace prn_job_manager.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class SettingsController : Controller
{
    private readonly cron_jobContext _context;
    
    public SettingsController(cron_jobContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return Ok("pong");
    }
    
    [HttpGet("billing/success/{id}")]
    public IActionResult BillingSuccess(int id)
    {
        PaymentInfo? paymentInfo = _context.PaymentInfos.Find(id);
        if(paymentInfo == null) return NotFound();
        paymentInfo.Status = PaymentStatusConstant.ACTIVE;
        _context.PaymentInfos.Update(paymentInfo);
        _context.SaveChanges();
        return Redirect("/settings/billing");
    }
    
    [HttpGet("billing/cancel/{id}")]
    public IActionResult BillingCancel(int id)
    {
        PaymentInfo? paymentInfo = _context.PaymentInfos.Find(id);
        if(paymentInfo == null) return NotFound();
        paymentInfo.Status = PaymentStatusConstant.CANCEL;
        _context.PaymentInfos.Update(paymentInfo);
        _context.SaveChanges();
        return Redirect("/settings/billing");
    }
}
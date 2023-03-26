using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace prn_job_manager.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class PingController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("pong");
    }
}
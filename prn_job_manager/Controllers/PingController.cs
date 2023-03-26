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
    
    // post
    [HttpPost]
    public IActionResult Post()
    {
        return Ok("pong");
    }
    
    [HttpPost("payload")]
    public IActionResult Payload([FromBody] string payload)
    {
        return Ok(payload);
    }
}
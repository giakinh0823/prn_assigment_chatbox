using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace prn_job_manager.Controllers;

[AllowAnonymous]
[ApiController]
[Produces("application/json")]
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
    public IActionResult Payload([FromBody] ResultModel payload)
    {
        // return json
        return Ok(payload);
    }
}

public class ResultModel
{
    public string? Name { get; set; }
}
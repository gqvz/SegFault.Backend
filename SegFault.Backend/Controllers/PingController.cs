using Microsoft.AspNetCore.Mvc;

namespace SegFault.Backend.Controllers;

[ApiController]
public class PingController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping() => Ok();
}
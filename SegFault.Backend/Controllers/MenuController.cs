using Microsoft.AspNetCore.Mvc;
using SegFault.Backend.Database;

namespace SegFault.Backend.Controllers;

[ApiController]
[Route("menu")]
public class MenuController(ILogger<UserController> logger, SessionService sessionService) : AuthController(sessionService)
{
    [HttpGet("{bhawan}")]
    public async Task<MenuResult> GetMenuAsync([FromRoute] string bhawan)
    {
        return null;
    }
}
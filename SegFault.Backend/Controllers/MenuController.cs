using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using SegFault.Backend.Database;

namespace SegFault.Backend.Controllers;

[ApiController]
[Route("menu")]
public class MenuController(ILogger<UserController> logger, SessionService sessionService, MenuService menuService) : AuthController(sessionService)
{
    [HttpGet("{bhawan}")]
    public async Task<string> GetMenuAsync([FromRoute] string bhawan)
    {
        IAsyncCursor<MenuResult?> result = await menuService.Menus.FindAsync(m => m.Bhawan == bhawan);
        var list = result.ToList();
        return JsonConvert.SerializeObject(list.FirstOrDefault());
    }
}
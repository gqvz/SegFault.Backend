using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Driver;
using SegFault.Backend.Database;

namespace SegFault.Backend.Controllers;

public class AuthController(SessionService sessionService) : Controller
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue("Auth", out var authHeader))
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        var authData = authHeader.ToString().Split(' ');
        var enrollmentNumber = Convert.ToUInt32(authData[0]);
        var sessionToken = authData[1];
        var result = await sessionService.Sessions.FindAsync(s => s.EnrollmentNumber == enrollmentNumber && s.SessionToken == sessionToken);
        if (result is null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        await base.OnActionExecutionAsync(context, next);
    }
}
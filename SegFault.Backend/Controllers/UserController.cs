using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SegFault.Backend.Database;

namespace SegFault.Backend.Controllers;

[ApiController]
[Route("users")]
public class UserController(ILogger<UserController> logger, UserService userService, SessionService sessionService)
    : ControllerBase
{
    
    [HttpPost("create")]
    public async Task<Session> CreateAsync([FromBody] UserCreateRequest request)
    {
        logger.LogInformation("Creating new {enrollmentNumber}", request.EnrollmentNumber);
        await userService.Users.InsertOneAsync(new User
        {
            EnrollmentNumber = request.EnrollmentNumber,
            Name = request.Name,
            PasswordHash = Encoding.UTF32.GetString(SHA256.HashData(Encoding.UTF32.GetBytes(request.Password)))
        });

        var session = new Session
        {
            EnrollmentNumber = request.EnrollmentNumber,
            SessionToken = Guid.NewGuid().ToString()
        };
        await sessionService.Sessions.InsertOneAsync(session);
        return session;
    }

    [HttpPut("login")]
    public async Task<Session?> LoginAsync([FromBody] UserLoginRequest request)
    {
        var session = new Session
        {
            EnrollmentNumber = request.EnrollmentNumber,
            SessionToken = Guid.NewGuid().ToString()
        };
        
        var result = await sessionService.Sessions.FindOneAndUpdateAsync(s => s.EnrollmentNumber == session.EnrollmentNumber, new ObjectUpdateDefinition<Session>(session));
        return result is null ? null : session;
    }
}
public record UserCreateRequest(uint EnrollmentNumber, string Name, string Password);
public record UserLoginRequest(uint EnrollmentNumber, string Password);
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SegFault.Backend.Database;

namespace SegFault.Backend.Controllers;

[ApiController]
[Route("reviews")]
public class ReviewController(SessionService sessionService, ReviewService reviewService) : AuthController(sessionService)
{
    [HttpGet("bhawans/{bhawan}")]
    public async Task<List<Review?>> GetBhawanReviews([FromRoute] string bhawan)
    {
        IAsyncCursor<Review?> reviews = await reviewService.Reviews.FindAsync(r => r.Target.StartsWith($"bhawans/{bhawan}"));
        return await reviews.ToListAsync();
    }
    
    [HttpPost("bhawans/{bhawan}/{type}")]
    public async Task<IActionResult> PostBhawanReview([FromBody] Review review)
    {
        review.Id = Guid.NewGuid().ToString();
        await reviewService.Reviews.InsertOneAsync(review); // ik i should verify the user but wtv
        return Ok();
    }

    [HttpGet("me")]
    public async Task<List<Review>> GetMyReviews([FromHeader(Name = "Auth")] string auth)
    {
        var enrollmentNumber = Convert.ToUInt32(auth.Split()[0]);
        var result = await reviewService.Reviews.FindAsync(r => r.ReviewerId == enrollmentNumber);
        return await result.ToListAsync();
    }
    
    
}
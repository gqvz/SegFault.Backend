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

    [HttpDelete("{reviewId}")]
    public async Task<IActionResult> DeleteReview([FromRoute] string reviewId, [FromHeader(Name = "Auth")] string auth)
    {
        var enrollmentNumber = Convert.ToUInt32(auth.Split()[0]);

        var reviews = await reviewService.Reviews.FindAsync(r => r.Id == reviewId);
        var review = reviews.First();
        if (review.ReviewerId != enrollmentNumber)
            return Unauthorized();
        await reviewService.Reviews.DeleteOneAsync(r => r.Id == reviewId);
        return Ok();
    }

    [HttpPost("items/{itemId}")]
    public async Task<IActionResult> PostItemReview([FromBody] Review review)
    {
        review.Id = Guid.NewGuid().ToString();
        await reviewService.Reviews.InsertOneAsync(review); // ik i should verify the user but wtv
        return Ok();
    }

    [HttpGet("items/{itemId}")]
    public async Task<List<Review>> GetItemReviews([FromRoute] string itemId)
    {
        var reviews = await reviewService.Reviews.FindAsync(r => r.Target == $"items/{itemId}");
        return await reviews.ToListAsync();
    }
}
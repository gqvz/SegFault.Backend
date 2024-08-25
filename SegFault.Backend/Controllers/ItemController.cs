using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SegFault.Backend.Calculations;
using SegFault.Backend.Database;

namespace SegFault.Backend.Controllers;

[ApiController]
[Route("items")]
public class ItemController(SessionService sessionService, ItemService itemService, ReviewService reviewService) : AuthController(sessionService)
{
    [HttpGet("{itemId}")]
    public async Task<IActionResult> GetItemAsync([FromRoute] string itemId)
    {
        var item = await itemService.MenuItems.FindAsync(i => i.Id == itemId);
        return Ok(item.First());
    }

    [HttpGet("sort")]
    public async Task<IActionResult> GetSortedItemsAsync([FromQuery] string property, [FromHeader(Name = "Auth")] string auth, [FromQuery] float min,
        [FromQuery] float max)
    {
        var enrollmentNumber = Convert.ToUInt32(auth.Split()[0]);
        var result = await (await reviewService.Reviews.FindAsync(r => r.ReviewerId == enrollmentNumber)).ToListAsync();
        var dict = new Dictionary<Review, MenuItem>();
        foreach (var review in result)
        {
            dict[review] = (await itemService.MenuItems.FindAsync(i => i.Id == review.Target.Substring(6))).First();
        }
        var calcTt = new CalculateTasteTolerances();
        calcTt.FoodReview(dict, property, min, max);
        var items = await (await itemService.MenuItems.FindAsync(
            i => i.Ratings[property] >= min && i.Ratings[property] <= max)).ToListAsync();
        return Ok(items);
    }
}
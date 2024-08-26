using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using SegFault.Backend.Calculations;
using SegFault.Backend.Database;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace SegFault.Backend.Controllers;

[ApiController]
[Route("items")]
public class ItemController(SessionService sessionService, ItemService itemService, ReviewService reviewService) : AuthController(sessionService)
{
    [HttpGet("{itemId}")]
    public async Task<IActionResult> GetItemAsync([FromRoute] string itemId)
    {
        var item = await itemService.MenuItems.FindAsync(i => i.Id.ToString() == itemId);
        return Ok(JsonConvert.SerializeObject(item.First()));
    }

    [HttpGet("sort")]
    public async Task<IActionResult> GetSortedItemsAsync([FromQuery] string property, [FromHeader(Name = "Auth")] string auth, [FromQuery] float min,
        [FromQuery] float max)
    {
        var enrollmentNumber = Convert.ToUInt32(auth.Split()[0]);
        var result = await (await reviewService.Reviews.FindAsync(r => r.ReviewerId == enrollmentNumber)).ToListAsync();
        var dict = new Dictionary<Review, MenuItem>();
        var res = (await itemService.MenuItems.FindAsync(x => true)).ToList();
        foreach (var review in result)
        {
            dict[review] = res.First(i => i.Id.ToString() == review.Target[6..]);
        }

        var calcTt = new CalculateTasteTolerances();
        (min, max) = calcTt.FoodReview(dict, property, min, max);
        var items = await (await itemService.MenuItems.FindAsync(
            i => i.Ratings[property] >= min && i.Ratings[property] <= max)).ToListAsync();
        return Ok(JsonConvert.SerializeObject(items));
    }
}
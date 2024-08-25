using MongoDB.Driver;
using SegFault.Backend.Database;
using HostingEnvironmentExtensions = Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions;

namespace SegFault.Backend.Calculations;

public class UpdateFoodReview
{
	public async Task<Dictionary<string, int>> FoodReview(IAsyncCursor<Review> reviews)
	{
		Dictionary<string,int> ratings=new Dictionary<string, int>();
		foreach(var review in await reviews.ToListAsync())
		{
			review.
		}
		return ratings;
	}

}
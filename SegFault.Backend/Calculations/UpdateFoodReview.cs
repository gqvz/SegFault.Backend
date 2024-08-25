using MongoDB.Driver;
using SegFault.Backend.Database;
using HostingEnvironmentExtensions = Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions;

namespace SegFault.Backend.Calculations;

public class UpdateFoodReview
{
	public Dictionary<string, int> FoodReview(IAsyncCursor<Review> reviews)
	{
		Dictionary<string,int> ratings=new Dictionary<string, int>();
		
		return ratings;
	}

}
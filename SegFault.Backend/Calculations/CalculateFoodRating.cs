using MongoDB.Driver;
using SegFault.Backend.Database;

namespace SegFault.Backend.Calculations;

public class CalculateFoodRating
{
	public async Task<Dictionary<string, double>> FoodReview(IAsyncCursor<Review> reviews)
	{
		Dictionary<string,double> ratings=new Dictionary<string, double>();
		Dictionary<string,double>  weightedSum=new Dictionary<string, double>();
		double weightSum=0;
		
		foreach (var review in await reviews.ToListAsync())
		{
			
			double timeDifference = (DateTime.Now - DateTimeOffset.FromUnixTimeMilliseconds(review.Timestamp).DateTime).Days/1461.0;
			if (timeDifference > 1) continue; // Ignore all reviews older than 4 years
			double weight = Math.Pow(1 - Math.Sqrt(timeDifference), 2);
			foreach (string ratingType in review.CustomParameters.Keys)
			{
				if (weightedSum.ContainsKey(ratingType))
				{
				weightedSum[ratingType]+= review.CustomParameters[ratingType]*weight;
				}
				else
				{
					weightedSum[ratingType]= review.CustomParameters[ratingType]*weight;
				}
			}
			weightSum += weight;
		}

		foreach (var ratingType in weightedSum.Keys)
		{
			ratings[ratingType]=(float)((weightedSum[ratingType]+3.75) / (weightSum+1.5));
		}

		return ratings;
	}

}
using SegFault.Backend.Database;

namespace SegFault.Backend.Calculations;

public class CalculateTasteTolerances
{
    float GetScaledValue(Dictionary<Review, MenuItem> menuItems, string property, float value)
    {
        double userRatingSum = 0;
        double ratingSum = 0;
        int ratingCount = 0;
        foreach (var userRating in menuItems.Keys)
        {
            if (!userRating.CustomParameters.TryGetValue(property, out var parameter)) continue;
            userRatingSum += parameter;
            ratingSum += menuItems[userRating].Ratings[property];
            ratingCount++;
        }

        if (ratingCount > 0)
        {
            double avgUserRating=userRatingSum / ratingCount;
            double avgRating= ratingSum / ratingCount;
            
            if ((avgUserRating <= 0 && value <= 0)||(avgUserRating >= 5 && value >= 5))
            {
                return (float)avgUserRating;
            }
         
            if (value < avgUserRating)
            {
                return (float)((avgRating / avgUserRating) * value);
            }
            
            if (value > avgUserRating)
            {
                return (float)
                    ((((5-avgRating) / (5-avgUserRating)) * (value-avgUserRating))+avgRating);
            }
            return (float)avgRating;
        }

        return value;
    }

    public (float, float) FoodReview(Dictionary<Review, MenuItem> menuItems, string property, float min, float max)
    {
        return(GetScaledValue(menuItems,property,min),GetScaledValue(menuItems,property,max));
    }
}
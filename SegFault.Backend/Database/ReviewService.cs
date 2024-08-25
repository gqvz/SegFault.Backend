using MongoDB.Driver;

namespace SegFault.Backend.Database;

public class ReviewService
{
    public readonly IMongoCollection<Review> Reviews;
    
    public ReviewService(MongoClient client)
    {
        var db = client.GetDatabase("segfault");
        Reviews = db.GetCollection<Review>("reviews");
    }

}
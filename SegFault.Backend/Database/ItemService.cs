using MongoDB.Driver;

namespace SegFault.Backend.Database;

public class ItemService
{
    public readonly IMongoCollection<MenuItem> MenuItems;
    
    public ItemService(MongoClient client)
    {
        var db = client.GetDatabase("segfault");
        MenuItems = db.GetCollection<MenuItem>("items");
    }
}
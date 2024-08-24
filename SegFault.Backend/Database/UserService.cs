using MongoDB.Driver;

namespace SegFault.Backend.Database;

public class UserService
{
    public readonly IMongoCollection<User> Users;
    
    public UserService(MongoClient client)
    {
        var db = client.GetDatabase("segfault");
        Users = db.GetCollection<User>("users");
    }
}
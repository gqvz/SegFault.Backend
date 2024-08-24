using MongoDB.Driver;

namespace SegFault.Backend.Database;

public class SessionService
{
    public readonly IMongoCollection<Session> Sessions;
    
    public SessionService(MongoClient client)
    {
        var db = client.GetDatabase("segfault");
        Sessions = db.GetCollection<Session>("sessions");
    }

}
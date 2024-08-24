using MongoDB.Driver;

namespace SegFault.Backend.Database;

public class MenuService
{
    public readonly IMongoCollection<MenuResult> Menu;
    
    public MenuService(MongoClient client)
    {
        var db = client.GetDatabase("segfault");
        Menu = db.GetCollection<MenuResult>("menus");
    }
}
using MongoDB.Driver;

namespace SegFault.Backend.Database;

public class MenuService
{
    public readonly IMongoCollection<MenuResult> Menus;
    
    public MenuService(MongoClient client)
    {
        var db = client.GetDatabase("segfault");
        Menus = db.GetCollection<MenuResult>("menus");
    }
}
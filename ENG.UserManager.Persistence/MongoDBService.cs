using MongoDB.Driver;
using ENG.UserManager.Persistence;
using ENG.UserManager.Domain.Entities;

namespace ENG.UserManager.Services;

public class MongoDBService
{
    public IMongoCollection<User> UserCollection;

    public MongoDBService(MongoDBSettings mongoDBSettings)
    {
        MongoClient client = new("mongodb://"+mongoDBSettings.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.DatabaseName);

        // Collections
        UserCollection = database.GetCollection<User>(mongoDBSettings.CollectionName);
    }
}
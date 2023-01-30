using ENG.UserManager.Persistence;
using ENG.UserManager.Services;

namespace ENG.UserManager.API.Extensions;

public static class DBExtensions
{
    public static IServiceCollection AddMongoDBService(this IServiceCollection services, IConfiguration configuration)
    {
        MongoDBSettings mongoDBSettings = new()
        {
            ConnectionURI = Environment.GetEnvironmentVariable("MONGODB_URL") ?? configuration.GetSection("MongoDB:ConnectionURI").Value,
            DatabaseName = Environment.GetEnvironmentVariable("MONGODB_DATABASE") ?? configuration.GetSection("MongoDB:DatabaseName").Value,
            CollectionName = Environment.GetEnvironmentVariable("MONGODB_COLLECTION") ?? configuration.GetSection("MongoDB:CollectionName").Value
        };

        services.AddSingleton(new MongoDBService(mongoDBSettings));

        return services;
    }
}

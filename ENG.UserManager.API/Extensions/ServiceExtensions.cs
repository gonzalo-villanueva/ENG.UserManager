
using ENG.UserManager.Application.Handlers;
using ENG.UserManager.Domain.Interfaces.Repositories;
using ENG.UserManager.Domain.Interfaces.Services;
using ENG.UserManager.Services;

namespace ENG.UserManager.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddMemoryCache();

        return services;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENG.UserManager.Domain.Interfaces.Repositories;
using ENG.UserManager.Persistence;
using ENG.UserManager.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ENG.UserManager.Infrastructure.Mappers;

namespace ENG.UserManager.API.Extensions;

public static class AutoMapperExtensions
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services, params Assembly[] assemblies)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(assemblies);
            cfg.AddProfile<AutoMapperProfile>();
        });

        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}

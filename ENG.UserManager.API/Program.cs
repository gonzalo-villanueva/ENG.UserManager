
using AutoMapper;
using ENG.UserManager.API.Controllers;
using ENG.UserManager.API.Extensions;
using ENG.UserManager.Domain.Interfaces.Repositories;
using ENG.UserManager.Domain.Interfaces.Services;
using ENG.UserManager.Persistence;
using ENG.UserManager.Services;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        builder.Services.AddMongoDBService(builder.Configuration);
        builder.Services.AddServices();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("CorsPolicy");

        //app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
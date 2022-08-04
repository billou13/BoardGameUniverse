using BGU.Database.Postgres;
using BGU.Database.Postgres.Entities;
using BGU.Database.Redis;
using BGU.MarvelChampions.Extensions;
using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.DeckService.Services;
using BGU.MarvelChampions.DeckService.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;
using System;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Configure API gateway services.
    builder.Services.ConfigureCardApiGatewayService();

    builder.Services.AddAutoMapper(cfg =>
    {
        cfg.CreateMap<DeckEntity, Deck>();
        cfg.CreateMap<Deck, DeckEntity>();
    });

    string postgresUrl = Environment.GetEnvironmentVariable(builder.Configuration["EnvironmentVariables:PostgresDatabaseUrl"]);
    builder.Services.ConfigurePostgres(postgresUrl);

    string redisUrl = Environment.GetEnvironmentVariable(builder.Configuration["EnvironmentVariables:RedisDatabaseUrl"]);
    builder.Services.ConfigureRedis(redisUrl);

    builder.Services.AddScoped<IDeckService, DeckService>();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    if (!app.Environment.IsDevelopment())
    {
        var port = Environment.GetEnvironmentVariable("PORT") ?? "7002";
        app.Run("http://0.0.0.0:" + port);
    }
    else
    {
        app.Run();
    }
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}

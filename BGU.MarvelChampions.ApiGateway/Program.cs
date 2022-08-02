using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddOcelot(builder.Configuration);

    builder.Services.AddCors(options =>
    {
        var origins = builder.Configuration.GetSection("EnableCorsOrigins").Get<string[]>();
        options.AddPolicy(
            "CorsPolicy",
            policy => policy.WithOrigins(origins)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
    });

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

    app.UseOcelot().Wait();

    app.UseCors("CorsPolicy");

    app.MapControllers();

    if (!app.Environment.IsDevelopment())
    {
        var port = Environment.GetEnvironmentVariable("PORT") ?? "7500";
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

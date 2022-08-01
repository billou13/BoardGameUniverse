using BGU.Database.Redis.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace BGU.Database.Redis;

public static class RedisServiceCollectionExtensions
{
    public static IServiceCollection ConfigureRedis(this IServiceCollection services, string connectionUrl)
    {
        services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(RedisInfo.Parse(connectionUrl).ConfigurationString));
        services.AddScoped<IRedisDal, RedisDal>();

        return services;
    }
}

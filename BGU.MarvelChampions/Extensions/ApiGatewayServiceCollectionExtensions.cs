using BGU.MarvelChampions.Services;
using BGU.MarvelChampions.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BGU.MarvelChampions.Extensions;

public static class ApiGatewayServiceCollectionExtensions
{
    public static IServiceCollection ConfigureCardApiGatewayService(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<ICardApiGatewayService, CardApiGatewayService>();
        
        return services;
    }

    public static IServiceCollection ConfigurePackApiGatewayService(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IPackApiGatewayService, PackApiGatewayService>();
        
        return services;
    }
}

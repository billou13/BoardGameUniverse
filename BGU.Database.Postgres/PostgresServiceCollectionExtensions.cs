using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BGU.Database.Postgres;

public static class PostgresServiceCollectionExtensions
{
    public static IServiceCollection ConfigurePostgres(this IServiceCollection services, string connectionUrl)
    {
        services.AddDbContext<DeckDbContext>(
            options =>
            {
                options
                    .UseNpgsql(PostgresInfo.Parse(connectionUrl).ConnectionString)
                    .UseSnakeCaseNamingConvention();
            });

        return services;
    }
}

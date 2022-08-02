using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.Services;

public class PackApiGatewayService : ApiGatewayService, IPackApiGatewayService
{
    public PackApiGatewayService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        : base(configuration, httpClientFactory)
    {
    }

    public async Task<Pack?> GetAsync(string code)
    {
        return await RequestGetAsync<Pack?>($"/pack?code={code}");
    }
}

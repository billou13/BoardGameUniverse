using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.Services;

public class CardApiGatewayService : ApiGatewayService, ICardApiGatewayService
{
    public CardApiGatewayService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        : base(configuration, httpClientFactory)
    {
    }

    public async Task<Card?> GetAsync(string code)
    {
        return await RequestGetAsync<Card?>($"/card?code={code}");
    }
}

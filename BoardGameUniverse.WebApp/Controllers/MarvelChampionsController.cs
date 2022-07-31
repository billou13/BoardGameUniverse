using Microsoft.AspNetCore.Mvc;

namespace BoardGameUniverse.WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class MarvelChampionsController : ApiGatewayController
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<MarvelChampionsController> _logger;

    private string CardServiceRootUrl
    {
        get { return _configuration["ApiGateway:RootUrls:CardService"]; }
    }

    private string PackServiceRootUrl
    {
        get { return _configuration["ApiGateway:RootUrls:PackService"]; }
    }

    public MarvelChampionsController(IConfiguration configuration, ILogger<MarvelChampionsController> logger, IHttpClientFactory httpClientFactory)
        : base (httpClientFactory)
    {
        _configuration = configuration;
        _logger = logger;
    }

    [HttpGet("packs")]
    public async Task<string> GetAllPacks()
    {
        var response = await TransferRequest($"{PackServiceRootUrl}/packs");
        return await response.Content.ReadAsStringAsync();
    }

    [HttpGet("cards")]
    public async Task<string> GetAllCards(string pack)
    {
        var response = await TransferRequest($"{CardServiceRootUrl}/cards?pack={pack}");
        return await response.Content.ReadAsStringAsync();
    }

    [HttpGet("card")]
    public async Task<string> GetCard(string code)
    {
        var response = await TransferRequest($"{CardServiceRootUrl}/card?code={code}");
        return await response.Content.ReadAsStringAsync();
    }
}

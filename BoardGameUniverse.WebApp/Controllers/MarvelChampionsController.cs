using BGU.MarvelChampions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BoardGameUniverse.WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class MarvelChampionsController : ApiGatewayController
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<MarvelChampionsController> _logger;
    private readonly IMemoryCache _memoryCache;
    private readonly IWebHostEnvironment _env;

    private string CardServiceRootUrl
    {
        get { return _configuration["ApiGateway:RootUrls:CardService"]; }
    }

    private string PackServiceRootUrl
    {
        get { return _configuration["ApiGateway:RootUrls:PackService"]; }
    }

    public MarvelChampionsController(IConfiguration configuration, ILogger<MarvelChampionsController> logger, IMemoryCache memoryCache, IHttpClientFactory httpClientFactory, IWebHostEnvironment env)
        : base (httpClientFactory)
    {
        _configuration = configuration;
        _logger = logger;
        _memoryCache = memoryCache;
        _env = env;
    }

    [HttpGet("packs")]
    public async Task<string> GetAllPacks()
    {
        var response = await SendHttpRequestAsync(Request.Method, $"{PackServiceRootUrl}/packs");
        return await response.Content.ReadAsStringAsync();
    }

    [HttpGet("cards")]
    public async Task<string> GetAllCards(string pack)
    {
        var response = await SendHttpRequestAsync(Request.Method, $"{CardServiceRootUrl}/cards?pack={pack}");
        return await response.Content.ReadAsStringAsync();
    }

    [HttpGet("card")]
    public async Task<string> GetCard(string code)
    {
        var response = await SendHttpRequestAsync(Request.Method, $"{CardServiceRootUrl}/card?code={code}");
        return await response.Content.ReadAsStringAsync();
    }

    [HttpGet("cardimage")]
    public async Task<IActionResult> GetCardImage(string code)
    {
        string cacheKey = $"GetCardImage-{code}";
        if (!_memoryCache.TryGetValue<string>(cacheKey, out string path))
        {
            var card = await SendHttpGetRequestAsync<Card>($"{CardServiceRootUrl}/card?code={code}");
            if (card.DuplicateOf != null)
            {
                card = await SendHttpGetRequestAsync<Card>($"{CardServiceRootUrl}/card?code={card.DuplicateOf}");
            }

            var pack = await SendHttpGetRequestAsync<Pack>($"{PackServiceRootUrl}/pack?code={card.PackCode}");
            
            string suffix = string.Empty;
            char lastCodeChar = code[code.Length -1];
            if (Char.IsLetter(lastCodeChar) && lastCodeChar != 'a')
            {
                suffix = $".{lastCodeChar}";
            }

            path = Path.Combine(_env.WebRootPath, $"Img/Cards/{pack.OctgnId}/Cards/{card.OctgnId}{suffix}.jpg");
            
            _memoryCache.Set<string>(cacheKey, path);
        }

        return PhysicalFile(path, "image/jpg");
    }
}

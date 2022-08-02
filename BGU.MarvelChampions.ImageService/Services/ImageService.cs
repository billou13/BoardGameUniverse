using BGU.MarvelChampions.Services.Interfaces;
using BGU.MarvelChampions.ImageService.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.ImageService.Services;

public class ImageService : IImageService
{
    private readonly ILogger<ImageService> _logger;
    private readonly IMemoryCache _memoryCache;
    private readonly ICardApiGatewayService _cardApiGatewayService;
    private readonly IPackApiGatewayService _packApiGatewayService;

    public ImageService(ILogger<ImageService> logger, IMemoryCache memoryCache, ICardApiGatewayService cardApiGatewayService, IPackApiGatewayService packApiGatewayService)
    {
        _logger = logger;
        _memoryCache = memoryCache;
        _cardApiGatewayService = cardApiGatewayService;
        _packApiGatewayService = packApiGatewayService;
    }

    public async Task<string?> GetCardPathAsync(string code)
    {
        try
        {
            string cacheKey = $"GetCardPathAsync_{code}";
            if (!_memoryCache.TryGetValue<string?>(cacheKey, out string? path))
            {
                path = await RequestForCardPathAsync(code);
                _memoryCache.Set<string?>(cacheKey, path);
            }

            return path;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while asynchronously getting card image path for code '{code}'.");
            throw;
        }
    }

    private async Task<string?> RequestForCardPathAsync(string code)
    {
        var card = await _cardApiGatewayService.GetAsync(code);
        if (card == null)
        {
            return null;
        }

        if (card.DuplicateOf != null)
        {
            card = await _cardApiGatewayService.GetAsync(card.DuplicateOf);
        }

        var pack = await _packApiGatewayService.GetAsync(card.PackCode);

        string suffix = string.Empty;
        char lastCodeChar = code[code.Length - 1];
        if (Char.IsLetter(lastCodeChar) && lastCodeChar != 'a')
        {
            suffix = $".{lastCodeChar}";
        }

        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Content/Cards/{pack.OctgnId}/Cards/{card.OctgnId}{suffix}.jpg");
    }
}

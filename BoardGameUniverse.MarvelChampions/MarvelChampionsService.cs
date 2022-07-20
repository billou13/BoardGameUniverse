using BoardGameUniverse.MarvelChampions.Data;
using BoardGameUniverse.MarvelChampions.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BoardGameUniverse.MarvelChampions;

public class MarvelChampionsService : IMarvelChampionsService
{
    private readonly ILogger<MarvelChampionsService> _logger;

    public MarvelChampionsService(ILogger<MarvelChampionsService> logger)
    {
        _logger = logger;
    }

    public async Task<Pack[]> GetAllPacksAsync()
    {
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Json/packs.json");
            using (var stream = File.OpenRead(path))
            {
                var packs = await JsonSerializer.DeserializeAsync<Pack[]>(stream);
                return packs != null ? packs : new Pack[] {};
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while asynchronously getting all packs.");
            throw;
        }
    }

    public async Task<Card[]> GetAllCardsAsync(string pack)
    {
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Json/Cards/{pack}.json");
            using (var stream = File.OpenRead(path))
            {
                var cards = await JsonSerializer.DeserializeAsync<Card[]>(stream);
                return cards != null ? cards : new Card[] {};
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while asynchronously getting all cards.");
            throw;
        }
    }

    public async Task<Card?> GetCardAsync(string pack, string code)
    {
        try
        {
            var cards = await GetAllCardsAsync(pack);
            foreach (var card in cards)
            {
                if (!string.Equals(card.Code, code, StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                return card;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while asynchronously getting card.");
            throw;
        }
    }
}

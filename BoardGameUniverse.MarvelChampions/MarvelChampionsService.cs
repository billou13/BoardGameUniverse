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

    public async Task<Card[]> GetAllCardsAsync(string pack)
    {
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Json/{pack}.json");
            using (var stream = File.OpenRead(path))
            {
                var cards = await JsonSerializer.DeserializeAsync<Card[]>(stream);
                return cards != null ? cards : new Card[] {};
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all cards async.");
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
            _logger.LogError(ex, "An error occurred while getting card async.");
            throw;
        }
    }
}

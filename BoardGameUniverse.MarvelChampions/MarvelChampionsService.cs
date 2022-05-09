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

    public async Task<Card?> GetCardAsync(string code)
    {
        try
        {
            using (var stream = File.OpenRead(@"Json\core.json"))
            {
                var cards = await JsonSerializer.DeserializeAsync<Card[]>(stream);
                if (cards == null)
                {
                    return null;
                }

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
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting card async.");
            throw;
        }
    }
}

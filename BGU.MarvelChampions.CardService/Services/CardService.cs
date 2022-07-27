using BGU.MarvelChampions.CardService.Models;
using BGU.MarvelChampions.CardService.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.CardService.Services;

public class CardService : ICardService
{
    private readonly ILogger<CardService> _logger;

    public CardService(ILogger<CardService> logger)
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

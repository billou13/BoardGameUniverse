using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.CardService.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.CardService.Services;

public class CardService : ICardService
{
    private readonly ILogger<CardService> _logger;
    private readonly IMemoryCache _memoryCache;

    public CardService(ILogger<CardService> logger, IMemoryCache memoryCache)
    {
        _logger = logger;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<Card>> GetAllByPackAsync(string pack)
    {
        try
        {
            string cacheKey = $"GetAllByPackAsync_{pack}";
            if (!_memoryCache.TryGetValue<IEnumerable<Card>>(cacheKey, out IEnumerable<Card> cards))
            {
                cards = await LoadAllByPackAsync(pack);
                _memoryCache.Set<IEnumerable<Card>>(cacheKey, cards);
            }

            return cards;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while asynchronously getting all cards for pack '{pack}'.");
            throw;
        }
    }

    public async Task<SortedList<string, Card>> GetAllAsync()
    {
        try
        {
            string cacheKey = "GetAllAsync";
            if (!_memoryCache.TryGetValue<SortedList<string, Card>>(cacheKey, out SortedList<string, Card> cards))
            {
                cards = await LoadAllAsync();
                _memoryCache.Set<SortedList<string, Card>>(cacheKey, cards);
            }

            return cards;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while asynchronously getting all packs.");
            throw;
        }
    }

    public async Task<Card?> GetAsync(string code)
    {
        try
        {
            var cards = await GetAllAsync();
            return cards.ContainsKey(code) ? cards[code] : null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while asynchronously getting card by code '{code}'.");
            throw;
        }
    }

    private async Task<IEnumerable<Card>> LoadAllByPackAsync(string pack)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Json/{pack}.json");
        using (var stream = File.OpenRead(path))
        {
            var cards = await JsonSerializer.DeserializeAsync<Card[]>(stream);
            return cards != null ? cards : new Card[] {};
        }
    }

    private async Task<SortedList<string, Card>> LoadAllAsync()
    {
        var result = new SortedList<string, Card>();
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json");
        foreach (var file in Directory.EnumerateFiles(path, "*.json"))
        {
            var cards = await GetAllByPackAsync(Path.GetFileNameWithoutExtension(file));
            if (cards != null)
            foreach (var card in cards)
            {
                if (string.IsNullOrEmpty(card.Code))
                {
                    throw new InvalidDataException($"A card without code exists in the '{file}' file.");
                }

                if (result.ContainsKey(card.Code))
                {
                    continue;
                }

                result.Add(card.Code, card);
            }
        }

        return result;
    }
}

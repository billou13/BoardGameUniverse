using BGU.MarvelChampions.CardService.Entities;
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

    public async Task<SortedList<string, CardEntity>> GetAllByPackAsync(string pack)
    {
        try
        {
            string cacheKey = $"GetAllByPackAsync_{pack}";
            if (!_memoryCache.TryGetValue<SortedList<string, CardEntity>>(cacheKey, out SortedList<string, CardEntity> cards))
            {
                cards = await LoadPackAsync(pack);
                if (cards == null)
                {
                    return null;
                }

                _memoryCache.Set<SortedList<string, CardEntity>>(cacheKey, cards);
            }

            return cards;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while asynchronously getting all cards for pack '{pack}'.");
            throw;
        }
    }

    public async Task<SortedList<string, CardEntity>> GetAllAsync()
    {
        try
        {
            string cacheKey = "GetAllAsync";
            if (!_memoryCache.TryGetValue<SortedList<string, CardEntity>>(cacheKey, out SortedList<string, CardEntity> cards))
            {
                cards = await LoadAllFilesAsync();
                _memoryCache.Set<SortedList<string, CardEntity>>(cacheKey, cards);
            }

            return cards;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while asynchronously getting all packs.");
            throw;
        }
    }

    public async Task<CardEntity?> GetAsync(string code)
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

    public async Task<CardEntity?> GetPreviousAsync(string code)
    {
        try
        {
            var cards = await GetAllAsync();
            if (!cards.ContainsKey(code))
            {
                return null;
            }

            int index = cards.IndexOfKey(code);
            return index > 0 ? cards.Values[index - 1] : null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while asynchronously getting previous card by code '{code}'.");
            throw;
        }
    }

    public async Task<CardEntity?> GetNextAsync(string code)
    {
        try
        {
            var cards = await GetAllAsync();
            if (!cards.ContainsKey(code))
            {
                return null;
            }

            int index = cards.IndexOfKey(code);
            return index < cards.Count - 1 ? cards.Values[index + 1] : null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while asynchronously getting next card by code '{code}'.");
            throw;
        }
    }

    private async Task<SortedList<string, CardEntity>> LoadFileAsync(string fileName)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Json/{fileName}");
        if (!File.Exists(path))
        {
            return null;
        }

        var result = new SortedList<string, CardEntity>();
        using (var stream = File.OpenRead(path))
        {
            var cards = await JsonSerializer.DeserializeAsync<IEnumerable<CardEntity>>(stream);
            if (cards != null)
            foreach (var card in cards)
            {
                if (string.IsNullOrEmpty(card.Code))
                {
                    throw new InvalidDataException($"A card without code exists in the '{fileName}' file.");
                }

                result.Add(card.Code, card);
            }
        }

        return result;
    }

    private async Task<SortedList<string, CardEntity>> LoadPackAsync(string pack)
    {
        var cards = await LoadFileAsync($"{pack}.json");
        if (cards == null)
        {
            return null;
        }

        var items = new SortedList<string, CardEntity>();
        foreach (var card in cards)
        {
            items.Add(card.Key, card.Value);
        }

        var encounterCards = await LoadFileAsync($"{pack}_encounter.json");
        if (encounterCards != null)
        foreach (var encounterCard in encounterCards)
        {
            items.Add(encounterCard.Key, encounterCard.Value);
        }

        return items;
    }

    private async Task<SortedList<string, CardEntity>> LoadAllFilesAsync()
    {
        var items = new SortedList<string, CardEntity>();
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json");
        foreach (var file in Directory.EnumerateFiles(path, "*.json"))
        {
            var cards = await LoadFileAsync(Path.GetFileName(file));
            if (cards != null)
            foreach (var card in cards)
            {
                items.Add(card.Key, card.Value);
            }
        }

        return items;
    }
}

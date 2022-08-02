using BGU.MarvelChampions.PackService.Entities;
using BGU.MarvelChampions.PackService.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.PackService.Services;

public class PackService : IPackService
{
    private readonly ILogger<PackService> _logger;
    private readonly IMemoryCache _memoryCache;

    public PackService(ILogger<PackService> logger, IMemoryCache memoryCache)
    {
        _logger = logger;
        _memoryCache = memoryCache;
    }

    public async Task<SortedList<string, PackEntity>> GetAllAsync()
    {
        try
        {
            string cacheKey = "GetAllAsync";
            if (!_memoryCache.TryGetValue<SortedList<string, PackEntity>>(cacheKey, out SortedList<string, PackEntity> packs))
            {
                packs = await LoadAllAsync();
                _memoryCache.Set<SortedList<string, PackEntity>>(cacheKey, packs);
            }

            return packs;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while asynchronously getting all packs.");
            throw;
        }
    }

    public async Task<PackEntity?> GetAsync(string code)
    {
        try
        {
            var packs = await GetAllAsync();
            return packs.ContainsKey(code) ? packs[code] : null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while asynchronously getting pack by code '{code}'.");
            throw;
        }
    }

    private async Task<SortedList<string, PackEntity>> LoadAllAsync()
    {
        var result = new SortedList<string, PackEntity>();
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Json/packs.json");
        using (var stream = File.OpenRead(path))
        {
            var packs = await JsonSerializer.DeserializeAsync<PackEntity[]>(stream);
            if (packs != null)
            foreach (var pack in packs)
            {
                if (string.IsNullOrEmpty(pack.Code))
                {
                    throw new InvalidDataException("A pack without code exists in the 'packs.json' file.");
                }

                result.Add(pack.Code, pack);
            }
        }

        return result;
    }
}

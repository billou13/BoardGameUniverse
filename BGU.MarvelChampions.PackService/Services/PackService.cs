using BGU.MarvelChampions.PackService.Models;
using BGU.MarvelChampions.PackService.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.PackService.Services;

public class PackService : IPackService
{
    private readonly ILogger<PackService> _logger;

    public PackService(ILogger<PackService> logger)
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
}

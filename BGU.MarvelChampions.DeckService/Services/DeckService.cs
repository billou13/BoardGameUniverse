using BGU.MarvelChampions.DeckService.Models;
using BGU.MarvelChampions.DeckService.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.DeckService.Services;

public class DeckService : IDeckService
{
    private readonly ILogger<DeckService> _logger;

    public DeckService(ILogger<DeckService> logger)
    {
        _logger = logger;
    }
}

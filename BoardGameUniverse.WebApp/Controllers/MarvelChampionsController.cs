using BoardGameUniverse.MarvelChampions.Data;
using BoardGameUniverse.MarvelChampions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameUniverse.WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class MarvelChampionsController : ControllerBase
{
    private readonly ILogger<MarvelChampionsController> _logger;
    private readonly IMarvelChampionsService _service;

    public MarvelChampionsController(ILogger<MarvelChampionsController> logger, IMarvelChampionsService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("packs")]
    public async Task<Pack[]> GetAllPacks()
    {
        var packs = await _service.GetAllPacksAsync();
        _logger.LogDebug($"get all packs returns '{packs.Count()}' packs");
        return packs;
    }

    [HttpGet("cards")]
    public async Task<Card[]> GetAllCards(string pack)
    {
        var cards = await _service.GetAllCardsAsync(pack);
        _logger.LogDebug($"get all cards from pack '{pack}' returns '{cards.Count()}' cards");
        return cards;
    }

    [HttpGet("card")]
    public async Task<Card?> GetCard(string pack, string code)
    {
        var card = await _service.GetCardAsync(pack, code);
        _logger.LogDebug($"get card '{code}' from pack '{pack}' returns '{card?.Name}'");
        return card;
    }
}

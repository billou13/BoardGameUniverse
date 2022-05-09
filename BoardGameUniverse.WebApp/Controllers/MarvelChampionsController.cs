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

    [HttpGet("card")]
    public async Task<Card?> GetCard(string code)
    {
        var card = await _service.GetCardAsync(code);
        _logger.LogDebug($"get card '{code}' returns '{card?.Name}'");
        return card;
    }
}

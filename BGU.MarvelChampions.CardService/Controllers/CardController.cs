using BGU.MarvelChampions.CardService.Models;
using BGU.MarvelChampions.CardService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.CardService.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ILogger<CardController> _logger;
    private readonly ICardService _service;

    public CardController(ILogger<CardController> logger, ICardService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<Card?> Get(string pack, string code)
    {
        return await _service.GetCardAsync(pack, code);
    }
}

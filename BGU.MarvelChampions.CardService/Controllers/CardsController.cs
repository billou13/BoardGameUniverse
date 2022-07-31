using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.CardService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.CardService.Controllers;

[ApiController]
[Route("[controller]")]
public class CardsController : CardControllerBase
{
    private readonly ILogger<CardsController> _logger;

    public CardsController(ILogger<CardsController> logger, ICardService service)
        : base (service)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<Card>> Get(string pack)
    {
        var cards = await _service.GetAllByPackAsync(pack);
        await EnrichWithDuplicate(cards);
        return cards;
    }
}

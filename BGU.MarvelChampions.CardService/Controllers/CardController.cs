using BGU.MarvelChampions.CardService.Models;
using BGU.MarvelChampions.CardService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.CardService.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : CardControllerBase
{
    private readonly ILogger<CardController> _logger;

    public CardController(ILogger<CardController> logger, ICardService service)
        : base(service)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<Card?> Get(string code)
    {
        var card = await _service.GetAsync(code);
        await EnrichWithDuplicate(card);
        return card;
    }
}

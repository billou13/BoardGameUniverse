using AutoMapper;
using BGU.MarvelChampions.CardService.Entities;
using BGU.MarvelChampions.CardService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.CardService.Controllers;

[ApiController]
[Route("[controller]")]
public class CardsController : CardControllerBase
{
    private readonly ILogger<CardsController> _logger;

    public CardsController(ILogger<CardsController> logger, ICardService service, IMapper mapper)
        : base(service, mapper)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("pack")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetByPack(string code)
    {
        var cards = await _service.GetAllByPackAsync(code);
        if (cards == null)
        {
            return NotFound();
        }

        return Ok(await EnrichData(cards));
    }

    [HttpPost]
    [Route("codes")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByCodes(string[] codes)
    {
        var cards = new List<CardEntity>();
        foreach (string code in codes)
        {
            var card = await _service.GetAsync(code);
            if (card == null)
            {
                continue;
            }

            cards.Add(card);
        }

        return Ok(await EnrichData(cards));
    }
}

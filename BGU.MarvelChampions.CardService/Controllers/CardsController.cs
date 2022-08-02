using AutoMapper;
using BGU.MarvelChampions.CardService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
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
    [SwaggerResponse((int)HttpStatusCode.OK)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get(string pack)
    {
        var cards = await _service.GetAllByPackAsync(pack);
        if (cards == null)
        {
            return NotFound();
        }

        return Ok(await EnrichData(cards));
    }
}

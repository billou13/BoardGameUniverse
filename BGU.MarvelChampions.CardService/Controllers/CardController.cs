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
public class CardController : CardControllerBase
{
    private readonly ILogger<CardController> _logger;

    public CardController(ILogger<CardController> logger, ICardService service, IMapper mapper)
        : base(service, mapper)
    {
        _logger = logger;
    }

    [HttpGet]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get(string code)
    {
        var card = await _service.GetAsync(code);
        if (card == null)
        {
            return NotFound();
        }

        return Ok(await EnrichData(card));
    }

    [HttpGet]
    [Route("previous")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetPrevious(string code)
    {
        var card = await _service.GetPreviousAsync(code);
        if (card == null)
        {
            return NotFound();
        }

        return Ok(await EnrichData(card));
    }

    [HttpGet]
    [Route("next")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetNext(string code)
    {
        var card = await _service.GetNextAsync(code);
        if (card == null)
        {
            return NotFound();
        }

        return Ok(await EnrichData(card));
    }
}

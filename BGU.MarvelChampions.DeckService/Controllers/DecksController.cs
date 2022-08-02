using AutoMapper;
using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.DeckService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.DeckService.Controllers;

[ApiController]
[Route("[controller]")]
public class DecksController : ControllerBase
{
    private readonly ILogger<DecksController> _logger;
    private readonly IDeckService _service;
    private readonly IMapper _mapper;

    public DecksController(ILogger<DecksController> logger, IDeckService service, IMapper mapper)
    {
        _logger = logger;
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get()
    {
        var decks = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<Deck>>(decks));
    }
}

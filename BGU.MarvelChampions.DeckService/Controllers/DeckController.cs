using AutoMapper;
using BGU.Database.Postgres.Entities;
using BGU.MarvelChampions.DeckService.Services.Interfaces;
using BGU.MarvelChampions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.DeckService.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckController : ControllerBase
{
    private readonly ILogger<DeckController> _logger;
    private readonly IDeckService _service;
    private readonly IMapper _mapper;

    public DeckController(ILogger<DeckController> logger, IDeckService service, IMapper mapper)
    {
        _logger = logger;
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get(Guid guid)
    {
        var deck = await _service.GetAsync(guid);
        if (deck == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<Deck>(deck));
    }

    [HttpPost]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(Deck deck)
    {
        var guid = await _service.CreateAsync(_mapper.Map<DeckEntity>(deck));
        return Ok(guid);
    }

    [HttpGet]
    [Route("cards")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllCards(Guid guid)
    {
        var cards = await _service.GetAllCards(guid);
        return Ok(cards);
    }

    [HttpPost]
    [Route("cards")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddCard(DeckCard item)
    {
        return Ok(await _service.AddCard(item.DeckGuid, item.CardCode));
    }

    [HttpDelete]
    [Route("cards")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<IActionResult> RemoveCard(DeckCard item)
    {
        return Ok(await _service.RemoveCard(item.DeckGuid, item.CardCode));
    }
}

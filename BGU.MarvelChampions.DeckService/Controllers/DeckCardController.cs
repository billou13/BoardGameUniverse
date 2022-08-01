using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.DeckService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.DeckService.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckCardController : ControllerBase
{
    private readonly ILogger<DeckCardController> _logger;
    private readonly IDeckService _service;

    public DeckCardController(ILogger<DeckCardController> logger, IDeckService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<string>> GetAllCards(Guid guid)
    {
        return await _service.GetAllCards(guid);
    }

    [HttpPost]
    public async Task<bool> AddCard(DeckCard item)
    {
        return await _service.AddCard(item);
    }

    [HttpDelete]
    public async Task<bool> RemoveCard(DeckCard item)
    {
        return await _service.RemoveCard(item);
    }
}

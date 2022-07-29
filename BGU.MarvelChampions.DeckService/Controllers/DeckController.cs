using BGU.MarvelChampions.DeckService.Models;
using BGU.MarvelChampions.DeckService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.DeckService.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckController : ControllerBase
{
    private readonly ILogger<DeckController> _logger;
    private readonly IDeckService _service;

    public DeckController(ILogger<DeckController> logger, IDeckService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<Deck?> Get(Guid guid)
    {
        return await _service.GetDeckAsync(guid);
    }

    [HttpPost]
    public async Task<Guid?> Create(Deck deck)
    {
        return await _service.CreateDeckAsync(deck);
    }

    /*[HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _userService.Update(id, model);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
    }*/
}
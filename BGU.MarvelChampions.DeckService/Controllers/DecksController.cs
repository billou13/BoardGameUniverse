using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.DeckService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.DeckService.Controllers;

[ApiController]
[Route("[controller]")]
public class DecksController : ControllerBase
{
    private readonly ILogger<DecksController> _logger;
    private readonly IDeckService _service;

    public DecksController(ILogger<DecksController> logger, IDeckService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Deck>> Get()
    {
        return await _service.GetAllAsync();
    }
}

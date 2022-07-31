using BGU.MarvelChampions.CardService.Models;
using BGU.MarvelChampions.CardService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.CardService.Controllers;

[ApiController]
[Route("[controller]")]
public class CardsController : ControllerBase
{
    private readonly ILogger<CardsController> _logger;
    private readonly ICardService _service;

    public CardsController(ILogger<CardsController> logger, ICardService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Card>> Get(string pack)
    {
        return await _service.GetAllByPackAsync(pack);
    }
}

using BGU.MarvelChampions.DeckService.Models;
using BGU.MarvelChampions.DeckService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
}
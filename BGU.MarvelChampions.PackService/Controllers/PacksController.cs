using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.PackService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.PackService.Controllers;

[ApiController]
[Route("[controller]")]
public class PacksController : ControllerBase
{
    private readonly ILogger<PacksController> _logger;
    private readonly IPackService _service;

    public PacksController(ILogger<PacksController> logger, IPackService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Pack>> Get()
    {
        var packs = await _service.GetAllAsync();
        _logger.LogDebug($"get all packs returns '{packs.Count}' packs");
        return packs.Values;
    }
}

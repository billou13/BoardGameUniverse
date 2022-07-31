using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.PackService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.PackService.Controllers;

[ApiController]
[Route("[controller]")]
public class PackController : ControllerBase
{
    private readonly ILogger<PacksController> _logger;
    private readonly IPackService _service;

    public PackController(ILogger<PacksController> logger, IPackService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<Pack?> Get(string code)
    {
        return await _service.GetAsync(code);
    }
}

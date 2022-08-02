using AutoMapper;
using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.PackService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.PackService.Controllers;

[ApiController]
[Route("[controller]")]
public class PacksController : ControllerBase
{
    private readonly ILogger<PacksController> _logger;
    private readonly IPackService _service;
    private readonly IMapper _mapper;

    public PacksController(ILogger<PacksController> logger, IPackService service, IMapper mapper)
    {
        _logger = logger;
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get()
    {
        var packs = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<Pack>>(packs.Values));
    }
}

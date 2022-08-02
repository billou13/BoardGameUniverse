using AutoMapper;
using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.PackService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.PackService.Controllers;

[ApiController]
[Route("[controller]")]
public class PackController : ControllerBase
{
    private readonly ILogger<PacksController> _logger;
    private readonly IPackService _service;
    private readonly IMapper _mapper;

    public PackController(ILogger<PacksController> logger, IPackService service, IMapper mapper)
    {
        _logger = logger;
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get(string code)
    {
        var pack = await _service.GetAsync(code);
        return pack != null ? Ok(_mapper.Map<Pack>(pack)) : NotFound();
    }
}

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace BGU.MarvelChampions.PackService.Controllers;

[ApiController]
[Route("/")]
public class RootController : ControllerBase
{
    [HttpGet]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public IActionResult Get()
    {
        return Ok("Marvel Champions Pack service started.");
    }
}

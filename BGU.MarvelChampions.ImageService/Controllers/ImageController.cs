using BGU.MarvelChampions.ImageService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.ImageService.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
    private readonly ILogger<ImageController> _logger;
    private readonly IImageService _service;

    public ImageController(ILogger<ImageController> logger, IImageService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    [Route("card")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetCard(string code)
    {
        var path = await _service.GetCardPathAsync(code);
        if (path == null)
        {
            return NotFound();
        }

        return PhysicalFile(path, "image/jpg");
    }
}

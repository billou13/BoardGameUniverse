using Microsoft.AspNetCore.Mvc;

namespace BGU.MarvelChampions.PackService.Controllers;

[ApiController]
public class RootController : ControllerBase
{
    [Route("/")]
    public string Get()
    {
        return "Marvel Champions Pack service started.";
    }
}

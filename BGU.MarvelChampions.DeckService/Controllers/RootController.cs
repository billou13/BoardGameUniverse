using Microsoft.AspNetCore.Mvc;

namespace BGU.MarvelChampions.CardService.Controllers;

[ApiController]
public class RootController : ControllerBase
{
    [Route("/")]
    public string Get()
    {
        return "Marvel Champions Deck service started.";
    }
}

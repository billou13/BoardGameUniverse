using Microsoft.AspNetCore.Mvc;

namespace BGU.MarvelChampions.DeckService.Controllers;

[ApiController]
public class RootController : ControllerBase
{
    [Route("/")]
    public string Get()
    {
        return "Marvel Champions Deck service started.";
    }
}

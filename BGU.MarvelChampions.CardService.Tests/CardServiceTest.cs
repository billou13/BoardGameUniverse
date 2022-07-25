using BGU.MarvelChampions.CardService.Services.Interfaces;
using Microsoft.Extensions.Logging;
using NSubstitute;

using Services = BGU.MarvelChampions.CardService.Services;

namespace BGU.MarvelChampions.CardService.Tests;

public partial class CardServiceTest
{
    private ICardService _service;

    public CardServiceTest()
    {
        var logger = Substitute.For<ILogger<Services.CardService>>();
        _service = new Services.CardService(logger);
    }
}

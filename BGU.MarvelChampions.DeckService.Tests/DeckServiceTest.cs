using BGU.MarvelChampions.DeckService.Database;
using BGU.MarvelChampions.DeckService.Services.Interfaces;
using Microsoft.Extensions.Logging;
using NSubstitute;

using Services = BGU.MarvelChampions.DeckService.Services;

namespace BGU.MarvelChampions.DeckService.Tests;

public partial class DeckServiceTest
{
    private IDeckService _service;

    public DeckServiceTest()
    {
        var logger = Substitute.For<ILogger<Services.DeckService>>();
        var dbContext = Substitute.For<DeckDbContext>();
        _service = new Services.DeckService(logger, dbContext);
    }
}

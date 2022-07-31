using BGU.MarvelChampions.CardService.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
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

        var services = new ServiceCollection();
        services.AddMemoryCache();
        var serviceProvider = services.BuildServiceProvider();
        var memoryCache = serviceProvider.GetService<IMemoryCache>();
        
        _service = new Services.CardService(logger, memoryCache);
    }
}

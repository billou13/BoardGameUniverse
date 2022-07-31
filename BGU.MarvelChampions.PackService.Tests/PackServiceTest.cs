using BGU.MarvelChampions.PackService.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;

using Services = BGU.MarvelChampions.PackService.Services;

namespace BGU.MarvelChampions.PackService.Tests;

public partial class PackServiceTest
{
    private IPackService _service;

    public PackServiceTest()
    {
        var logger = Substitute.For<ILogger<Services.PackService>>();
        
        var services = new ServiceCollection();
        services.AddMemoryCache();
        var serviceProvider = services.BuildServiceProvider();
        var memoryCache = serviceProvider.GetService<IMemoryCache>();
        
        _service = new Services.PackService(logger, memoryCache);
    }
}

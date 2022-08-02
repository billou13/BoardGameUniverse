using BGU.MarvelChampions.Services;
using BGU.MarvelChampions.ImageService.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;

using Services = BGU.MarvelChampions.ImageService.Services;

namespace BGU.MarvelChampions.ImageService.Tests;

public partial class ImageServiceTest
{
    private IImageService _service;

    public ImageServiceTest()
    {
        var logger = Substitute.For<ILogger<Services.ImageService>>();
        
        var services = new ServiceCollection();
        services.AddMemoryCache();
        var serviceProvider = services.BuildServiceProvider();
        var memoryCache = serviceProvider.GetService<IMemoryCache>();

        var cardApiGatewayService = Substitute.For<CardApiGatewayService>();
        var packApiGatewayService = Substitute.For<PackApiGatewayService>();

        _service = new Services.ImageService(logger, memoryCache, cardApiGatewayService, packApiGatewayService);
    }
}

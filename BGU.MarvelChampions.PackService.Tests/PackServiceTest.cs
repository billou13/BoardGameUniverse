using BGU.MarvelChampions.PackService.Services.Interfaces;
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
        _service = new Services.PackService(logger);
    }
}

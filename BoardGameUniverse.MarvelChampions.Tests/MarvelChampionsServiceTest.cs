using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace BoardGameUniverse.MarvelChampions.Tests;

public partial class MarvelChampionsServiceTest
{
    private MarvelChampionsService _service;

    public MarvelChampionsServiceTest()
    {
        var logger = Substitute.For<ILogger<MarvelChampionsService>>();
        _service = new MarvelChampionsService(logger);
    }
}

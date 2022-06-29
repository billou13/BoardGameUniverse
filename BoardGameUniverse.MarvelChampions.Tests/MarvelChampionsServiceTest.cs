using BoardGameUniverse.MarvelChampions;
using BoardGameUniverse.MarvelChampions.Data;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace BoardGameUniverse.MarvelChampions.Tests;

public class MarvelChampionsServiceTest
{
    private MarvelChampionsService _service;
    private Card? _card;

    public MarvelChampionsServiceTest()
    {
        var logger = Substitute.For<ILogger<MarvelChampionsService>>();
        _service = new MarvelChampionsService(logger);
    }

    [Fact]
    public async void GetCardAsyncFailed()
    {
        var test = await WhenGettingCardAsync("00000");

        test
            .AssertCardIsNull();
    }

    [Theory]
    [InlineData("01001a", "hero", "Spider-Man", "18ae183c-de26-4369-8a41-424d58f01631")]
    [InlineData("01027", "upgrade", "Focused Rage", "b37aeafa-227b-4edf-8b00-7326ae1b45db")]
    [InlineData("01054", "event", "Uppercut", "30d53042-f68d-4607-afad-257f33099788")]
    [InlineData("01089", "resource", "Genius", "ec9d5930-031c-493c-920b-32d980409567")]
    public async void GetCardAsyncSucceed(string code, string typeCode, string name, string octgnId)
    {
        var test = await WhenGettingCardAsync(code);

        test
            .AssertCardIsNotNull()
            .AssertCodeIs(code)
            .AssertTypeCodeIs(typeCode)
            .AssertNameIs(name)
            .AssertOctgnIdIs(octgnId);
    }

    public async Task<MarvelChampionsServiceTest> WhenGettingCardAsync(string code)
    {
        _card = await _service.GetCardAsync(code);
        return this;
    }

    public MarvelChampionsServiceTest AssertCardIsNull()
    {
        Assert.Null(_card);
        return this;
    }

    public MarvelChampionsServiceTest AssertCardIsNotNull()
    {
        Assert.NotNull(_card);
        return this;
    }

    public MarvelChampionsServiceTest AssertCodeIs(string expected)
    {
        Assert.Equal(_card?.Code, expected);
        return this;
    }

    public MarvelChampionsServiceTest AssertNameIs(string expected)
    {
        Assert.Equal(_card?.Name, expected);
        return this;
    }

    public MarvelChampionsServiceTest AssertTypeCodeIs(string expected)
    {
        Assert.Equal(_card?.TypeCode, expected);
        return this;
    }

    public MarvelChampionsServiceTest AssertOctgnIdIs(string expected)
    {
        Assert.Equal(_card?.OctgnId, expected);
        return this;
    }
}

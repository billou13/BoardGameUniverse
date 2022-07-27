using BGU.MarvelChampions.CardService.Models;
using System.Threading.Tasks;
using Xunit;

namespace BGU.MarvelChampions.CardService.Tests;

public partial class CardServiceTest
{
    private Card? _card;

    [Fact]
    public async void GetMissingCard()
    {
        var test = await WhenGettingCardAsync("core", "00000");

        test
            .AssertCardIsNull();
    }

    [Theory]
    [InlineData("core", "01001a", "hero", "Spider-Man", "18ae183c-de26-4369-8a41-424d58f01631")]
    [InlineData("core", "01027", "upgrade", "Focused Rage", "b37aeafa-227b-4edf-8b00-7326ae1b45db")]
    [InlineData("core", "01054", "event", "Uppercut", "30d53042-f68d-4607-afad-257f33099788")]
    [InlineData("core", "01089", "resource", "Genius", "ec9d5930-031c-493c-920b-32d980409567")]
    public async void GetExistingCard(string pack, string code, string typeCode, string name, string octgnId)
    {
        var test = await WhenGettingCardAsync(pack, code);

        test
            .AssertCardIsNotNull()
            .AssertCodeIs(code)
            .AssertTypeCodeIs(typeCode)
            .AssertNameIs(name)
            .AssertOctgnIdIs(octgnId);
    }

    public async Task<CardServiceTest> WhenGettingCardAsync(string pack, string code)
    {
        _card = await _service.GetCardAsync(pack, code);
        return this;
    }

    public CardServiceTest AssertCardIsNull()
    {
        Assert.Null(_card);
        return this;
    }

    public CardServiceTest AssertCardIsNotNull()
    {
        Assert.NotNull(_card);
        return this;
    }

    public CardServiceTest AssertCodeIs(string expected)
    {
        Assert.Equal(_card?.Code, expected);
        return this;
    }

    public CardServiceTest AssertNameIs(string expected)
    {
        Assert.Equal(expected, _card?.Name);
        return this;
    }

    public CardServiceTest AssertTypeCodeIs(string expected)
    {
        Assert.Equal(expected, _card?.TypeCode);
        return this;
    }

    public CardServiceTest AssertOctgnIdIs(string expected)
    {
        Assert.Equal(expected, _card?.OctgnId);
        return this;
    }
}

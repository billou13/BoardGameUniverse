using BGU.MarvelChampions.Models;
using System.Threading.Tasks;
using Xunit;

namespace BGU.MarvelChampions.CardService.Tests;

public partial class CardServiceTest
{
    private Card? _card;

    [Fact]
    public async void GetMissing()
    {
        var test = await WhenGettingAsync("00000");

        test
            .AssertCardIsNull();
    }

    [Theory]
    [InlineData("01001a", "hero", "Spider-Man", "18ae183c-de26-4369-8a41-424d58f01631")]
    [InlineData("01027", "upgrade", "Focused Rage", "b37aeafa-227b-4edf-8b00-7326ae1b45db")]
    [InlineData("01054", "event", "Uppercut", "30d53042-f68d-4607-afad-257f33099788")]
    [InlineData("01089", "resource", "Genius", "ec9d5930-031c-493c-920b-32d980409567")]
    [InlineData("09017", null, null, null)]
    [InlineData("09013", "ally", "Clea", "5bdde0e7-90c1-40a4-a973-480ffe6eb02a")]
    [InlineData("22008", "upgrade", "Wide Stance", "9d6baaa7-609c-4bca-b1ea-b672cde4169a")]
    public async void GetExisting(string code, string typeCode, string name, string octgnId)
    {
        var test = await WhenGettingAsync(code);

        test
            .AssertCardIsNotNull()
            .AssertCodeIs(code)
            .AssertTypeCodeIs(typeCode)
            .AssertNameIs(name)
            .AssertOctgnIdIs(octgnId);
    }

    public async Task<CardServiceTest> WhenGettingAsync(string code)
    {
        _card = await _service.GetAsync(code);
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
        Assert.Equal(expected, _card?.Code);
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

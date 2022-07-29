using BGU.MarvelChampions.CardService.Models;
using System.Threading.Tasks;
using Xunit;

namespace BGU.MarvelChampions.CardService.Tests;

public partial class CardServiceTest
{
    private Card[] _cards;

    [Theory]
    [InlineData("core", 101, "01065")]
    public async void GetAllCards(string pack, int count, string existingCode)
    {
        var test = await WhenGettingAllCardsAsync(pack);

        test
            .AssertCardsLengthIs(count)
            .AssertCardsContains(existingCode);
    }

    public async Task<CardServiceTest> WhenGettingAllCardsAsync(string pack)
    {
        _cards = await _service.GetAllCardsAsync(pack);
        return this;
    }

    public CardServiceTest AssertCardsLengthIs(int expected)
    {
        Assert.Equal(expected, _cards.Length);
        return this;
    }

    public CardServiceTest AssertCardsContains(string code)
    {
        Assert.Contains(_cards, c => string.Equals(c.Code, code));
        return this;
    }
}
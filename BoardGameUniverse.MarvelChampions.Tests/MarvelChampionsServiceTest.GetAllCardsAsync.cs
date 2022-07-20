using BoardGameUniverse.MarvelChampions.Data;
using Xunit;

namespace BoardGameUniverse.MarvelChampions.Tests;

public partial class MarvelChampionsServiceTest
{
    private Card[] _cards;

    [Theory]
    [InlineData("core", 101, "01065")]
    public async void GetAllCards(string pack, int count, string existingCode)
    {
        var test = await WhenGettingAllCardsAsync(pack);

        test
            .AssertCardsCountIs(count)
            .AssertCardsContains(existingCode);
    }

    public async Task<MarvelChampionsServiceTest> WhenGettingAllCardsAsync(string pack)
    {
        _cards = await _service.GetAllCardsAsync(pack);
        return this;
    }

    public MarvelChampionsServiceTest AssertCardsCountIs(int expected)
    {
        Assert.Equal(expected, _cards.Count());
        return this;
    }

    public MarvelChampionsServiceTest AssertCardsContains(string code)
    {
        Assert.Contains(_cards, c => string.Equals(c.Code, code));
        return this;
    }
}

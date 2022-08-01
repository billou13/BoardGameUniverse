using BGU.MarvelChampions.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BGU.MarvelChampions.CardService.Tests;

public partial class CardServiceTest
{
    private IEnumerable<Card> _packCards;

    [Theory]
    [InlineData("core", 101, "01065")]
    [InlineData("drs", 35, "09017")]
    public async void GetAllByPack(string pack, int count, string existingCode)
    {
        var test = await WhenGettingAllByPackAsync(pack);

        test
            .AssertPackCardsLengthIs(count)
            .AssertPackCardsContains(existingCode);
    }

    public async Task<CardServiceTest> WhenGettingAllByPackAsync(string pack)
    {
        _packCards = await _service.GetAllByPackAsync(pack);
        return this;
    }

    public CardServiceTest AssertPackCardsLengthIs(int expected)
    {
        Assert.Equal(expected, _packCards.Count());
        return this;
    }

    public CardServiceTest AssertPackCardsContains(string code)
    {
        Assert.Contains(_packCards, c => string.Equals(c.Code, code));
        return this;
    }
}

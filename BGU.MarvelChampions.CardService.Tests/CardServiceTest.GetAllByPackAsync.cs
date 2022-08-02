using BGU.MarvelChampions.CardService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BGU.MarvelChampions.CardService.Tests;

public partial class CardServiceTest
{
    private SortedList<string, CardEntity> _packCards;

    [Theory]
    [InlineData("core", 101, "01065")]
    [InlineData("drs", 35, "09017")]
    public async void GetAllByPack(string pack, int count, string existingCode)
    {
        var test = await WhenGettingAllByPackAsync(pack);

        test
            .AssertPackCardsCountIs(count)
            .AssertPackCardsContains(existingCode);
    }

    public async Task<CardServiceTest> WhenGettingAllByPackAsync(string pack)
    {
        _packCards = await _service.GetAllByPackAsync(pack);
        return this;
    }

    public CardServiceTest AssertPackCardsCountIs(int expected)
    {
        Assert.Equal(expected, _packCards.Count);
        return this;
    }

    public CardServiceTest AssertPackCardsContains(string code)
    {
        Assert.True(_packCards.ContainsKey(code));
        return this;
    }
}

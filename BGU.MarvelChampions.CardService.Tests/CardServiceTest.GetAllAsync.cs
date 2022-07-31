using BGU.MarvelChampions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BGU.MarvelChampions.CardService.Tests;

public partial class CardServiceTest
{
    private SortedList<string, Card> _cards;

    [Theory]
    [InlineData(1995, "01003")]
    public async void GetAll(int count, string existingCode)
    {
        var test = await WhenGettingAllAsync();

        test
            .AssertCardsCountIs(count)
            .AssertCardsContains(existingCode);
    }

    public async Task<CardServiceTest> WhenGettingAllAsync()
    {
        _cards = await _service.GetAllAsync();
        return this;
    }

    public CardServiceTest AssertCardsCountIs(int expected)
    {
        Assert.Equal(expected, _cards.Count);
        return this;
    }

    public CardServiceTest AssertCardsContains(string code)
    {
        Assert.True(_cards.ContainsKey(code));
        return this;
    }
}

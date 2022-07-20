using BoardGameUniverse.MarvelChampions.Data;
using Xunit;

namespace BoardGameUniverse.MarvelChampions.Tests;

public partial class MarvelChampionsServiceTest
{
    private Pack[] _packs;

    [Theory]
    [InlineData(32, "drs")]
    public async void GetAllPacks(int count, string existingCode)
    {
        var test = await WhenGettingAllPacksAsync();

        test
            .AssertPacksCountIs(count)
            .AssertPacksContains(existingCode);
    }

    public async Task<MarvelChampionsServiceTest> WhenGettingAllPacksAsync()
    {
        _packs = await _service.GetAllPacksAsync();
        return this;
    }

    public MarvelChampionsServiceTest AssertPacksCountIs(int expected)
    {
        Assert.Equal(expected, _packs.Count());
        return this;
    }

    public MarvelChampionsServiceTest AssertPacksContains(string code)
    {
        Assert.Contains(_packs, p => string.Equals(p.Code, code));
        return this;
    }
}

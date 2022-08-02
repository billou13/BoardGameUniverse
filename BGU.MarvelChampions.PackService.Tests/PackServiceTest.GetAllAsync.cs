using BGU.MarvelChampions.PackService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BGU.MarvelChampions.PackService.Tests;

public partial class PackServiceTest
{
    private SortedList<string, PackEntity> _packs;

    [Theory]
    [InlineData(32, "drs")]
    public async void GetAll(int count, string existingCode)
    {
        var test = await WhenGettingAllAsync();

        test
            .AssertPacksCountIs(count)
            .AssertPacksContains(existingCode);
    }

    public async Task<PackServiceTest> WhenGettingAllAsync()
    {
        _packs = await _service.GetAllAsync();
        return this;
    }

    public PackServiceTest AssertPacksCountIs(int expected)
    {
        Assert.Equal(expected, _packs.Count);
        return this;
    }

    public PackServiceTest AssertPacksContains(string code)
    {
        Assert.True(_packs.ContainsKey(code));
        return this;
    }
}

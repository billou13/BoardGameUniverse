using BGU.MarvelChampions.PackService.Models;
using System.Threading.Tasks;
using Xunit;

namespace BGU.MarvelChampions.PackService.Tests;

public partial class PackServiceTest
{
    private Pack[] _packs;

    [Theory]
    [InlineData(32, "drs")]
    public async void GetAllPacks(int count, string existingCode)
    {
        var test = await WhenGettingAllPacksAsync();

        test
            .AssertPacksLengthIs(count)
            .AssertPacksContains(existingCode);
    }

    public async Task<PackServiceTest> WhenGettingAllPacksAsync()
    {
        _packs = await _service.GetAllPacksAsync();
        return this;
    }

    public PackServiceTest AssertPacksLengthIs(int expected)
    {
        Assert.Equal(expected, _packs.Length);
        return this;
    }

    public PackServiceTest AssertPacksContains(string code)
    {
        Assert.Contains(_packs, p => string.Equals(p.Code, code));
        return this;
    }
}

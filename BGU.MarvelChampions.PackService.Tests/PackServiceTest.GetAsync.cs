using BGU.MarvelChampions.PackService.Entities;
using System.Threading.Tasks;
using Xunit;

namespace BGU.MarvelChampions.PackService.Tests;

public partial class PackServiceTest
{
    private PackEntity? _pack;

    [Theory]
    [InlineData("drs", "2020-06-06", "Doctor Strange", "08cf8438-8367-43e7-8443-46836f7974e4", "hero", 56)]
    [InlineData("valk", "2021-11-26", "Valkyrie", "cd491a1d-b192-4cd5-8a50-6f9093f271ee", "hero", 56)]
    [InlineData("spiderham", "2022-07-15", "Spider-Ham", "5f189d1d-2352-41cc-b285-a4c687da51de", "hero", 60)]
    public async void GetAsync(string code, string dateRelease, string name, string octgnId, string typeCode, int size)
    {
        var test = await WhenGettingAsync(code);

        test
            .AssertPackDateReleaseIs(dateRelease)
            .AssertPackNameIs(name)
            .AssertPackOctgnIdIs(octgnId)
            .AssertPackTypeCodeIs(typeCode)
            .AssertPackSizeIs(size);
    }

    public async Task<PackServiceTest> WhenGettingAsync(string code)
    {
        _pack = await _service.GetAsync(code);
        return this;
    }

    public PackServiceTest AssertPackDateReleaseIs(string expected)
    {
        Assert.Equal(expected, _pack?.DateRelease);
        return this;
    }

    public PackServiceTest AssertPackNameIs(string expected)
    {
        Assert.Equal(expected, _pack?.Name);
        return this;
    }

    public PackServiceTest AssertPackOctgnIdIs(string expected)
    {
        Assert.Equal(expected, _pack?.OctgnId);
        return this;
    }

    public PackServiceTest AssertPackTypeCodeIs(string expected)
    {
        Assert.Equal(expected, _pack?.PackTypeCode);
        return this;
    }

    public PackServiceTest AssertPackSizeIs(int expected)
    {
        Assert.Equal(expected, _pack?.Size);
        return this;
    }
}

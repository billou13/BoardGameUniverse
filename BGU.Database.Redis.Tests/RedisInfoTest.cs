using Xunit;

namespace BGU.Database.Redis.Tests;

public partial class RedisInfoTest
{
    private RedisInfo? _redisInfo;

    [Theory]
    [InlineData("127.0.0.1", 5432, "myPassword", "127.0.0.1:5432,password=myPassword")]
    [InlineData("8.8.8.8", 5632, null, "8.8.8.8:5632")]
    public void Create(string url, int port, string password, string configurationString)
    {
        WhenCreating(url, port, password)
            .AssertUrlIs(url)
            .AssertPortIs(port)
            .AssertPasswordIs(password)
            .AssertConfigurationStringIs(configurationString);
    }

    [Theory]
    [InlineData("redis://:myPassword@127.0.0.1:5432", "127.0.0.1", 5432, "myPassword", "127.0.0.1:5432,password=myPassword")]
    public void Parse(string connectionUrl, string url, int port, string password, string configurationString)
    {
        WhenParsing(connectionUrl)
            .AssertUrlIs(url)
            .AssertPortIs(port)
            .AssertPasswordIs(password)
            .AssertConfigurationStringIs(configurationString);
    }

    public RedisInfoTest WhenCreating(string url, int port, string password)
    {
        _redisInfo = RedisInfo.Create(url, port, password);
        return this;
    }

    public RedisInfoTest WhenParsing(string connectionUrl)
    {
        _redisInfo = RedisInfo.Parse(connectionUrl);
        return this;
    }

    public RedisInfoTest AssertUrlIs(string expected)
    {
        Assert.Equal(expected, _redisInfo?.Url);
        return this;
    }

    public RedisInfoTest AssertPortIs(int expected)
    {
        Assert.Equal(expected, _redisInfo?.Port);
        return this;
    }

    public RedisInfoTest AssertPasswordIs(string expected)
    {
        Assert.Equal(expected, _redisInfo?.Password);
        return this;
    }

    public RedisInfoTest AssertConfigurationStringIs(string expected)
    {
        Assert.Equal(expected, _redisInfo?.ConfigurationString);
        return this;
    }
}

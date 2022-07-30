using BGU.Database.Postgres;
using Xunit;

namespace BGU.Database.Postgres.Tests;

public partial class PostgresInfoTest
{
    private PostgresInfo? _postgresInfo;

    [Theory]
    [InlineData("postgres://myUsername:myPassword@127.0.0.1:5432/myDataBase", "Server=127.0.0.1;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword;")]
    public void Parse(string connectionUrl, string connectionString)
    {
        WhenParsing(connectionUrl)
            .AssertConnectionStringIs(connectionString);
    }

    public PostgresInfoTest WhenParsing(string connectionUrl)
    {
        _postgresInfo = PostgresInfo.Parse(connectionUrl);
        return this;
    }

    public PostgresInfoTest AssertConnectionStringIs(string expected)
    {
        Assert.Equal(_postgresInfo?.ConnectionString, expected);
        return this;
    }
}

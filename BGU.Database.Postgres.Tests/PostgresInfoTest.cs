using Xunit;

namespace BGU.Database.Postgres.Tests;

public partial class PostgresInfoTest
{
    private PostgresInfo? _postgresInfo;

    [Theory]
    [InlineData("127.0.0.1", 5432, "myDataBase", "myUsername", "myPassword", "Server=127.0.0.1;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword;")]
    public void Create(string server, int port, string database, string userId, string password, string connectionString)
    {
        WhenCreating(server, port, database, userId, password)
            .AssertServerIs(server)
            .AssertPortIs(port)
            .AssertDatabaseIs(database)
            .AssertUserIdIs(userId)
            .AssertPasswordIs(password)
            .AssertConnectionStringIs(connectionString);
    }

    [Theory]
    [InlineData("postgres://myUsername:myPassword@127.0.0.1:5432/myDataBase", "127.0.0.1", 5432, "myDataBase", "myUsername", "myPassword", "Server=127.0.0.1;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword;")]
    public void Parse(string connectionUrl, string server, int port, string database, string userId, string password, string connectionString)
    {
        WhenParsing(connectionUrl)
            .AssertServerIs(server)
            .AssertPortIs(port)
            .AssertDatabaseIs(database)
            .AssertUserIdIs(userId)
            .AssertPasswordIs(password)
            .AssertConnectionStringIs(connectionString);
    }

    public PostgresInfoTest WhenCreating(string server, int port, string database, string userId, string password)
    {
        _postgresInfo = PostgresInfo.Create(server, port, database, userId, password);
        return this;
    }

    public PostgresInfoTest WhenParsing(string connectionUrl)
    {
        _postgresInfo = PostgresInfo.Parse(connectionUrl);
        return this;
    }

    public PostgresInfoTest AssertServerIs(string expected)
    {
        Assert.Equal(expected, _postgresInfo?.Server);
        return this;
    }

    public PostgresInfoTest AssertPortIs(int expected)
    {
        Assert.Equal(expected, _postgresInfo?.Port);
        return this;
    }

    public PostgresInfoTest AssertDatabaseIs(string expected)
    {
        Assert.Equal(expected, _postgresInfo?.Database);
        return this;
    }

    public PostgresInfoTest AssertUserIdIs(string expected)
    {
        Assert.Equal(expected, _postgresInfo?.UserId);
        return this;
    }

    public PostgresInfoTest AssertPasswordIs(string expected)
    {
        Assert.Equal(expected, _postgresInfo?.Password);
        return this;
    }

    public PostgresInfoTest AssertConnectionStringIs(string expected)
    {
        Assert.Equal(expected, _postgresInfo?.ConnectionString);
        return this;
    }
}

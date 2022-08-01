using System;

namespace BGU.Database.Postgres;

public class PostgresInfo
{
    private PostgresInfo()
    {
    }

    public string? Server { get; set; }
    public int? Port { get; set; }
    public string? Database { get; set; }
    public string? UserId { get; set; }
    public string? Password { get; set; }

    public string ConnectionString
    {
        get { return $"Server={Server};Port={Port};Database={Database};User Id={UserId};Password={Password};"; }
    }

    public static PostgresInfo Create(string server, int port, string database, string userId, string password)
    {
        return new PostgresInfo
        {
            Server = server,
            Port = port,
            Database = database,
            UserId = userId,
            Password = password
        };
    }

    public static PostgresInfo Parse(string connectionUrl)
    {
        var databaseUri = new Uri(connectionUrl);
        string database = databaseUri.LocalPath.TrimStart('/');
        string[] userInfo = databaseUri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);

        return PostgresInfo.Create(databaseUri.Host, databaseUri.Port, database, userInfo[0], userInfo[1]);
    }
}

using System;

namespace BGU.Database.Redis;

public class RedisInfo
{
    private RedisInfo()
    {
    }

    public string? Url { get; set; }
    public int? Port { get; set; }
    public string? Password { get; set; }

    public string ConfigurationString
    {
        get { return Password != null ? $"{Url}:{Port},password={Password}" : $"{Url}:{Port}"; }
    }

    public static RedisInfo Create(string url, int port, string password)
    {
        return new RedisInfo
        {
            Url = url,
            Port = port,
            Password = password
        };
    }

    public static RedisInfo Parse(string connectionUrl)
    {
        var databaseUri = new Uri(connectionUrl);
        string[] userInfo = databaseUri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);

        return RedisInfo.Create(databaseUri.Host, databaseUri.Port, userInfo[0]);
    }
}

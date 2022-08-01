using BGU.Database.Redis.Interfaces;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace BGU.Database.Redis;

// https://github.com/StackExchange/StackExchange.Redis/blob/9fb222e86fe596558e07f8ecfdc9a901a4893fb4/src/StackExchange.Redis/Interfaces/IDatabase.cs
// https://stackexchange.github.io/StackExchange.Redis/Basics
public class RedisStringDal : RedisDal, IRedisStringDal
{
    public RedisStringDal(IConnectionMultiplexer connectionMultiplexer)
        : base(connectionMultiplexer)
    {
    }

    public async Task<bool> SetAsync(string key, string value)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.StringSetAsync(key, value);
    }

    public async Task<string?> GetAsync(string key)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.StringGetAsync(key);
    }

    public async Task<string?> GetAndDeleteAsync(string key)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.StringGetDeleteAsync(key);
    }
}

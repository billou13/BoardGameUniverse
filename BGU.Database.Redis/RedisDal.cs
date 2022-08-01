using BGU.Database.Redis.Interfaces;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGU.Database.Redis;

// https://github.com/StackExchange/StackExchange.Redis/blob/9fb222e86fe596558e07f8ecfdc9a901a4893fb4/src/StackExchange.Redis/Interfaces/IDatabase.cs
// https://stackexchange.github.io/StackExchange.Redis/Basics
public abstract class RedisDal : IRedisDal
{
    protected readonly IConnectionMultiplexer _connectionMultiplexer;

    public RedisDal(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<bool> KeyDeleteAsync(string key)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.KeyDeleteAsync(key);
    }
}

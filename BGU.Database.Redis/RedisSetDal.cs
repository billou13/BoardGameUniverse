using BGU.Database.Redis.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGU.Database.Redis;

public class RedisSetDal : RedisDal, IRedisSetDal
{
    public RedisSetDal(IConnectionMultiplexer connectionMultiplexer)
        : base(connectionMultiplexer)
    {
    }

    public async Task<bool> AddAsync(string key, string value)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.SetAddAsync(key, value);
    }

    public async Task<long> LengthAsync(string key)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.SetLengthAsync(key);
    }

    public async Task<bool> ContainsAsync(string key, string value)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.SetContainsAsync(key, value);
    }

    public async Task<IEnumerable<string>> MembersAsync(string key)
    {
        var db = _connectionMultiplexer.GetDatabase();
        var values = await db.SetMembersAsync(key);
        return values.Select(value => Convert.ToString(value));
    }

    public async Task<bool> MoveAsync(string sourceKey, string destinationKey, string value)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.SetMoveAsync(sourceKey, destinationKey, value);
    }

    public async Task<string?> PopAsync(string key)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.SetPopAsync(key);
    }

    public async Task<string?> RandomMemberAsync(string key)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.SetRandomMemberAsync(key);
    }

    public async Task<bool> RemoveAsync(string key, string value)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.SetRemoveAsync(key, value);
    }

    public async Task<IEnumerable<string>> CombineAsync(SetOperation operation, string firstKey, string secondKey)
    {
        var db = _connectionMultiplexer.GetDatabase();
        var values = await db.SetCombineAsync(operation, firstKey, secondKey);
        return values.Cast<string>();
    }

    public async Task<long> CombineAndStoreAsync(SetOperation operation, string destinationKey, string firstKey, string secondKey)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.SetCombineAndStoreAsync(operation, destinationKey, firstKey, secondKey);
    }
}

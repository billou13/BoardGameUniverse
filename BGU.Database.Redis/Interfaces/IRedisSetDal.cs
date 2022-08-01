using StackExchange.Redis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.Database.Redis.Interfaces;

public interface IRedisSetDal : IRedisDal
{
    Task<bool> AddAsync(string key, string value);

    Task<long> LengthAsync(string key);

    Task<bool> ContainsAsync(string key, string value);

    Task<IEnumerable<string>> MembersAsync(string key);

    Task<bool> MoveAsync(string sourceKey, string destinationKey, string value);

    Task<string?> PopAsync(string key);

    Task<string?> RandomMemberAsync(string key);

    Task<bool> RemoveAsync(string key, string value);

    Task<IEnumerable<string>> CombineAsync(SetOperation operation, string firstKey, string secondKey);

    Task<long> CombineAndStoreAsync(SetOperation operation, string destinationKey, string firstKey, string secondKey);
}

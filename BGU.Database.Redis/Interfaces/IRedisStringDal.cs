using System.Threading.Tasks;

namespace BGU.Database.Redis.Interfaces;

public interface IRedisStringDal : IRedisDal
{
    Task<bool> SetAsync(string key, string value);

    Task<string?> GetAsync(string key);

    Task<string?> GetAndDeleteAsync(string key);
}

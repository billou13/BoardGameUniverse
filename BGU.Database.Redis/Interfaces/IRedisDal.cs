using System.Threading.Tasks;

namespace BGU.Database.Redis.Interfaces;

public interface IRedisDal
{
    Task<bool> StringSetAsync(string key, string value);

    Task<string?> StringGetAsync(string key);
}

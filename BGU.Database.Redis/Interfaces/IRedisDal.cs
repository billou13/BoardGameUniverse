using System.Threading.Tasks;

namespace BGU.Database.Redis.Interfaces;

public interface IRedisDal
{
    Task<bool> KeyDeleteAsync(string key);
}

using BGU.MarvelChampions.Models;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.Services.Interfaces;

public interface IPackApiGatewayService
{
    Task<Pack?> GetAsync(string code);
}

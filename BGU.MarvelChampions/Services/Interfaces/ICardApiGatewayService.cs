using BGU.MarvelChampions.Models;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.Services.Interfaces;

public interface ICardApiGatewayService
{
    Task<Card?> GetAsync(string code);
}

using BGU.MarvelChampions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.Services.Interfaces;

public interface ICardApiGatewayService
{
    Task<Card?> GetAsync(string code);

    Task<IEnumerable<Card>> GetAllByCodes(IEnumerable<string> codes);
}

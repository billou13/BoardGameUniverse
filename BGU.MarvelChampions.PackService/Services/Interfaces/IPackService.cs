using BGU.MarvelChampions.PackService.Models;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.PackService.Services.Interfaces;

public interface IPackService
{
    Task<Pack[]> GetAllPacksAsync();
}

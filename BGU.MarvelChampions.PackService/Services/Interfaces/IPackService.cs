using BGU.MarvelChampions.PackService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.PackService.Services.Interfaces;

public interface IPackService
{
    Task<SortedList<string, PackEntity>> GetAllAsync();

    Task<PackEntity?> GetAsync(string code);
}

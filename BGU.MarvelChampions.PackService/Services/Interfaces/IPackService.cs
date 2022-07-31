using BGU.MarvelChampions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.PackService.Services.Interfaces;

public interface IPackService
{
    Task<SortedList<string, Pack>> GetAllAsync();

    Task<Pack?> GetAsync(string code);
}

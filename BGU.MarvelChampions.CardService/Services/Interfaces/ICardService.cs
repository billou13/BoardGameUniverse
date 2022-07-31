using BGU.MarvelChampions.CardService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.CardService.Services.Interfaces;

public interface ICardService
{
    Task<IEnumerable<Card>> GetAllByPackAsync(string pack);

    Task<SortedList<string, Card>> GetAllAsync();

    Task<Card?> GetAsync(string code);
}

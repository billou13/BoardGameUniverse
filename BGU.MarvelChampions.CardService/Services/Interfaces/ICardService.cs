using BGU.MarvelChampions.CardService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.CardService.Services.Interfaces;

public interface ICardService
{
    Task<SortedList<string, CardEntity>> GetAllByPackAsync(string pack);

    Task<SortedList<string, CardEntity>> GetAllAsync();

    Task<CardEntity?> GetAsync(string code);

    Task<CardEntity?> GetPreviousAsync(string code);

    Task<CardEntity?> GetNextAsync(string code);
}

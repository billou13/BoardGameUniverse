using BGU.MarvelChampions.CardService.Models;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.CardService.Services.Interfaces;

public interface ICardService
{
    Task<Card[]> GetAllCardsAsync(string pack);

    Task<Card?> GetCardAsync(string pack, string code);
}

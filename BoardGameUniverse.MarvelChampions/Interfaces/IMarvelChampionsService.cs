using BoardGameUniverse.MarvelChampions.Data;

namespace BoardGameUniverse.MarvelChampions.Interfaces;

public interface IMarvelChampionsService
{
    Task<Pack[]> GetAllPacksAsync();

    Task<Card[]> GetAllCardsAsync(string pack);

    Task<Card?> GetCardAsync(string pack, string code);
}

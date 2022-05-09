using BoardGameUniverse.MarvelChampions.Data;

namespace BoardGameUniverse.MarvelChampions.Interfaces;

public interface IMarvelChampionsService
{
    Task<Card?> GetCardAsync(string code);
}

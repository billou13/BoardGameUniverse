using BGU.MarvelChampions.DeckService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.DeckService.Services.Interfaces;

public interface IDeckService
{
    Task<IEnumerable<Deck>> GetAllDecksAsync();

    Task<Guid?> CreateDeckAsync(Deck deck);

    Task<Deck?> GetDeckAsync(Guid guid);
}

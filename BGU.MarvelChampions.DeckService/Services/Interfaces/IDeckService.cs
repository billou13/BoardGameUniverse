using BGU.MarvelChampions.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.DeckService.Services.Interfaces;

public interface IDeckService
{
    Task<IEnumerable<Deck>> GetAllAsync();

    Task<Deck?> GetAsync(Guid guid);

    Task<Guid?> CreateAsync(Deck deck);
}

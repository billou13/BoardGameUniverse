using BGU.Database.Postgres.Entities;
using BGU.MarvelChampions.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.DeckService.Services.Interfaces;

public interface IDeckService
{
    Task<IEnumerable<DeckEntity>> GetAllAsync();

    Task<DeckEntity?> GetAsync(Guid guid);

    Task<Guid?> CreateAsync(DeckEntity deck);

    Task<bool> AddCard(Guid deckGuid, string cardCode);

    Task<bool> RemoveCard(Guid deckGuid, string cardCode);

    Task<IEnumerable<Card>> GetAllCards(Guid deckGuid);
}

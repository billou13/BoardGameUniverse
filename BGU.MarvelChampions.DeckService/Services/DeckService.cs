using BGU.Database.Postgres;
using BGU.Database.Postgres.Entities;
using BGU.Database.Redis.Interfaces;
using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.DeckService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.DeckService.Services;

public class DeckService : IDeckService
{
    private readonly ILogger<DeckService> _logger;
    private readonly DeckDbContext _dbContext;
    private readonly IRedisSetDal _redisSetDal;

    public DeckService(ILogger<DeckService> logger, DeckDbContext dbContext, IRedisSetDal redisSetDal)
    {
        _logger = logger;
        _dbContext = dbContext;
        _redisSetDal = redisSetDal;
    }

    public async Task<IEnumerable<Deck>> GetAllAsync()
    {
        var entities = await _dbContext.Decks.ToListAsync();
        return entities.Select(e => new Deck
        {
            Guid = e.Guid,
            Name = e.Name,
            CreateDate = e.CreateDate,
            UpdateDate = e.UpdateDate
        });
    }

    public async Task<Deck?> GetAsync(Guid guid)
    {
        var entity = await _dbContext.Decks.FindAsync(guid);
        if (entity == null)
        {
            return null;
        }
        
        return new Deck
        {
            Guid = entity.Guid,
            Name = entity.Name,
            CreateDate = entity.CreateDate,
            UpdateDate = entity.UpdateDate
        };
    }

    public async Task<Guid?> CreateAsync(Deck deck)
    {
        var newEntry = await _dbContext.Decks.AddAsync(
            new DeckEntity
            {
                Guid = deck.Guid,
                Name = deck.Name,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            }
        );

        await _dbContext.SaveChangesAsync();
        return newEntry.Entity.Guid;
    }

    public async Task<bool> AddCard(DeckCard item)
    {
        return await _redisSetDal.AddAsync(GetRedisKey(item.DeckGuid), item.CardCode);
    }

    public async Task<bool> RemoveCard(DeckCard item)
    {
        return await _redisSetDal.RemoveAsync(GetRedisKey(item.DeckGuid), item.CardCode);
    }

    public async Task<IEnumerable<string>> GetAllCards(Guid deckGuid)
    {
        return await _redisSetDal.MembersAsync(GetRedisKey(deckGuid));
    }

    private string GetRedisKey(Guid deckGuid)
    {
        return $"deck:{deckGuid}";
    }
}

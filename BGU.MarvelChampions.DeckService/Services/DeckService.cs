using BGU.Database.Postgres;
using BGU.Database.Postgres.Entities;
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

    public DeckService(ILogger<DeckService> logger, DeckDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
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
}

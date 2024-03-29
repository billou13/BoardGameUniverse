using BGU.Database.Postgres;
using BGU.Database.Postgres.Entities;
using BGU.Database.Redis.Interfaces;
using BGU.MarvelChampions.DeckService.Services.Interfaces;
using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.Services.Interfaces;
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
    private readonly ICardApiGatewayService _cardApiGatewayService;

    public DeckService(ILogger<DeckService> logger, DeckDbContext dbContext, IRedisSetDal redisSetDal, ICardApiGatewayService cardApiGatewayService)
    {
        _logger = logger;
        _dbContext = dbContext;
        _redisSetDal = redisSetDal;
        _cardApiGatewayService = cardApiGatewayService;
    }

    public async Task<IEnumerable<DeckEntity>> GetAllAsync()
    {
        return await _dbContext.Decks.ToListAsync();
    }

    public async Task<DeckEntity?> GetAsync(Guid guid)
    {
        return await _dbContext.Decks.FindAsync(guid);
    }

    public async Task<Guid?> CreateAsync(DeckEntity deck)
    {
        var newEntry = await _dbContext.Decks.AddAsync(deck);
        await _dbContext.SaveChangesAsync();
        return newEntry.Entity.Guid;
    }

    public async Task<bool> AddCard(Guid deckGuid, string cardCode)
    {
        return await _redisSetDal.AddAsync(GetRedisKey(deckGuid), cardCode);
    }

    public async Task<bool> RemoveCard(Guid deckGuid, string cardCode)
    {
        return await _redisSetDal.RemoveAsync(GetRedisKey(deckGuid), cardCode);
    }

    public async Task<IEnumerable<Card>> GetAllCards(Guid deckGuid)
    {
        var codes = await _redisSetDal.MembersAsync(GetRedisKey(deckGuid));
        return await _cardApiGatewayService.GetAllByCodes(codes);
    }

    private string GetRedisKey(Guid deckGuid)
    {
        return $"deck:{deckGuid}";
    }
}

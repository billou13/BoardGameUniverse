using AutoMapper;
using BGU.MarvelChampions.CardService.Entities;
using BGU.MarvelChampions.CardService.Extensions;
using BGU.MarvelChampions.Models;
using BGU.MarvelChampions.CardService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.CardService.Controllers;

public abstract class CardControllerBase : ControllerBase
{
    protected readonly ICardService _service;
    protected readonly IMapper _mapper;

    public CardControllerBase(ICardService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    protected async Task<Card?> EnrichData(CardEntity? card)
    {
        if (card == null)
        {
            return null;
        }

        if (card?.DuplicateOf != null)
        {
            var originalCard = await _service.GetAsync(card.DuplicateOf);
            card.MergeWith(originalCard);
        }

        return _mapper.Map<Card>(card);
    }

    protected async Task<IEnumerable<Card>> EnrichData(IEnumerable<CardEntity> cards)
    {
        if (cards == null)
        {
            return null;
        }

        var items = new List<Card>();
        foreach (var card in cards)
        {
            var item = await EnrichData(card);
            if (item == null)
            {
                continue;
            }

            items.Add(item);
        }

        return items;
    }

    protected async Task<IEnumerable<Card>> EnrichData(SortedList<string, CardEntity> cards)
    {
        if (cards == null)
        {
            return null;
        }

        return await EnrichData(cards.Values);
    }
}

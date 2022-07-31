using BGU.MarvelChampions.CardService.Extensions;
using BGU.MarvelChampions.CardService.Models;
using BGU.MarvelChampions.CardService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.CardService.Controllers;

public abstract class CardControllerBase : ControllerBase
{
    protected readonly ICardService _service;

    public CardControllerBase(ICardService service)
    {
        _service = service;
    }

    protected async Task EnrichWithDuplicate(Card? card)
    {
        if (card?.DuplicateOf == null)
        {
            return;
        }

        var baseCard = await _service.GetAsync(card.DuplicateOf);
        if (baseCard == null)
        {
            return;
        }

        card.MergeWith(baseCard);
    }

    protected async Task EnrichWithDuplicate(IEnumerable<Card> cards)
    {
        foreach (var card in cards)
        {
            await EnrichWithDuplicate(card);
        }
    }
}

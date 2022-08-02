using BGU.MarvelChampions.CardService.Entities;

namespace BGU.MarvelChampions.CardService.Extensions;

public static class CardEntityExtensions
{
    public static void MergeWith(this CardEntity cardX, CardEntity cardY)
    {
        cardX.Attack = cardX.Attack ?? cardY.Attack;
        cardX.BackLink = cardX.BackLink ?? cardY.BackLink;
        cardX.Code = cardX.Code ?? cardY.Code;
        cardX.Cost = cardX.Cost ?? cardY.Cost;
        cardX.DeckLimit = cardX.DeckLimit ?? cardY.DeckLimit;
        cardX.Defense = cardX.Defense ?? cardY.Defense;
        cardX.DuplicateOf = cardX.DuplicateOf ?? cardY.DuplicateOf;
        cardX.FactionCode = cardX.FactionCode ?? cardY.FactionCode;
        cardX.Flavor = cardX.Flavor ?? cardY.Flavor;
        cardX.HandSize = cardX.HandSize ?? cardY.HandSize;
        cardX.Health = cardX.Health ?? cardY.Health;
        cardX.Hidden = cardX.Hidden ?? cardY.Hidden;
        cardX.IsUnique = cardX.IsUnique ?? cardY.IsUnique;
        cardX.Name = cardX.Name ?? cardY.Name;
        cardX.OctgnId = cardX.OctgnId ?? cardY.OctgnId;
        cardX.PackCode = cardX.PackCode ?? cardY.PackCode;
        cardX.Position = cardX.Position ?? cardY.Position;
        cardX.Quantity = cardX.Quantity ?? cardY.Quantity;
        cardX.ResourceEnergy = cardX.ResourceEnergy ?? cardY.ResourceEnergy;
        cardX.ResourceMental = cardX.ResourceMental ?? cardY.ResourceMental;
        cardX.ResourcePhysical = cardX.ResourcePhysical ?? cardY.ResourcePhysical;
        cardX.ResourceWild = cardX.ResourceWild ?? cardY.ResourceWild;
        cardX.SetCode = cardX.SetCode ?? cardY.SetCode;
        cardX.Text = cardX.Text ?? cardY.Text;
        cardX.Thwart = cardX.Thwart ?? cardY.Thwart;
        cardX.Traits = cardX.Traits ?? cardY.Traits;
        cardX.TypeCode = cardX.TypeCode ?? cardY.TypeCode;
    }
}

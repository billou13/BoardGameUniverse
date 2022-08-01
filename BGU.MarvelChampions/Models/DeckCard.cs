using System;
using System.Text.Json.Serialization;

namespace BGU.MarvelChampions.Models;

public class DeckCard
{
    [JsonPropertyName("deckGuid")]
    public Guid DeckGuid { get; set; }

    [JsonPropertyName("cardCode")]
    public string CardCode { get; set; }
}

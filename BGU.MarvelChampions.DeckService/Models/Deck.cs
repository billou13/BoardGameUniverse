using System;
using System.Text.Json.Serialization;

namespace BGU.MarvelChampions.DeckService.Models;

public class Deck
{
    [JsonPropertyName("guid")]
    public Guid? Guid { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("createDate")]
    public DateTime? CreateDate { get; set; }
}

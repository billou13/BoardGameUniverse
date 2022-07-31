using System;
using System.Text.Json.Serialization;

namespace BGU.MarvelChampions.Models;

public class Deck
{
    [JsonPropertyName("guid")]
    public Guid? Guid { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("createDate")]
    public DateTime? CreateDate { get; set; }

    [JsonPropertyName("updateDate")]
    public DateTime? UpdateDate { get; set; }
}

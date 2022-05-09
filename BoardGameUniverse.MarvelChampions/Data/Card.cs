using System.Text.Json.Serialization;

namespace BoardGameUniverse.MarvelChampions.Data;

public class Card
{
    [JsonPropertyName("type_code")]
    public string? TypeCode { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("octgn_id")]
    public string? OctgnId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }
}
using BGU.MarvelChampions.JsonConverters;
using System.Text.Json.Serialization;

namespace BGU.MarvelChampions.Models;

public class Card
{
    [JsonPropertyName("attack"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Attack { get; set; }

    [JsonPropertyName("backLink"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BackLink { get; set; }

    [JsonPropertyName("code"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Code { get; set; }

    [JsonPropertyName("cost"), JsonConverter(typeof(StringNumberJsonConverter)), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Cost { get; set; }

    [JsonPropertyName("deckLimit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? DeckLimit { get; set; }

    [JsonPropertyName("defense"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Defense { get; set; }

    [JsonPropertyName("duplicateOf"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DuplicateOf { get; set; }

    [JsonPropertyName("factionCode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FactionCode { get; set; }

    [JsonPropertyName("flavor"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Flavor { get; set; }

    [JsonPropertyName("handSize"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? HandSize { get; set; }

    [JsonPropertyName("health"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Health { get; set; }

    [JsonPropertyName("hidden"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Hidden { get; set; }

    [JsonPropertyName("isUnique"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsUnique { get; set; }

    [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    [JsonPropertyName("octgnId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OctgnId { get; set; }

    [JsonPropertyName("packCode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PackCode { get; set; }

    [JsonPropertyName("position"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Position { get; set; }

    [JsonPropertyName("quantity"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Quantity { get; set; }

    [JsonPropertyName("resourceEnergy"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ResourceEnergy { get; set; }

    [JsonPropertyName("resourceMental"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ResourceMental { get; set; }

    [JsonPropertyName("resourcePhysical"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ResourcePhysical { get; set; }

    [JsonPropertyName("resourceWild"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ResourceWild { get; set; }

    [JsonPropertyName("setCode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SetCode { get; set; }

    [JsonPropertyName("text"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }

    [JsonPropertyName("thwart"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Thwart { get; set; }

    [JsonPropertyName("traits"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Traits { get; set; }

    [JsonPropertyName("typeCode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TypeCode { get; set; }
}

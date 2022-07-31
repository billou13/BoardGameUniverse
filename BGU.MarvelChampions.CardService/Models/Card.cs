using BGU.MarvelChampions.CardService.JsonConverters;
using System.Text.Json.Serialization;

namespace BGU.MarvelChampions.CardService.Models;

public class Card
{
    [JsonPropertyName("attack"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Attack { get; set; }

    [JsonPropertyName("back_link"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BackLink { get; set; }

    [JsonPropertyName("code"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Code { get; set; }

    [JsonPropertyName("cost"), JsonConverter(typeof(StringNumberJsonConverter)), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Cost { get; set; }

    [JsonPropertyName("deck_limit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? DeckLimit { get; set; }

    [JsonPropertyName("defense"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Defense { get; set; }

    [JsonPropertyName("duplicate_of"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DuplicateOf { get; set; }

    [JsonPropertyName("faction_code"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FactionCode { get; set; }

    [JsonPropertyName("flavor"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Flavor { get; set; }

    [JsonPropertyName("hand_size"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? HandSize { get; set; }

    [JsonPropertyName("health"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Health { get; set; }

    [JsonPropertyName("hidden"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Hidden { get; set; }

    [JsonPropertyName("is_unique"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsUnique { get; set; }

    [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    [JsonPropertyName("octgn_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OctgnId { get; set; }

    [JsonPropertyName("pack_code"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PackCode { get; set; }

    [JsonPropertyName("position"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Position { get; set; }

    [JsonPropertyName("quantity"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Quantity { get; set; }

    [JsonPropertyName("resource_energy"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ResourceEnergy { get; set; }

    [JsonPropertyName("resource_mental"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ResourceMental { get; set; }

    [JsonPropertyName("resource_physical"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ResourcePhysical { get; set; }

    [JsonPropertyName("resource_wild"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ResourceWild { get; set; }

    [JsonPropertyName("set_code"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SetCode { get; set; }

    [JsonPropertyName("text"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }

    [JsonPropertyName("thwart"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Thwart { get; set; }

    [JsonPropertyName("traits"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Traits { get; set; }

    [JsonPropertyName("type_code"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TypeCode { get; set; }
}

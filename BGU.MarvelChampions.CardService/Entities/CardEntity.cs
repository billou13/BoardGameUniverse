using BGU.MarvelChampions.JsonConverters;
using System.Text.Json.Serialization;

namespace BGU.MarvelChampions.CardService.Entities;

public class CardEntity
{
    [JsonPropertyName("attack")]
    public int? Attack { get; set; }

    [JsonPropertyName("back_link")]
    public string? BackLink { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("cost"), JsonConverter(typeof(StringNumberJsonConverter))]
    public string? Cost { get; set; }

    [JsonPropertyName("deck_limit")]
    public int? DeckLimit { get; set; }

    [JsonPropertyName("defense")]
    public int? Defense { get; set; }

    [JsonPropertyName("duplicate_of")]
    public string? DuplicateOf { get; set; }

    [JsonPropertyName("faction_code")]
    public string? FactionCode { get; set; }

    [JsonPropertyName("flavor")]
    public string? Flavor { get; set; }

    [JsonPropertyName("hand_size")]
    public int? HandSize { get; set; }

    [JsonPropertyName("health")]
    public int? Health { get; set; }

    [JsonPropertyName("hidden")]
    public bool? Hidden { get; set; }

    [JsonPropertyName("is_unique")]
    public bool? IsUnique { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("octgn_id")]
    public string? OctgnId { get; set; }

    [JsonPropertyName("pack_code")]
    public string? PackCode { get; set; }

    [JsonPropertyName("position")]
    public int? Position { get; set; }

    [JsonPropertyName("quantity")]
    public int? Quantity { get; set; }

    [JsonPropertyName("resource_energy")]
    public int? ResourceEnergy { get; set; }

    [JsonPropertyName("resource_mental")]
    public int? ResourceMental { get; set; }

    [JsonPropertyName("resource_physical")]
    public int? ResourcePhysical { get; set; }

    [JsonPropertyName("resource_wild")]
    public int? ResourceWild { get; set; }

    [JsonPropertyName("set_code")]
    public string? SetCode { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("thwart")]
    public int? Thwart { get; set; }

    [JsonPropertyName("traits")]
    public string? Traits { get; set; }

    [JsonPropertyName("type_code")]
    public string? TypeCode { get; set; }
}

using System.Text.Json.Serialization;

namespace BGU.MarvelChampions.Models;

public class Pack
{
    [JsonPropertyName("cgdbId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CgdbId { get; set; }

    [JsonPropertyName("code"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Code { get; set; }

    [JsonPropertyName("dateRelease"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DateRelease { get; set; }

    [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    [JsonPropertyName("octgnId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OctgnId { get; set; }

    [JsonPropertyName("packTypeCode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PackTypeCode { get; set; }

    [JsonPropertyName("position"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Position { get; set; }

    [JsonPropertyName("size"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Size { get; set; }
}

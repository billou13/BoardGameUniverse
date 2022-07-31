using System.Text.Json.Serialization;

namespace BGU.MarvelChampions.PackService.Models;

public class Pack
{
    [JsonPropertyName("cgdb_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CgdbId { get; set; }

    [JsonPropertyName("code"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Code { get; set; }

    [JsonPropertyName("date_release"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DateRelease { get; set; }

    [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    [JsonPropertyName("octgn_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OctgnId { get; set; }

    [JsonPropertyName("pack_type_code"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PackTypeCode { get; set; }

    [JsonPropertyName("position"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Position { get; set; }

    [JsonPropertyName("size"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Size { get; set; }
}

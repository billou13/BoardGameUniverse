using System.Text.Json.Serialization;

namespace BGU.MarvelChampions.PackService.Entities;

public class PackEntity
{
    [JsonPropertyName("cgdb_id")]
    public int? CgdbId { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("date_release")]
    public string? DateRelease { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("octgn_id")]
    public string? OctgnId { get; set; }

    [JsonPropertyName("pack_type_code")]
    public string? PackTypeCode { get; set; }

    [JsonPropertyName("position")]
    public int? Position { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }
}

using System.Text.Json.Serialization;

namespace NekoSpace.SlstGen.Models;

public class SlstLocalizationInfo
{
    [JsonPropertyName("en")]
    public string En { get; set; } = string.Empty;

    [JsonPropertyName("ja")]
    public string? Ja { get; set; } = null;

    [JsonPropertyName("ko")]
    public string? Ko { get; set; } = null;

    [JsonPropertyName("zh-Hans")]
    public string? ZhHans { get; set; } = null;

    [JsonPropertyName("zh-Hant")]
    public string? ZhHant { get; set; } = null;
}
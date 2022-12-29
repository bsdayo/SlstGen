using System.Text.Json.Serialization;

namespace NekoSpace.SlstGen.Models;

public class SlstJacketLocalizationInfo
{
    [JsonPropertyName("ja")]
    public bool? Ja { get; set; } = null;

    [JsonPropertyName("ko")]
    public bool? Ko { get; set; } = null;

    [JsonPropertyName("zh-Hans")]
    public bool? ZhHans { get; set; } = null;

    [JsonPropertyName("zh-Hant")]
    public bool? ZhHant { get; set; } = null;

    public bool IsAllNull()
    {
        return (Ja, Ko, ZhHans, ZhHant) is (null, null, null, null);
    }
}
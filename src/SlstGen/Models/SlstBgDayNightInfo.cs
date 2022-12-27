using System.Text.Json.Serialization;

namespace NekoSpace.SlstGen.Models;

public class SlstBgDayNightInfo
{
    [JsonPropertyName("day")]
    public string Day { get; set; } = string.Empty;

    [JsonPropertyName("night")]
    public string Night { get; set; } = string.Empty;
}
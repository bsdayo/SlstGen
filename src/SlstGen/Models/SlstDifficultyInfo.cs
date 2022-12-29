using System.Text.Json.Serialization;

namespace NekoSpace.SlstGen.Models;

public class SlstDifficultyInfo
{
    [JsonPropertyName("ratingClass")]
    public ArcaeaRatingClass RatingClass { get; set; } = ArcaeaRatingClass.Future;

    [JsonPropertyName("chartDesigner")]
    public string ChartDesigner { get; set; } = string.Empty;

    [JsonPropertyName("jacketDesigner")]
    public string JacketDesigner { get; set; } = string.Empty;

    [JsonPropertyName("rating")]
    public int Rating { get; set; }

    [JsonPropertyName("ratingPlus")]
    public bool? RatingPlus { get; set; } = null;

    [JsonPropertyName("jacket_night")]
    public string? JacketNight { get; set; } = null;

    [JsonPropertyName("jacketOverride")]
    public bool? JacketOverride { get; set; } = null;

    [JsonPropertyName("audioOverride")]
    public bool? AudioOverride { get; set; } = null;

    [JsonPropertyName("hidden_until_unlocked")]
    public bool? HiddenUntilUnlocked { get; set; } = null;

    [JsonPropertyName("bg")]
    public string? Bg { get; set; } = null;

    [JsonPropertyName("world_unlock")]
    public bool? WorldUnlock { get; set; } = null;
}
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using NekoSpace.SlstGen.Models;

namespace NekoSpace.SlstGen.Services;

public class SlstService
{
    public SlstItem Slst { get; } = new();

    public event EventHandler? OnSlstUpdated;

    public string GetJsonText() =>
        JsonSerializer.Serialize(Slst, new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });

    public void InvokeSlstUpdatedEvent() => OnSlstUpdated?.Invoke(this, EventArgs.Empty);
}
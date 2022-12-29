using System;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace NekoSpace.SlstGen.ViewModels;

public class BasicPageViewModel : SlstViewModel
{
    public SharedViewModel Shared { get; } = Ioc.Default.GetRequiredService<SharedViewModel>();

    public string Id
    {
        get => Service.Slst.Id;
        set => Update(Service.Slst.Id, value, Service.Slst,
            (s, v) => s.Id = v ?? string.Empty);
    }

    public int Idx
    {
        get => Service.Slst.Idx;
        set => Update(Service.Slst.Idx, value, Service.Slst,
            (s, v) => s.Idx = v);
    }

    public string Artist
    {
        get => Service.Slst.Artist;
        set => Update(Service.Slst.Artist, value, Service.Slst,
            (s, v) => s.Artist = v ?? string.Empty);
    }

    public string Bpm
    {
        get => Service.Slst.Bpm;
        set => Update(Service.Slst.Bpm, value, Service.Slst,
            (s, v) => s.Bpm = v ?? string.Empty);
    }

    public double BpmBase
    {
        get => Service.Slst.BpmBase;
        set => Update(Service.Slst.BpmBase, value, Service.Slst,
            (s, v) => s.BpmBase = v);
    }

    public string Set
    {
        get => Service.Slst.Set;
        set => Update(Service.Slst.Set, value, Service.Slst,
            (s, v) => s.Set = v ?? string.Empty);
    }

    public string Purchase
    {
        get => Service.Slst.Purchase;
        set => Update(Service.Slst.Purchase, value, Service.Slst,
            (s, v) => s.Purchase = v ?? string.Empty);
    }

    public int AudioPreview
    {
        get => Service.Slst.AudioPreview;
        set => Update(Service.Slst.AudioPreview, value, Service.Slst,
            (s, v) => s.AudioPreview = v);
    }

    public int AudioPreviewEnd
    {
        get => Service.Slst.AudioPreviewEnd;
        set => Update(Service.Slst.AudioPreviewEnd, value, Service.Slst,
            (s, v) => s.AudioPreviewEnd = v);
    }

    public int Side
    {
        get => Service.Slst.Side;
        set => Update(Service.Slst.Side, value, Service.Slst,
            (s, v) => s.Side = v);
    }

    public string Bg
    {
        get => Service.Slst.Bg;
        set => Update(Service.Slst.Bg, value, Service.Slst,
            (s, v) => s.Bg = v ?? string.Empty);
    }

    private DateTime _date = DateTime.Now;
    private string _time = string.Empty;

    public DateTime Date
    {
        get => _date;
        set
        {
            _date = value;
            UpdateDate();
        }
    }

    public string Time
    {
        get => _time;
        set
        {
            _time = value;
            if (!DateTime.TryParse(_time, out var parsed))
                return;
            _date = new DateTime(_date.Year, _date.Month, _date.Day, parsed.Hour, parsed.Minute, parsed.Second);
            UpdateDate();
        }
    }

    public string Version
    {
        get => Service.Slst.Version;
        set => Update(Service.Slst.Version, value, Service.Slst,
            (s, v) => s.Version = v ?? string.Empty);
    }

    private void UpdateDate()
    {
        var timestamp = (long)(_date.ToUniversalTime() - DateTime.UnixEpoch).TotalSeconds;
        Update(Service.Slst.Date, timestamp, Service.Slst,
            (s, v) => s.Date = v);
    }
}
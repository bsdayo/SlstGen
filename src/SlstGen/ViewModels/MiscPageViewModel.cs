using CommunityToolkit.Mvvm.DependencyInjection;
using NekoSpace.SlstGen.Models;
using NekoSpace.SlstGen.Utils;

namespace NekoSpace.SlstGen.ViewModels;

public class MiscPageViewModel : SlstViewModel
{
    public SharedViewModel Shared { get; } = Ioc.Default.GetRequiredService<SharedViewModel>();

    public string? BgInverse
    {
        get => Service.Slst.BgInverse;
        set => Update(Service.Slst.BgInverse, value?.NullOrNotEmpty(), Service.Slst,
            (s, v) => s.BgInverse = v);
    }

    public string? BgDay
    {
        get => Service.Slst.BgDayNight?.Day;
        set
        {
            if (string.IsNullOrEmpty(value) && string.IsNullOrEmpty(BgNight))
            {
                Service.Slst.BgDayNight = null;
                Service.InvokeSlstUpdatedEvent();
                return;
            }

            Service.Slst.BgDayNight ??= new SlstBgDayNightInfo();
            Update(Service.Slst.BgDayNight.Day, value, Service.Slst,
                (s, v) => s.BgDayNight!.Day = v!);
        }
    }

    public string? BgNight
    {
        get => Service.Slst.BgDayNight?.Night;
        set
        {
            if (string.IsNullOrEmpty(value) && string.IsNullOrEmpty(BgDay))
            {
                Service.Slst.BgDayNight = null;
                Service.InvokeSlstUpdatedEvent();
                return;
            }

            Service.Slst.BgDayNight ??= new SlstBgDayNightInfo();
            Update(Service.Slst.BgDayNight.Night, value, Service.Slst,
                (s, v) => s.BgDayNight!.Night = v!);
        }
    }

    public string? SourceCopyright
    {
        get => Service.Slst.SourceCopyright;
        set => Update(Service.Slst.SourceCopyright, value?.NullOrNotEmpty(), Service.Slst,
            (s, v) => s.SourceCopyright = v);
    }

    public bool WorldUnlock
    {
        get => Service.Slst.WorldUnlock ?? false;
        set => Update(Service.Slst.WorldUnlock, value.NullOrTrue(), Service.Slst,
            (s, v) => s.WorldUnlock = v);
    }

    public bool RemoteDl
    {
        get => Service.Slst.RemoteDl ?? false;
        set => Update(Service.Slst.RemoteDl, value.NullOrTrue(), Service.Slst,
            (s, v) => s.RemoteDl = v);
    }

    public bool BydLocalUnlock
    {
        get => Service.Slst.BydLocalUnlock ?? false;
        set => Update(Service.Slst.BydLocalUnlock, value.NullOrTrue(), Service.Slst,
            (s, v) => s.BydLocalUnlock = v);
    }

    public bool SonglistHidden
    {
        get => Service.Slst.SonglistHidden ?? false;
        set => Update(Service.Slst.SonglistHidden, value.NullOrTrue(), Service.Slst,
            (s, v) => s.SonglistHidden = v);
    }

    public bool NoStream
    {
        get => Service.Slst.NoStream ?? false;
        set => Update(Service.Slst.NoStream, value.NullOrTrue(), Service.Slst,
            (s, v) => s.NoStream = v);
    }
}
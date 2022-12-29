using System;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.DependencyInjection;
using NekoSpace.SlstGen.Models;
using NekoSpace.SlstGen.Utils;

namespace NekoSpace.SlstGen.ViewModels;

public class LocalizationPageViewModel : SlstViewModel
{
    public SharedViewModel Shared { get; } = Ioc.Default.GetRequiredService<SharedViewModel>();

    public SlstLocalizationInfoViewModel TitleLocalized { get; }

    public SlstLocalizationInfoViewModel SourceLocalized { get; }

    private readonly SlstJacketLocalizationInfo _jacketInfo;

    public bool JacketLocalizedJa
    {
        get => _jacketInfo.Ja ?? false;
        set => UpdateJacketLocalized(_jacketInfo.Ja, value,
            (i, v) => i.Ja = v);
    }

    public bool JacketLocalizedKo
    {
        get => _jacketInfo.Ko ?? false;
        set => UpdateJacketLocalized(_jacketInfo.Ko, value,
            (i, v) => i.Ko = v);
    }

    public bool JacketLocalizedZhHans
    {
        get => _jacketInfo.ZhHans ?? false;
        set => UpdateJacketLocalized(_jacketInfo.ZhHans, value,
            (i, v) => i.ZhHans = v);
    }

    public bool JacketLocalizedZhHant
    {
        get => _jacketInfo.ZhHant ?? false;
        set => UpdateJacketLocalized(_jacketInfo.ZhHant, value,
            (i, v) => i.ZhHant = v);
    }

    public LocalizationPageViewModel()
    {
        TitleLocalized = new SlstLocalizationInfoViewModel(
            "曲目名称", nameof(Service.Slst.TitleLocalized));
        SourceLocalized = new SlstLocalizationInfoViewModel(
            "曲目来源", nameof(Service.Slst.SourceLocalized));

        _jacketInfo = Service.Slst.JacketLocalized ?? new SlstJacketLocalizationInfo();
    }

    private void UpdateJacketLocalized(bool? oldValue, bool newValue, Action<SlstJacketLocalizationInfo, bool?> action,
        [CallerMemberName] string? propertyName = null)
    {
        SetProperty(oldValue, newValue.NullOrTrue(), _jacketInfo, action, propertyName);
        Service.Slst.JacketLocalized = _jacketInfo.IsAllNull() ? null : _jacketInfo;
        Service.InvokeSlstUpdatedEvent();
    }
}
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using NekoSpace.SlstGen.Models;
using NekoSpace.SlstGen.Utils;

namespace NekoSpace.SlstGen.ViewModels;

public class SlstLocalizationInfoViewModel : SlstViewModel
{
    private readonly PropertyInfo _property;
    private readonly SlstLocalizationInfo _infoModel;
    private bool _isPropertyAssigned;
    private readonly bool _propertyIsTitleLocalized;

    public string CategoryName { get; }

    public string En
    {
        get => _infoModel.En;
        set => Update(_infoModel.En, value,
            (m, v) => m.En = v ?? string.Empty);
    }

    public string? Ja
    {
        get => _infoModel.Ja;
        set => Update(_infoModel.Ja, value?.NullOrNotEmpty(),
            (m, v) => m.Ja = v);
    }

    public string? Ko
    {
        get => _infoModel.Ko;
        set => Update(_infoModel.Ko, value?.NullOrNotEmpty(),
            (m, v) => m.Ko = v);
    }

    public string? ZhHans
    {
        get => _infoModel.ZhHans;
        set => Update(_infoModel.ZhHans, value?.NullOrNotEmpty(),
            (m, v) => m.ZhHans = v);
    }

    public string? ZhHant
    {
        get => _infoModel.ZhHant;
        set => Update(_infoModel.ZhHant, value?.NullOrNotEmpty(),
            (m, v) => m.ZhHant = v);
    }

    public SlstLocalizationInfoViewModel(string categoryName, string propertyName)
    {
        CategoryName = categoryName;

        _property = Service.Slst.GetType().GetProperty(propertyName)!;
        _infoModel = (SlstLocalizationInfo?)_property.GetValue(Service.Slst) ?? new SlstLocalizationInfo();
        _propertyIsTitleLocalized = propertyName == nameof(Service.Slst.TitleLocalized);
    }

    private void Update(string? oldValue, string? newValue, Action<SlstLocalizationInfo, string?> action,
        [CallerMemberName] string? propertyName = null)
    {
        SetProperty(oldValue, newValue, _infoModel, action, propertyName);

        if (CheckIsAllEmpty())
        {
            _property.SetValue(Service.Slst, null);
            _isPropertyAssigned = false;
        }
        else if (!_isPropertyAssigned)
        {
            _property.SetValue(Service.Slst, _infoModel);
            _isPropertyAssigned = true;
        }

        Service.InvokeSlstUpdatedEvent();
    }

    private bool CheckIsAllEmpty()
    {
        if (_propertyIsTitleLocalized) return false;
        return
            string.IsNullOrEmpty(_infoModel.En) &&
            string.IsNullOrEmpty(_infoModel.Ja) &&
            string.IsNullOrEmpty(_infoModel.Ko) &&
            string.IsNullOrEmpty(_infoModel.ZhHans) &&
            string.IsNullOrEmpty(_infoModel.ZhHant);
    }
}
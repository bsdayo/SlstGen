using System;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using NekoSpace.SlstGen.Services;

namespace NekoSpace.SlstGen.ViewModels;

public class SlstViewModel : ObservableObject
{
    protected SlstService Service { get; } = Ioc.Default.GetRequiredService<SlstService>();

    protected void Update<T, TModel>(T? oldValue, T? newValue, TModel model, Action<TModel, T?> action,
        [CallerMemberName] string? propertyName = null) where TModel : class
    {
        if (SetProperty(oldValue, newValue, model, action, propertyName))
            Service.InvokeSlstUpdatedEvent();
    }
}
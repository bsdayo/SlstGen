using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using NekoSpace.SlstGen.Models;
using NekoSpace.SlstGen.Services;

namespace NekoSpace.SlstGen.ViewModels;

public class SlstViewModel : ObservableObject
{
    protected SlstService Service { get; } = Ioc.Default.GetRequiredService<SlstService>();

    protected void Update<T>(T? oldValue, T? newValue, SlstItem model, Action<SlstItem, T?> action)
    {
        if (SetProperty(oldValue, newValue, model, action))
            Service.InvokeSlstUpdatedEvent();
    }
}
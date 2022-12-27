using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using NekoSpace.SlstGen.Models;
using NekoSpace.SlstGen.Services;

namespace NekoSpace.SlstGen.ViewModels;

public class SlstDifficultyInfoViewModel : ObservableObject
{
    private readonly SlstService _service = Ioc.Default.GetRequiredService<SlstService>();
    private readonly SlstDifficultyInfo _infoModel;

    public string RatingClassText => _infoModel.RatingClass.ToString();

    public string ChartDesigner
    {
        get => _infoModel.ChartDesigner;
        set => Update(_infoModel.ChartDesigner, value, _infoModel,
            (m, v) => m.ChartDesigner = v ?? string.Empty);
    }

    public string JacketDesigner
    {
        get => _infoModel.JacketDesigner;
        set => Update(_infoModel.JacketDesigner, value, _infoModel,
            (m, v) => m.JacketDesigner = v ?? string.Empty);
    }

    private string _difficulty = string.Empty;

    public string Difficulty
    {
        get => _difficulty;
        set
        {
            _difficulty = value;
            var index = value.IndexOf('+');
            bool? ratingPlus = index > 0 ? true : null;
            if (!int.TryParse(index > 0 ? value.AsSpan()[..index] : value, out var rating))
                rating = 0;

            SetProperty(_infoModel.RatingPlus, ratingPlus, _infoModel,
                (m, v) => m.RatingPlus = v);
            SetProperty(_infoModel.Rating, rating, _infoModel,
                (m, v) => m.Rating = v);

            _service.InvokeSlstUpdatedEvent();
        }
    }

    public SlstDifficultyInfoViewModel(SlstDifficultyInfo infoModel)
    {
        _infoModel = infoModel;
    }

    private void Update<T>(T? oldValue, T? newValue, SlstDifficultyInfo model, Action<SlstDifficultyInfo, T?> action)
    {
        if (SetProperty(oldValue, newValue, model, action))
            _service.InvokeSlstUpdatedEvent();
    }
}
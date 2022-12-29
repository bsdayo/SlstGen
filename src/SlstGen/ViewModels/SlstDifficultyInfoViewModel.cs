using System;
using NekoSpace.SlstGen.Models;
using NekoSpace.SlstGen.Utils;

namespace NekoSpace.SlstGen.ViewModels;

public class SlstDifficultyInfoViewModel : SlstViewModel
{
    private readonly SlstDifficultyInfo _infoModel;

    public string RatingClassText => _infoModel.RatingClass.ToString();
    public int RatingClassIndex => (int)_infoModel.RatingClass;

    public string SpecialCoverLabel => $"{RatingClassText} 难度使用特殊曲绘（需要 {RatingClassIndex}.jpg）";
    public string SpecialAudioLabel => $"{RatingClassText} 难度使用特殊音频（需要 {RatingClassIndex}.ogg）";

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
            SetProperty(ref _difficulty, value);
            var index = value.IndexOf('+');
            bool? ratingPlus = index > 0 ? true : null;
            if (!int.TryParse(index > 0 ? value.AsSpan()[..index] : value, out var rating))
                rating = 0;

            SetProperty(_infoModel.RatingPlus, ratingPlus, _infoModel,
                (m, v) => m.RatingPlus = v);
            SetProperty(_infoModel.Rating, rating, _infoModel,
                (m, v) => m.Rating = v);

            Service.InvokeSlstUpdatedEvent();
        }
    }

    public bool JacketOverride
    {
        get => _infoModel.JacketOverride ?? false;
        set => Update(_infoModel.JacketOverride, value.NullOrTrue(), _infoModel,
            (m, v) => m.JacketOverride = v);
    }

    public bool AudioOverride
    {
        get => _infoModel.AudioOverride ?? false;
        set => Update(_infoModel.AudioOverride, value.NullOrTrue(), _infoModel,
            (m, v) => m.AudioOverride = v);
    }

    public bool HiddenUntilUnlocked
    {
        get => _infoModel.HiddenUntilUnlocked ?? false;
        set => Update(_infoModel.HiddenUntilUnlocked, value.NullOrTrue(), _infoModel,
            (m, v) => m.HiddenUntilUnlocked = v);
    }

    public bool WorldUnlock
    {
        get => _infoModel.WorldUnlock ?? false;
        set => Update(_infoModel.WorldUnlock, value.NullOrTrue(), _infoModel,
            (m, v) => m.WorldUnlock = v);
    }

    public string JacketNight
    {
        get => _infoModel.JacketNight ?? string.Empty;
        set => Update(_infoModel.JacketNight, value.NullOrNotEmpty(), _infoModel,
            (m, v) => m.JacketNight = v);
    }

    public string Bg
    {
        get => _infoModel.Bg ?? string.Empty;
        set => Update(_infoModel.Bg, value.NullOrNotEmpty(), _infoModel,
            (m, v) => m.Bg = v);
    }

    public SlstDifficultyInfoViewModel(SlstDifficultyInfo infoModel)
    {
        _infoModel = infoModel;
    }
}
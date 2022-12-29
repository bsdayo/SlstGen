using System.Collections.ObjectModel;
using System.Linq;
using NekoSpace.SlstGen.Models;

namespace NekoSpace.SlstGen.ViewModels;

public class SharedViewModel : SlstViewModel
{
    public string NameEn
    {
        get => Service.Slst.TitleLocalized.En;
        set => Update(Service.Slst.TitleLocalized.En, value, Service.Slst,
            (s, v) => s.TitleLocalized.En = v!);
    }

    public ObservableCollection<SlstDifficultyInfoViewModel> Difficulties { get; }

    public SharedViewModel()
    {
        Difficulties =
            new ObservableCollection<SlstDifficultyInfoViewModel>(
                Service.Slst.Difficulties.Select(d => new SlstDifficultyInfoViewModel(d)));
    }

    public void AddBeyondDifficulty()
    {
        var diffInfo = new SlstDifficultyInfo { RatingClass = ArcaeaRatingClass.Beyond };
        Service.Slst.Difficulties.Add(diffInfo);
        Difficulties.Add(new SlstDifficultyInfoViewModel(diffInfo));
        Service.InvokeSlstUpdatedEvent();
    }

    public void RemoveBeyondDifficulty()
    {
        Service.Slst.Difficulties.RemoveAt(3);
        Difficulties.RemoveAt(3);
        Service.InvokeSlstUpdatedEvent();
    }
}
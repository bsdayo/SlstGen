using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using NekoSpace.SlstGen.ViewModels;

namespace NekoSpace.SlstGen.Views.Pages;

public partial class BasicPage
{
    public BasicPage()
    {
        InitializeComponent();
    }

    private void OnDifficultyTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = DifficultyTextRegex().IsMatch(e.Text);
    }

    private void OnTimeTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = TimeTextRegex().IsMatch(e.Text);
    }

    private void OnVersionTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = VersionTextRegex().IsMatch(e.Text);
    }

    // lang=regex
    [GeneratedRegex("[^0-9+]+")]
    private static partial Regex DifficultyTextRegex();

    // lang=regex
    [GeneratedRegex("[^0-9:]+")]
    private static partial Regex TimeTextRegex();

    // lang=regex
    [GeneratedRegex("[^0-9.]+")]
    private static partial Regex VersionTextRegex();

    private void OnBeyondToggleSwitchChecked(object sender, RoutedEventArgs e)
    {
        ((BasicPageViewModel)DataContext).Shared.AddBeyondDifficulty();
    }

    private void OnBeyondToggleSwitchUnchecked(object sender, RoutedEventArgs e)
    {
        ((BasicPageViewModel)DataContext).Shared.RemoveBeyondDifficulty();
    }
}
using Wpf.Ui.Appearance;

namespace NekoSpace.SlstGen.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();

        Loaded += (_, _) => Watcher.Watch(this);
    }
}
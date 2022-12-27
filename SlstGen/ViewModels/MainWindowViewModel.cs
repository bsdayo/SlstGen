using System.IO;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Win32;
using NekoSpace.SlstGen.Services;
using Wpf.Ui.Common;

namespace NekoSpace.SlstGen.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private readonly SlstService _service = Ioc.Default.GetRequiredService<SlstService>();

    private string _previewText;

    public string PreviewText
    {
        get => _previewText;
        set => SetProperty(ref _previewText, value);
    }

    public ICommand CopyCommand { get; }

    public ICommand SaveCommand { get; }

    public MainWindowViewModel()
    {
        _previewText = _service.GetJsonText();
        _service.OnSlstUpdated += (_, _) => PreviewText = _service.GetJsonText();

        CopyCommand = new RelayCommand(() => Clipboard.SetText(PreviewText));
        SaveCommand = new RelayCommand(SaveSlstFile);
    }

    public void SaveSlstFile()
    {
        var sfd = new SaveFileDialog
        {
            Filter = "JSON 文档 (*.json)|*.json|文本文档 (*.txt)|*.txt",
            FilterIndex = 1,
            RestoreDirectory = true,
            FileName = "songlist"
        };

        if (sfd.ShowDialog() ?? false) File.WriteAllText(sfd.FileName, PreviewText);
    }
}
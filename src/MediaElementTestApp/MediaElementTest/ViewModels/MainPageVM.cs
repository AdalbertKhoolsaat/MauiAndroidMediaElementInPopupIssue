using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediaElementTest.Controls;

namespace MediaElementTest.ViewModels;
public partial class MainPageVM : ObservableObject
{
    private readonly IPopupService _popupService;

    [ObservableProperty] public partial MediaSource? VideoSource { get; set; }

    public MainPageVM(IPopupService popupService)
    {
        _popupService = popupService;
    }  

    public void Initialize()
    {
        VideoSource = MediaSource.FromUri(Constants.StreamingVideoUrls.SampleVideo);
    }
        
    [RelayCommand]
    private async Task StartVideoPlayback()
    {
        var options = new PopupOptions
        {
            CanBeDismissedByTappingOutsideOfPopup = false
        };

        _ = await _popupService.ShowPopupAsync<VideoPopup>(Shell.Current, options: options, shellParameters: new Dictionary<string, object>
        {
            {"MediaSource", VideoSource! }
        });
    }
}
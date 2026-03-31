using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MediaElementTest.Controls;

public partial class VideoPopupVM : ObservableObject, IQueryAttributable
{    
    private readonly IPopupService _popupService;

    [ObservableProperty] public partial MediaSource? VideoSource { get; set; }

    public VideoPopupVM(IPopupService popupService)
    {        
        _popupService = popupService;       
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("MediaSource", out var mediaSource) && mediaSource is MediaSource videoSource)
        {
            VideoSource = videoSource;
        }
    }

    [RelayCommand]
    private async Task Close()
    {                
        await _popupService.ClosePopupAsync(Shell.Current);
    }
}
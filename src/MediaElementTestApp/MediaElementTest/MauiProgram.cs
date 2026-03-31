using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MediaElementTest.Controls;
using MediaElementTest.ViewModels;

namespace MediaElementTest;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
                .UseMauiCommunityToolkitMediaElement(isAndroidForegroundServiceEnabled: false)
                .UseMauiCommunityToolkit(options =>
                {
                    options.SetShouldEnableSnackbarOnWindows(true);
                })
                .AddViews()
                .AddViewModels()
                .AddPopupViews()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    public static MauiAppBuilder AddViews(this MauiAppBuilder appBuilder)
    {
        appBuilder.Services.AddSingleton<AppShell>();
        appBuilder.Services.AddSingleton<MainPage>();

        return appBuilder;
    }

    public static MauiAppBuilder AddViewModels(this MauiAppBuilder appBuilder)
    {
        appBuilder.Services.AddSingleton<MainPageVM>();

        return appBuilder;
    }

    public static MauiAppBuilder AddPopupViews(this MauiAppBuilder appBuilder)
    {
        appBuilder.Services.AddTransientPopup<VideoPopup, VideoPopupVM>();

        return appBuilder;
    }
}

using Microsoft.Extensions.Logging;

namespace ElginM10MauiBlazor;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<Services.IDialogService, Services.DialogService>();
        builder.Services.AddSingleton<Services.E1BridgeService>();
		builder.Services.AddSingleton<Services.PrinterService>();
		builder.Services.AddSingleton<Services.KioskService>();
		builder.Services.AddSingleton<Services.SatService>();

        return builder.Build();
    }
}

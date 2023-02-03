namespace ElginM10MauiBlazor.Shared;
public partial class MainLayout
{
    private static bool KioskMode { get; set; } = false;

    private async Task ToggleKioskMode()
    {
        if (DeviceInfo.Current.Platform != DevicePlatform.Android)
        {
            return;
        }

        KioskMode = !KioskMode;

        if (KioskMode)
        {
            await KioskService.DesabilitaBarraStatusAsync();
            await KioskService.DesabilitaBarraNavegacaoAsync();
            await KioskService.DesabilitaBotaoPowerAsync();
        }
        else
        {
            await KioskService.HabilitaBarraNavegacaoAsync();
            await KioskService.HabilitaBarraStatusAsync();
            await KioskService.HabilitaBotaoPowerAsync();
        }
    }
}

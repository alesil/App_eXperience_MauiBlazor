namespace ElginM10MauiBlazor.Shared;
public partial class MainLayout
{
        private static bool KioskMode { get; set; } = false;

    private void ToggleKioskMode()
    {
        if (DeviceInfo.Current.Platform != DevicePlatform.Android)
        {
            return;
        }

        KioskMode = !KioskMode;

        if (KioskMode)
        {
            KioskService.DesabilitaBarraStatus();
            KioskService.DesabilitaBarraNavegacao();
            KioskService.DesabilitaBotaoPower();
        }
        else
        {
            KioskService.HabilitaBarraNavegacao();
            KioskService.HabilitaBarraStatus();
            KioskService.HabilitaBotaoPower();
        }
    }
}

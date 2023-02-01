using Microsoft.AspNetCore.Components;

namespace ElginM10MauiBlazor.Pages;
public partial class Principal : ComponentBase
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
            KioskService.DesabilitaBarraNavegacao();
            KioskService.DesabilitaBarraStatus();
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

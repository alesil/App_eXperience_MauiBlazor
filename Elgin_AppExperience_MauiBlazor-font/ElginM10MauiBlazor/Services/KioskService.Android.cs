using Com.Elgin.E1.Core;


namespace ElginM10MauiBlazor.Services;
internal partial class KioskService
{
    private Utils _utils;
    private partial void DoConstructor()
    {
        var ctx = MainActivity.mContext;
        _utils = new Utils(ctx);
    }

    internal partial void HabilitaBarraStatus() => _utils.HabilitaBarraStatus();
    internal partial void DesabilitaBarraStatus() => _utils.DesabilitaBarraStatus();
    internal partial void HabilitaBarraNavegacao() => _utils.HabilitaBarraNavegacao();
    internal partial void DesabilitaBarraNavegacao() => _utils.DesabilitaBarraNavegacao();
    internal partial void HabilitaBotaoPower() => _utils.HabilitaBotaoPower();
    internal partial void DesabilitaBotaoPower() => _utils.DesabilitaBotaoPower();
}

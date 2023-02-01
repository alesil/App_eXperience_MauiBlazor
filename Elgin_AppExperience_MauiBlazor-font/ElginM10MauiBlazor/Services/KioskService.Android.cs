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

    public partial void HabilitaBarraStatus() => _utils.HabilitaBarraStatus();
    public partial void DesabilitaBarraStatus() => _utils.DesabilitaBarraStatus();
    public partial void HabilitaBarraNavegacao() => _utils.HabilitaBarraNavegacao();
    public partial void DesabilitaBarraNavegacao() => _utils.DesabilitaBarraNavegacao();
    public partial void HabilitaBotaoPower() => _utils.HabilitaBotaoPower();
    public partial void DesabilitaBotaoPower() => _utils.DesabilitaBotaoPower();
}

namespace ElginM10MauiBlazor.Services;
internal partial class KioskService
{
    public KioskService()
    {
        DoConstructor();
    }

    private partial void DoConstructor();

    internal partial void HabilitaBarraStatus();
    internal partial void DesabilitaBarraStatus();
    internal partial void HabilitaBarraNavegacao();
    internal partial void DesabilitaBarraNavegacao();
    internal partial void HabilitaBotaoPower();
    internal partial void DesabilitaBotaoPower();

    internal async Task HabilitaBarraStatusAsync()
        => await Task.Run(() => HabilitaBarraStatus());
    internal async Task DesabilitaBarraStatusAsync()
        => await Task.Run(() => DesabilitaBarraStatus());
    internal async Task HabilitaBarraNavegacaoAsync()
        => await Task.Run(() => HabilitaBarraNavegacao());
    internal async Task DesabilitaBarraNavegacaoAsync()
        => await Task.Run(() => DesabilitaBarraNavegacao());
    internal async Task HabilitaBotaoPowerAsync()
        => await Task.Run(() => HabilitaBotaoPower());
    internal async Task DesabilitaBotaoPowerAsync()
        => await Task.Run(() => DesabilitaBotaoPower());
}

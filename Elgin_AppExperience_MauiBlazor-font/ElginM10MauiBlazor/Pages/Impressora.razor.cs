using ElginM10MauiBlazor.Services;

using Microsoft.AspNetCore.Components;

namespace ElginM10MauiBlazor.Pages;
public partial class Impressora : ComponentBase
{
    private bool _showSpinner = false;
    private string _messageSpinner = "Aguardando Impressão...";
    public readonly Dados DadosImpressora = new();
    private EPaginaImpressora _paginaImpressora = EPaginaImpressora.ImpressoraTexto;

    private ETipoImpresora _tipoImpressoraAtual = ETipoImpresora.Interna;
    private string _impressoraIpAtual = string.Empty;

    public RenderFragment ChildContent { get; set; }

    protected async override Task OnInitializedAsync()
    {
        _ = await PrinterService.PrinterInternalImpStartAsync();
        await base.OnInitializedAsync();
    }

    public void ShowSpinner(string message = "Aguardando Impressão...")
    {
        _messageSpinner = message;
        _showSpinner = true;
        StateHasChanged();
    }

    public void HideSpinner()
    {
        _showSpinner = false;
        StateHasChanged();
    }

    private void ClickImpressoraTexto()
    {
        _paginaImpressora = EPaginaImpressora.ImpressoraTexto;
    }

    private void ClickImpressoraBarcode()
    {
        _paginaImpressora = EPaginaImpressora.ImpressoraBarcode;
    }

    private void ClickImpressoraImagem()
    {
        _paginaImpressora = EPaginaImpressora.ImpressoraImagem;
    }

    public async Task VerificarConexaoImpressora()
    {
        if (DadosImpressora.TipoImpresora == _tipoImpressoraAtual
            && DadosImpressora.ImpressoraIp == _impressoraIpAtual)
            return;

        switch (DadosImpressora.TipoImpresora)
        {
            case ETipoImpresora.Interna:
                _ = await PrinterService.PrinterInternalImpStartAsync();
                break;
            case ETipoImpresora.Usb:
                HideSpinner();
                string modeloImpressoraUsb = await SelecionarModeloImpressoraUsb();
                ShowSpinner("Conectando impressora...");
                if (string.IsNullOrEmpty(modeloImpressoraUsb))
                {
                    await PrinterService.PrinterInternalImpStartAsync();
                }
                _ = await PrinterService.PrinterExternalImpStartByUSBAsync(modeloImpressoraUsb);
                break;
            case ETipoImpresora.Ethernet:
                string[] ipAndPort = DadosImpressora.ImpressoraIp.Split(':');
                HideSpinner();
                string modeloImpressoraEth = await SelecionarModeloImpressoraEth();
                ShowSpinner("Conectando impressora...");
                if (string.IsNullOrEmpty(modeloImpressoraEth))
                {
                    await PrinterService.PrinterInternalImpStartAsync();
                }
                int result = await PrinterService.PrinterExternalImpStartByIPAsync(modeloImpressoraEth, ipAndPort[0], int.Parse(ipAndPort[1]));
                if (result != 0)
                {
                    HideSpinner();
                    await DialogService.DisplayAlert("Alerta", "A tentativa de conexão por IP não foi bem sucedida!", "OK");
                    ShowSpinner("Conectando impressora...");
                    await PrinterService.PrinterInternalImpStartAsync();
                }
                break;
            default:
                _ = await PrinterService.PrinterInternalImpStartAsync();
                DadosImpressora.TipoImpresora = ETipoImpresora.Interna;
                break;
        }
        _tipoImpressoraAtual = DadosImpressora.TipoImpresora;
        _impressoraIpAtual = DadosImpressora.ImpressoraIp;
    }

    private async Task<string> SelecionarModeloImpressoraUsb()
    {
        string[] models = { "i9", "i8" };
        return await DialogService.DisplayActionSheet("Selecione o modelo de impressora a ser conectado", "CANCELAR", null, models);
    }

    private async Task<string> SelecionarModeloImpressoraEth()
    {
        string[] models = { "i9", "i8" };
        return await DialogService.DisplayActionSheet("Selecione o modelo de impressora a ser conectado", "CANCELAR", null, models);
    }

    private async void VerificarStatusGaveta()
    {
        ShowSpinner("Verificando gaveta...");
        await VerificarConexaoImpressora();
        int statusGaveta = await PrinterService.StatusGavetaAsync();
        HideSpinner();
        switch (statusGaveta)
        {
            case 1:
                await DialogService.DisplayAlert("Status da Gaveta", "Gaveta aberta!", "OK");
                break;
            case 2:
                await DialogService.DisplayAlert("Status da Gaveta", "Gaveta fechada!", "OK");
                break;
            default:
                await DialogService.DisplayAlert("Status da Gaveta", "Status Desconhecido", "OK");
                break;
        }
    }
    private async void VerificarStatusImpressora()
    {
        ShowSpinner("Verificando sensor...");
        await VerificarConexaoImpressora();
        int statusImpressora = await PrinterService.StatusSensorPapelAsync();
        HideSpinner();

        switch (statusImpressora)
        {
            case 5:
                await DialogService.DisplayAlert("Status da Impressora", "Papel está presente e não está próximo do fim!", "OK");
                break;
            case 6:
                await DialogService.DisplayAlert("Status da Impressora", "Papel está próximo do fim!", "OK");
                break;
            case 7:
                await DialogService.DisplayAlert("Status da Impressora", "Papel ausente!", "OK");
                break;
            default:
                await DialogService.DisplayAlert("Status da Impressora", "Status Desconhecido", "OK");
                break;
        }
    }
    private async void AbrirGaveta()
    {
        ShowSpinner("Abrindo gaveta...");
        await VerificarConexaoImpressora();
        _ = await PrinterService.AbrirGavetaAsync();
        HideSpinner();
    }

    public class Dados
    {
        public ETipoImpresora TipoImpresora { get; set; } = DeviceInfo.Current.Platform == DevicePlatform.Android ? ETipoImpresora.Interna : ETipoImpresora.Usb;
        public string ImpressoraIp { get; set; } = "192.168.2.160:9100";
    }

    public enum ETipoImpresora
    {
        Interna,
        Usb,
        Ethernet
    }

    private enum EPaginaImpressora
    {
        ImpressoraTexto,
        ImpressoraBarcode,
        ImpressoraImagem
    }
}


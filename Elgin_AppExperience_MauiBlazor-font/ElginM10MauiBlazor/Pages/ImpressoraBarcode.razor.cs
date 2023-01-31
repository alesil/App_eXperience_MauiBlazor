using ElginM10MauiBlazor.Services;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace ElginM10MauiBlazor.Pages;
public partial class ImpressoraBarcode : ComponentBase
{
    [CascadingParameter]
    private Impressora Parent { get; set; }

    private EditContext EditContext;
    private readonly Dados _dados = new();

    private void ShowSpinner(string mensagem) => Parent.ShowSpinner(mensagem);
    private void HideSpinner() => Parent.HideSpinner();

    private readonly string[] barCodeOptions = new string[] { "EAN 8", "EAN 13", "QR CODE", "UPC-A", "CODE 39", "ITF", "CODE BAR", "CODE 93", "CODE 128" };
    private readonly string[] heigthOptions = new string[] { "20", "60", "120", "200" };
    private readonly string[] widthOptions = new string[] { "1", "2", "3", "4", "5", "6" };

    protected override void OnInitialized()
    {
        base.OnInitialized();

        // Define o contexto do EditForm, passando o ob
        EditContext = new EditContext(_dados);
        EditContext.OnFieldChanged += EditContext_OnFieldChanged;
    }

    private void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        switch (e.FieldIdentifier.FieldName)
        {
            case nameof(Dados.BarCodeType):
                // Alterado o tipo do código de barras
                AlterarCodigoBarrasConformeTipo();
                break;
            default:
                break;
        }
    }

    private void AlterarCodigoBarrasConformeTipo()
    {
        _dados.BarCodeText = _dados.BarCodeType switch
        {
            "EAN 8" => "40170725",
            "EAN 13" => "0123456789012",
            "QR CODE" => "ELGIN DEVELOPERS COMMUNITY",
            "UPC-A" => "123601057072",
            "CODE 39" => "*ABC123*",
            "ITF" => "05012345678900",
            "CODE BAR" => "A3419500A",
            "CODE 93" => "ABC123456789",
            "CODE 128" => "{C1233",
            _ => string.Empty
        };
    }

    private async Task ImprimirCodigoBarras()
    {
        if (string.IsNullOrWhiteSpace(_dados.BarCodeText))
        {
            await DialogService.DisplayAlert("Campo Vazio", "A entrada do Código de Barras está vazio, insira um valor", "OK");
            return;
        }

        if (_dados.BarCodeType == "QR CODE")
        {
            await ImprimirQrCode();
        }
        else
        {
            await ImprimirCodigoBarrasPadrao();
        }
    }

    private async Task ImprimirCodigoBarrasPadrao()
    {
        await Parent.VerificarConexaoImpressora();
        ShowSpinner("Imprimindo Código de Barras...");

        var parametros = new Dictionary<string, string>();
        string align = _dados.Alinhamento switch
        {
            EAlinhamento.Esquerda => "Esquerda",
            EAlinhamento.Centralizado => "Centralizado",
            EAlinhamento.Direita => "Direita",
            _ => " "
        };

        parametros.Add("barCodeType", _dados.BarCodeType);
        parametros.Add("text", _dados.BarCodeText);
        parametros.Add("height", _dados.BarCodeHeight);
        parametros.Add("width", _dados.BarCodeWidth);
        parametros.Add("align", align);

        await PrinterService.ImprimeBarCodeAsync(parametros);
        await PrinterService.JumpLineAsync();
        await PrinterService.JumpLineAsync();

        if (_dados.CutPaper)
        {
            await PrinterService.CutPaperAsync(1);
        }
        HideSpinner();
    }

    private async Task ImprimirQrCode()
    {
        await Parent.VerificarConexaoImpressora();
        ShowSpinner("Imprimindo QR-Code...");

        var parametros = new Dictionary<string, string>();
        string align = _dados.Alinhamento switch
        {
            EAlinhamento.Esquerda => "Esquerda",
            EAlinhamento.Centralizado => "Centralizado",
            EAlinhamento.Direita => "Direita",
            _ => " "
        };

        parametros.Add("qrSize", _dados.BarCodeWidth);
        parametros.Add("text", _dados.BarCodeText);
        parametros.Add("align", align);

        await PrinterService.ImprimeQR_CODEAsync(parametros);
        await PrinterService.JumpLineAsync();
        await PrinterService.JumpLineAsync();

        if (_dados.CutPaper)
        {
            await PrinterService.CutPaperAsync(1);
        }
        HideSpinner();
    }

    private class Dados
    {
        public string BarCodeText { get; set; } = "0123456789012";
        public string BarCodeType { get; set; } = "EAN 13";
        public EAlinhamento Alinhamento { get; set; } = EAlinhamento.Esquerda;
        public string BarCodeWidth { get; set; } = "4";
        public string BarCodeHeight { get; set; } = "60";
        public bool CutPaper { get; set; } = false;

    }

    private enum EAlinhamento
    {
        Esquerda,
        Centralizado,
        Direita
    }
}


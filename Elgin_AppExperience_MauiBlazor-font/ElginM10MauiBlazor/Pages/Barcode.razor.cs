using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace ElginM10MauiBlazor.Pages;
public partial class Barcode : ComponentBase
{
    private bool _showSpinner = false;
    private string _messageSpinner = "Aguarde...";

    private Dados _dados = new();

    private InputText _codigo01;
    private InputText _codigo02;
    private InputText _codigo03;
    private InputText _codigo04;
    private InputText _codigo05;
    private InputText _codigo06;
    private InputText _codigo07;
    private InputText _codigo08;

    private async Task IniciarLeitura()
    {
        await LimparCampos();
    }

    private async Task LimparCampos()
    {
        _dados.Codigo01 = string.Empty;
        _dados.Codigo02 = string.Empty;
        _dados.Codigo03 = string.Empty;
        _dados.Codigo04 = string.Empty;
        _dados.Codigo05 = string.Empty;
        _dados.Codigo06 = string.Empty;
        _dados.Codigo07 = string.Empty;
        _dados.Codigo08 = string.Empty;

        await _codigo01.Element.Value.FocusAsync();
    }

    private async Task OnKeyPressCodigo01(KeyboardEventArgs args) => await OnKeyPress(args, _codigo02);
    private async Task OnKeyPressCodigo02(KeyboardEventArgs args) => await OnKeyPress(args, _codigo03);
    private async Task OnKeyPressCodigo03(KeyboardEventArgs args) => await OnKeyPress(args, _codigo04);
    private async Task OnKeyPressCodigo04(KeyboardEventArgs args) => await OnKeyPress(args, _codigo05);
    private async Task OnKeyPressCodigo05(KeyboardEventArgs args) => await OnKeyPress(args, _codigo06);
    private async Task OnKeyPressCodigo06(KeyboardEventArgs args) => await OnKeyPress(args, _codigo07);
    private async Task OnKeyPressCodigo07(KeyboardEventArgs args) => await OnKeyPress(args, _codigo08);
    private async Task OnKeyPressCodigo08(KeyboardEventArgs args) => await OnKeyPress(args, _codigo08);


    private async Task OnKeyPress(KeyboardEventArgs args, InputText nextElement)
    {
        if (args.Key == "Enter")
        {
            await nextElement.Element.Value.FocusAsync();
        }
    }

    private class Dados
    {
        public string Codigo01 { get; set; }
        public string Codigo02 { get; set; }
        public string Codigo03 { get; set; }
        public string Codigo04 { get; set; }
        public string Codigo05 { get; set; }
        public string Codigo06 { get; set; }
        public string Codigo07 { get; set; }
        public string Codigo08 { get; set; }
    }
}

using Microsoft.AspNetCore.Components;

namespace ElginM10MauiBlazor.Pages;
public partial class Sat : ComponentBase
{
    private readonly Dados _dados = new();

    private bool _showSpinner = false;
    private string _messageSpinner = "Comunicando com o SAT...";

    public void ShowSpinner(string message = "Comunicando com o SAT...")
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

    private void Cmd()
    {
        _dados.RetornoSat = "Uma grande string replicada várias vezes";
        _dados.RetornoSat += _dados.RetornoSat;
        _dados.RetornoSat += _dados.RetornoSat;
        _dados.RetornoSat += _dados.RetornoSat;
        _dados.RetornoSat += _dados.RetornoSat;
        _dados.RetornoSat += _dados.RetornoSat;
        _dados.RetornoSat += _dados.RetornoSat;
        _dados.RetornoSat += _dados.RetornoSat;
        _dados.RetornoSat += _dados.RetornoSat;
        _dados.RetornoSat += _dados.RetornoSat;
        _dados.RetornoSat += _dados.RetornoSat;
    }

    private class Dados
    {
        public ModeloSat Modelo { get; set; } = ModeloSat.SmartSat;
        public string CodigoAtivacao { get; set; } = "123456789";
        public string RetornoSat { get; set; } = string.Empty;
    }

    private enum ModeloSat
    {
        SmartSat,
        SatGo
    }
}

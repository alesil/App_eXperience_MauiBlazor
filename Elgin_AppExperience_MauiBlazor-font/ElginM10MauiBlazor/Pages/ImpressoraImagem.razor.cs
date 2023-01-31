using Microsoft.AspNetCore.Components;

namespace ElginM10MauiBlazor.Pages;
public partial class ImpressoraImagem : ComponentBase
{
    [CascadingParameter]
    private Impressora Parent { get; set; }

    private readonly Dados _dados = new();

    private async Task Imprimir()
    {

    }

    private async Task CarregarImagem()
    {

    }

    private class Dados
    {
        public bool CutPaper { get; set; } = false;

    }
}

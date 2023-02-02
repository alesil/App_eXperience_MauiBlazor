using Microsoft.AspNetCore.Components;

using System.Reflection;

namespace ElginM10MauiBlazor.Pages;
public partial class ImpressoraImagem : ComponentBase
{
    [CascadingParameter]
    private Impressora Parent { get; set; }

    private readonly Dados _dados = new();

    private void ShowSpinner(string mensagem) => Parent.ShowSpinner(mensagem);
    private void HideSpinner() => Parent.HideSpinner();

    protected override async Task OnInitializedAsync()
    {
        await CarregarImagemPadrao();
        await base.OnInitializedAsync();
    }

    private async Task Imprimir()
    {
        await Parent.VerificarConexaoImpressora();
        ShowSpinner("Imprimindo Imagem...");

        // foi passado a extensão da imagem para conseguir imprimir no ambiente windows, para android não é necessário.
        _dados.ImageStream.Position = 0;
        var ret = await PrinterService.ImprimeImagemAsync(_dados.ImageStream, _dados.ImageFileExtension);

        await PrinterService.JumpLineAsync();
        await PrinterService.JumpLineAsync();

        if (_dados.CutPaper)
        {
            await PrinterService.CutPaperAsync(1);
        }
        HideSpinner();

        if (ret != 0)
        {
            await DialogService.DisplayAlert("Impressão de Imagem", $"Retorno: {ret}", "OK");
        }
    }

    private async Task CarregarImagemPadrao()
    {
        // Realiza a leitura de uma imagem fixa dentro do projeto Maui
        // (não é válido para imagens dentro do wwwroot)
        try
        {
            // Neste exemplo, imagem deve estar na pasta Resources/Raw
            // com o atributo BuildAction = MauiAsset
            using var sourceStream = await FileSystem.OpenAppPackageFileAsync("elgin_logo_default_print_image.png");
            if (sourceStream != null)
            {
                using MemoryStream ms = new();
                _dados.ImageStream = new();
                sourceStream.CopyTo(_dados.ImageStream); // Armazena o stream em _dados

                byte[] byteArray = _dados.ImageStream.ToArray();
                var b64String = Convert.ToBase64String(byteArray);
                _dados.ImageUrl = $"data:image;base64,{b64String}";
                _dados.ImageFileExtension = ".png";
            }
        }
        catch (Exception ex)
        {
            await DialogService.DisplayAlert("Erro ao Carregar Imagem Padrão", ex.Message, "OK");
        }
    }

    private async Task CarregarImagem()
    {
        MediaPickerOptions options = new()
        {
            Title = "Selecione uma imagem"
        };

        try
        {
            FileResult photo = await MediaPicker.Default.PickPhotoAsync(options);

            if (photo != null)
            {
                using Stream sourceStream = await photo.OpenReadAsync();

                if (sourceStream != null)
                {
                    _dados.ImageStream = new();
                    sourceStream.CopyTo(_dados.ImageStream); // Armazena o stream em _dados

                    byte[] byteArray = _dados.ImageStream.ToArray();
                    var b64String = Convert.ToBase64String(byteArray);
                    _dados.ImageUrl = $"data:{photo.ContentType};base64,{b64String}";
                    FileInfo fi = new(photo.FileName);
                    _dados.ImageFileExtension = fi.Extension;
                }
            }
        }
        catch (Exception ex)
        {
            await DialogService.DisplayAlert("Erro ao Carregar Imagem", ex.Message, "OK");
        }
    }

    private class Dados
    {
        public bool CutPaper { get; set; } = false;
        public string ImageUrl { get; set; } = string.Empty;
        public string ImageFileExtension { get; set; } = string.Empty;
        public MemoryStream ImageStream { get; set; } = new();
    }
}

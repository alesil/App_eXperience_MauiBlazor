namespace ElginM10MauiBlazor.Services;
internal partial class PrinterService
{
    //Variavel utilizada para a verificação de se a conexão atual é por impressora interna ou não
    public bool isPrinterInternSelected;

    public PrinterService()
    {
        DoConstructor();
    }

    private partial void DoConstructor();

    public partial int PrinterInternalImpStart();
    public partial int PrinterExternalImpStartByIP(string model, string ip, int port);
    public partial int PrinterExternalImpStartByUSB(string model);
    public partial void PrinterStop();
    public partial int AvancaLinhas(int linesNumber);
    public partial void JumpLine();
    public partial int CutPaper(int cut);
    public partial int ImprimeBarCode(Dictionary<string, string> dictionary);
    public partial int ImprimeQR_CODE(Dictionary<string, string> dictionary);
    public partial int ImprimeImagem(Stream bitmapStream, string fileExtension);
    public partial int ImprimeImagemPadrao();
    public partial int ImprimeXMLNFCe(Dictionary<string, object> parametros);
    public partial int ImprimeXMLSAT(Dictionary<string, object> parametros);
    public partial int StatusGaveta();
    public partial int AbrirGaveta();
    public partial int StatusSensorPapel();
    public partial int ImprimeCupomTEF(Dictionary<string, string> dictionary);
    public partial int ImprimeTexto(Dictionary<string, string> dictionary);

    private int CodeOfBarCode(String barCodeName)
    {
        return barCodeName switch
        {
            "UPC-A" => 0,
            "UPC-E" => 1,
            "EAN 13" or "JAN 13" => 2,
            "EAN 8" or "JAN 8" => 3,
            "CODE 39" => 4,
            "ITF" => 5,
            "CODE BAR" => 6,
            "CODE 93" => 7,
            "CODE 128" => 8,
            _ => 0
        };
    }

    #region ==> Chamadas Assíncronas <==

    public async Task<int> PrinterInternalImpStartAsync()
        => await Task.Run(() => PrinterInternalImpStart());
    public async Task<int> PrinterExternalImpStartByIPAsync(string model, string ip, int port)
        => await Task.Run(() => PrinterExternalImpStartByIP(model, ip, port));
    public async Task<int> PrinterExternalImpStartByUSBAsync(string model)
        => await Task.Run(() => PrinterExternalImpStartByUSB(model));
    public async Task PrinterStopAsync()
        => await Task.Run(() => PrinterStop());
    public async Task<int> AvancaLinhasAsync(int linesNumber)
        => await Task.Run(() => AvancaLinhas(linesNumber));
    public async Task JumpLineAsync()
        => await Task.Run(() => JumpLine());
    public async Task<int> CutPaperAsync(int cut)
        => await Task.Run(() => CutPaper(cut));
    public async Task<int> ImprimeBarCodeAsync(Dictionary<string, string> dictionary)
        => await Task.Run(() => ImprimeBarCode(dictionary));
    public async Task<int> ImprimeQR_CODEAsync(Dictionary<string, string> dictionary)
        => await Task.Run(() => ImprimeQR_CODE(dictionary));
    public async Task<int> ImprimeImagemAsync(Stream bitmapStream, string fileExtension)
        => await Task.Run(() => ImprimeImagem(bitmapStream, fileExtension));
    public async Task<int> ImprimeImagemPadraoAsync()
        => await Task.Run(() => ImprimeImagemPadrao());
    public async Task<int> ImprimeXMLNFCeAsync(Dictionary<string, object> parametros)
        => await Task.Run(() => ImprimeXMLNFCe(parametros));
    public async Task<int> ImprimeXMLSATAsync(Dictionary<string, object> parametros)
        => await Task.Run(() => ImprimeXMLSAT(parametros));
    public async Task<int> StatusGavetaAsync()
        => await Task.Run(() => StatusGaveta());
    public async Task<int> AbrirGavetaAsync()
        => await Task.Run(() => AbrirGaveta());
    public async Task<int> StatusSensorPapelAsync()
        => await Task.Run(() => StatusSensorPapel());
    public async Task<int> ImprimeCupomTEFAsync(Dictionary<string, string> dictionary)
        => await Task.Run(() => ImprimeCupomTEF(dictionary));
    public async Task<int> ImprimeTextoAsync(Dictionary<string, string> dictionary)
        => await Task.Run(() => ImprimeTexto(dictionary));

    #endregion ==> Chamadas Assíncronas <==
}

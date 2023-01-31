

using ElginM10MauiBlazor.Services.External.Windows;

using System.Drawing;

namespace ElginM10MauiBlazor.Services;
internal partial class PrinterService
{
    private partial void DoConstructor() { }

    public partial int PrinterInternalImpStart()
    {
        PrinterStop();
        int result = E1Impressora.AbreConexaoImpressora(6, "M8", "", 0); // Conexão para M10
        if (result == 0) isPrinterInternSelected = true;
        return result;
    }
    public partial int PrinterExternalImpStartByIP(string model, string ip, int port)
    {
        PrinterStop();
        try
        {
            int result = E1Impressora.AbreConexaoImpressora(3, model, ip, port);
            if (result == 0) isPrinterInternSelected = false;
            return result;
        }
        catch (Exception)
        {
            return PrinterInternalImpStart();
        }
    }
    public partial int PrinterExternalImpStartByUSB(string model)
    {
        PrinterStop();
        try
        {
            int result = E1Impressora.AbreConexaoImpressora(1, model, "USB", 0);
            if (result == 0) isPrinterInternSelected = false;
            return result;
        }
        catch (Exception)
        {
            return PrinterInternalImpStart();
        }
    }
    public partial void PrinterStop()
    {
        E1Impressora.FechaConexaoImpressora();
    }
    public partial int AvancaLinhas(int linesNumber)
    {
        return E1Impressora.AvancaPapel(linesNumber);
    }
    public partial void JumpLine()
    {
        int quant = 5;
        //Se a impressão for por impressora externa, 5 é o suficiente; 15 caso contrário
        if (isPrinterInternSelected)
        {
            quant = 15;
        }
        AvancaLinhas(quant);
    }
    public partial int CutPaper(int cut)
    {
        return E1Impressora.Corte(cut);
    }
    public partial int ImprimeBarCode(Dictionary<string, string> dictionary)
    {
        int barCodeType = CodeOfBarCode(dictionary["barCodeType"]);
        string text = dictionary["text"];
        int height = int.Parse(dictionary["height"]);
        int width = int.Parse(dictionary["width"]);
        string align = dictionary["align"];

        int hri = 4; // NO PRINT
        int result;

        // ALINHAMENTO VALUE
        int alignValue = align switch
        {
            "Esquerda" => 0,
            "Centralizado" => 1,
            _ => 2
        };

        E1Impressora.DefinePosicao(alignValue);

        result = E1Impressora.ImpressaoCodigoBarras(barCodeType, text, height, width, hri);
        return result;
    }
    public partial int ImprimeQR_CODE(Dictionary<string, string> dictionary)
    {
        int size = int.Parse(dictionary["qrSize"]);
        string text = dictionary["text"];
        string align = dictionary["align"];

        int nivelCorrecao = 2;
        int result;

        // ALINHAMENTO VALUE
        int alignValue = align switch
        {
            "Esquerda" => 0,
            "Centralizado" => 1,
            _ => 2
        };

        E1Impressora.DefinePosicao(alignValue);

        result = E1Impressora.ImpressaoQRCode(text, size, nivelCorrecao);
        return result;
    }
    public partial int ImprimeImagem(Stream bitmapStream, string fileExtension)
    {
        // A função da de impressão de imagem da elgin utiliza arquivo em disco, por isso foi armazenado em uma pasta local e em seguida excluído.
        // Lembrando que a função também faz uso da extensão do arquivo para conseguir imprimir, se passar a extensão incorreta é retornado um erro -9999
        int ret;
        try
        {
            string fileName = Path.Combine(FileSystem.Current.AppDataDirectory, $"{Guid.NewGuid()}{fileExtension}");

            // grava o arquivo temporário da imagem
            using FileStream outputStream = File.OpenWrite(fileName);

            bitmapStream.CopyTo(outputStream);
            outputStream.Close();

            ret = E1Impressora.ImprimeImagem(fileName);

            File.Delete(fileName);

        }
        catch
        {
            ret = -987654321;
        }

        return ret;
    }

    public partial int ImprimeXMLNFCe(Dictionary<string, object> parametros)
    {
        string xml = (string)parametros["xmlNFCe"];
        int indexcsc = (int)parametros["indexcsc"];
        string csc = (string)parametros["csc"];
        int param = (int)parametros["param"];
        return E1Impressora.ImprimeXMLNFCe(xml, indexcsc, csc, param);
    }
    public partial int ImprimeXMLSAT(Dictionary<string, object> parametros)
    {
        string xml = (string)parametros["xmlSAT"];
        int param = (int)parametros["param"];
        return E1Impressora.ImprimeXMLSAT(xml, param);
    }
    public partial int StatusGaveta()
    {
        return E1Impressora.StatusImpressora(1);
    }
    public partial int AbrirGaveta()
    {
        return E1Impressora.AbreGavetaElgin();
    }
    public partial int StatusSensorPapel()
    {
        return E1Impressora.StatusImpressora(3);
    }
    public partial int ImprimeCupomTEF(Dictionary<string, string> dictionary)
    {
        string base64 = dictionary["base64"];
        return E1Impressora.ImprimeCupomTEF(base64);
    }
    public partial int ImprimeTexto(Dictionary<string, string> dictionary)
    {
        string text = dictionary["text"];
        string align = dictionary["align"];
        string font = dictionary["font"];
        int fontSize = int.Parse(dictionary["fontSize"]);
        bool isBold = Convert.ToBoolean(dictionary["isBold"]);
        bool isUnderline = Convert.ToBoolean(dictionary["isUnderline"]);

        int styleValue = 0;

        // ALINHAMENTO VALUE
        int alignValue = align switch
        {
            "Esquerda" => 0,
            "Centralizado" => 1,
            _ => 2
        };

        // ESTILO VALUE
        if (font.Equals("FONT B"))
        {
            styleValue += 1;
        }
        if (isUnderline)
        {
            styleValue += 2;
        }
        if (isBold)
        {
            styleValue += 8;
        }

        int result = E1Impressora.ImpressaoTexto(text, alignValue, styleValue, fontSize);
        return result;
    }
}

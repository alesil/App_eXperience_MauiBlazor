using Android.Graphics;

using Com.Elgin.E1.Impressora;

namespace ElginM10MauiBlazor.Services;
internal partial class PrinterService
{
    private partial void DoConstructor()
    {
        Termica.SetActivity(MainActivity.mContext);
    }

    public partial int PrinterInternalImpStart()
    {
        PrinterStop();
        int result = Termica.AbreConexaoImpressora(6, "M8", "", 0); // Conexão para M10
        if (result == 0) isPrinterInternSelected = true;
        return result;
    }
    public partial int PrinterExternalImpStartByIP(string model, string ip, int port)
    {
        PrinterStop();
        try
        {
            int result = Termica.AbreConexaoImpressora(3, model, ip, port);
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
            int result = Termica.AbreConexaoImpressora(1, model, "USB", 0);
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
        Termica.FechaConexaoImpressora();
    }
    public partial int AvancaLinhas(int linesNumber)
    {
        return Termica.AvancaPapel(linesNumber);
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
        return Termica.Corte(cut);
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

        Termica.DefinePosicao(alignValue);

        result = Termica.ImpressaoCodigoBarras(barCodeType, text, height, width, hri);
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

        Termica.DefinePosicao(alignValue);

        result = Termica.ImpressaoQRCode(text, size, nivelCorrecao);
        return result;
    }

    public partial int ImprimeImagem(Stream bitmapStream, string fileExtension)
    {
        int result;
        Bitmap bmp = BitmapFactory.DecodeStream(bitmapStream);

        result = isPrinterInternSelected
            ? Termica.ImprimeBitmap(bmp)    // método para impressão com impressora interna
            : Termica.ImprimeImagem(bmp);   // método para impressão externa

        return result;
    }

    public partial int ImprimeXMLNFCe(Dictionary<string, object> parametros)
    {
        string xml = (string)parametros["xmlNFCe"];
        int indexcsc = (int)parametros["indexcsc"];
        string csc = (string)parametros["csc"];
        int param = (int)parametros["param"];
        return Termica.ImprimeXMLNFCe(xml, indexcsc, csc, param);
    }
    public partial int ImprimeXMLSAT(Dictionary<string, object> parametros)
    {
        string xml = (string)parametros["xmlSAT"];
        int param = (int)parametros["param"];
        return Termica.ImprimeXMLSAT(xml, param);
    }
    public partial int StatusGaveta()
    {
        return Termica.StatusImpressora(1);
    }
    public partial int AbrirGaveta()
    {
        return Termica.AbreGavetaElgin();
    }
    public partial int StatusSensorPapel()
    {
        return Termica.StatusImpressora(3);
    }
    public partial int ImprimeCupomTEF(Dictionary<string, string> dictionary)
    {
        string base64 = dictionary["base64"];
        return Termica.ImprimeCupomTEF(base64);
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

        int result = Termica.ImpressaoTexto(text, alignValue, styleValue, fontSize);
        return result;
    }
}

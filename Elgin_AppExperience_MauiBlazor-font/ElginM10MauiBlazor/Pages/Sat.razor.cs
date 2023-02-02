using Microsoft.AspNetCore.Components;

using System.Xml.Linq;

namespace ElginM10MauiBlazor.Pages;
public partial class Sat : ComponentBase
{
    [Inject]
    Services.SatService SatService { get; set; }

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
        ShowSpinner();
        _dados.RetornoSat = string.Empty;
        for (int i = 1; i <= 20; i++)
        {
            _dados.RetornoSat += $"Testando várias linhas. Linha {i:000}\n";
        }
        HideSpinner();
    }

    private async Task ConsultarSat()
    {
        ShowSpinner("Consultando SAT...");
        var retornoSat = await SatService.ConsultarSatAsync(SatService.GerarNumeroSessao());
        _dados.RetornoSat = retornoSat.Equals("DeviceNotFound", StringComparison.InvariantCultureIgnoreCase)
            ? "Sat não conectado\nou ocorreu algum problema inesperado."
            : string.Join("\n", DecodificarResultadoPadrao(retornoSat));
        HideSpinner();
    }

    private async Task ConsultarStatusOperacional()
    {
        ShowSpinner("Consultando Status Operacional do SAT...");
        var retornoSat = await SatService.ConsultarStatusOperacionalAsync(SatService.GerarNumeroSessao(), _dados.CodigoAtivacao);
        _dados.RetornoSat = retornoSat.Equals("DeviceNotFound", StringComparison.InvariantCultureIgnoreCase)
            ? "Sat não conectado\nou ocorreu algum problema inesperado."
            : string.Join("\n", DecodificarStatusOperacional(retornoSat));
        HideSpinner();
    }

    private async Task ExtrairLogSat()
    {
        ShowSpinner("Extraindo logs do SAT...");
        var retornoSat = await SatService.ExtrairLogsAsync(SatService.GerarNumeroSessao(), _dados.CodigoAtivacao);
        ShowSpinner("Decodificando logs do SAT...");
        _dados.RetornoSat = retornoSat.Equals("DeviceNotFound", StringComparison.InvariantCultureIgnoreCase)
            ? "Sat não conectado\nou ocorreu algum problema inesperado."
            : string.Join("\n", DecodificarLogs(retornoSat));
        HideSpinner();
    }

    private async Task AtivarSat()
    {
        ShowSpinner("Ativando SAT...");
        var retornoSat = await SatService.AtivarSatAsync(
            SatService.GerarNumeroSessao(),
            certification_type: 2,
            _dados.CodigoAtivacao,
            _dados.CnpjEmitente,
            c_uf: 15); // SP
        _dados.RetornoSat = retornoSat.Equals("DeviceNotFound", StringComparison.InvariantCultureIgnoreCase)
            ? "Sat não conectado\nou ocorreu algum problema inesperado."
            : string.Join("\n", DecodificarResultadoPadrao(retornoSat));
        HideSpinner();
    }

    private async Task RealizarVenda()
    {
        ShowSpinner("Lendo arquivo XML de venda...");
        var conteudoXml = await CarregarArquivoXml("xmlenviadadosvendasat.xml");
        ShowSpinner("Enviando XML de venda ao SAT...");
        var retornoSat = await SatService.EnviarDadosVendaAsync(
            SatService.GerarNumeroSessao(),
            _dados.CodigoAtivacao,
            conteudoXml);
        ShowSpinner("Decodificando venda realizada...");
        _dados.RetornoSat = retornoSat.Equals("DeviceNotFound", StringComparison.InvariantCultureIgnoreCase)
            ? "Sat não conectado\nou ocorreu algum problema inesperado."
            : string.Join("\n", DecodificarVenda(retornoSat));
        HideSpinner();
    }

    private async Task AssociarAssinaturaSat()
    {
        ShowSpinner("Associando assinatura SAT...");
        var retornoSat = await SatService.AssociarAssinaturaAsync(
            SatService.GerarNumeroSessao(),
            _dados.CodigoAtivacao,
            _dados.CnpjSoftwareHouse,
            _dados.AssinaturaAC);
        _dados.RetornoSat = retornoSat.Equals("DeviceNotFound", StringComparison.InvariantCultureIgnoreCase)
            ? "Sat não conectado\nou ocorreu algum problema inesperado."
            : string.Join("\n", DecodificarResultadoPadrao(retornoSat));
        HideSpinner();
    }

    private async Task<string> CarregarArquivoXml(string nomeArquivo)
    {
        try
        {
            using var sourceStream = await FileSystem.OpenAppPackageFileAsync(nomeArquivo);
            if (sourceStream == null) return null;

            using MemoryStream ms = new();
            sourceStream.CopyTo(ms);
            string conteudo = System.Text.Encoding.UTF8.GetString(ms.ToArray());
            return conteudo;
        }
        catch (Exception ex)
        {
            await DialogService.DisplayAlert("Erro ao Carregar Arquivo XML", ex.Message, "OK");
            return null;
        }

    }
    private List<string> DecodificarVenda(string dados)
    {
        List<string> ret = new();
        var aDados = dados.Split('|', StringSplitOptions.TrimEntries);

        int pos = 0;
        ret.Add($"numeroSessao.....: {aDados[pos++]}");
        ret.Add($"EEEEE............: {aDados[pos++]}");
        ret.Add($"CCCC.............: {aDados[pos++]}");
        ret.Add($"mensagem.........: {aDados[pos++]}");
        ret.Add($"cod..............: {aDados[pos++]}");
        ret.Add($"mensagemSEFAZ....: {aDados[pos++]}");

        var xmlCFeSatBase64 = aDados[pos++];

        ret.Add($"timeStamp........: {aDados[pos++]}");
        ret.Add($"chaveConsulta....: {aDados[pos++]}");
        ret.Add($"valorTotalCFe....: {aDados[pos++]}");
        ret.Add($"CPFCNPJValue.....: {aDados[pos++]}");
        ret.Add($"assinaturaQRCODE.: {aDados[pos++]}");

        string xmlCFeSat = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFeSatBase64));
        XDocument doc = XDocument.Parse(xmlCFeSat);
        string formatedXmlCFeSat = doc.ToString();

        ret.Add(string.Empty);
        ret.Add("--- CONTEÚDO DO CFe-SAT ---");
        ret.Add(string.Empty);


        ret.Add(formatedXmlCFeSat);



        return ret;
    }

    private List<string> DecodificarResultadoPadrao(string dados)
    {
        List<string> ret = new();
        var aDados = dados.Split('|', StringSplitOptions.TrimEntries);

        int pos = 0;
        ret.Add($"numeroSessao.....: {aDados[pos++]}");
        ret.Add($"EEEEE............: {aDados[pos++]}");
        ret.Add($"mensagem.........: {aDados[pos++]}");
        ret.Add($"cod..............: {aDados[pos++]}");
        ret.Add($"mensagemSEFAZ....: {aDados[pos++]}");

        return ret;
    }

    private List<string> DecodificarLogs(string dados)
    {
        List<string> ret = new();
        var aDados = dados.Split('|', StringSplitOptions.TrimEntries);

        int pos = 0;
        ret.Add($"numeroSessao.....: {aDados[pos++]}");
        ret.Add($"EEEEE............: {aDados[pos++]}");
        ret.Add($"mensagem.........: {aDados[pos++]}");
        ret.Add($"cod..............: {aDados[pos++]}");
        ret.Add($"mensagemSEFAZ....: {aDados[pos++]}");
        ret.Add(string.Empty);
        ret.Add("--- CONTEÚDO DO LOG ---");
        ret.Add(string.Empty);

        string logBase64 = aDados[pos++];
        string log = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(logBase64));

        ret.Add(log);

        return ret;
    }

    private List<string> DecodificarStatusOperacional(string dados)
    {
        List<string> ret = new();
        var aDados = dados.Split('|', StringSplitOptions.TrimEntries);

        int pos = 0;
        ret.Add($"numeroSessao.....: {aDados[pos++]}");
        ret.Add($"EEEEE............: {aDados[pos++]}");
        ret.Add($"mensagem.........: {aDados[pos++]}");
        ret.Add($"cod..............: {aDados[pos++]}");
        ret.Add($"mensagemSEFAZ....: {aDados[pos++]}");
        ret.Add(string.Empty);
        // -- //
        ret.Add($"NSERIE...........: {aDados[pos++]}");
        ret.Add($"TIPO_LAN.........: {aDados[pos++]}");
        ret.Add($"LAN_IP...........: {aDados[pos++]}");
        ret.Add($"LAN_MAC..........: {aDados[pos++]}");
        ret.Add($"LAN_MASK.........: {aDados[pos++]}");
        ret.Add($"LAN_GW...........: {aDados[pos++]}");
        ret.Add($"LAN_DNS_1........: {aDados[pos++]}");
        ret.Add($"LAN_DNS_2........: {aDados[pos++]}");
        ret.Add($"STATUS_LAN.......: {aDados[pos++]}");
        ret.Add($"NIVEL_BATERIA....: {aDados[pos++]}");
        ret.Add($"MT_TOTAL.........: {aDados[pos++]}");
        ret.Add($"MT_USADA.........: {aDados[pos++]}");
        ret.Add($"DH_ATUAL.........: {aDados[pos++]}");
        ret.Add($"VER_SB...........: {aDados[pos++]}");
        ret.Add($"VER_LAYOUT.......: {aDados[pos++]}");
        ret.Add($"ULTIMO_CF-E-SAT..: {aDados[pos++]}");
        ret.Add($"LISTA_ INICIAL...: {aDados[pos++]}");
        ret.Add($"LISTA_ FINAL.....: {aDados[pos++]}");
        ret.Add($"DH_CFe...........: {aDados[pos++]}");
        ret.Add($"DH_ULTIMA........: {aDados[pos++]}");
        ret.Add($"CERT_EMISSAO.....: {aDados[pos++]}");
        ret.Add($"CERT_VENCIMENTO..: {aDados[pos++]}");

        var estadoOperacao = aDados[pos++];
        var estadoOperacaoDescricao = estadoOperacao switch
        {
            "0" => "DESBLOQUEADO",
            "1" => "BLOQUEIO SEFAZ",
            "2" => "BLOQUEIO CONTRIBUINTE",
            "3" => "BLOQUEIO AUTÔNOMO",
            "4" => "BLOQUEIO PARA DESATIVAÇÃO",
            _ => "N/A"
        };
        ret.Add($"ESTADO_OPERACAO..: {estadoOperacao} ({estadoOperacaoDescricao})");

        return ret;
    }

    private class Dados
    {
        public ModeloSat Modelo { get; set; } = ModeloSat.SmartSat;
        public string CodigoAtivacao { get; set; } = "123456789";
        public string RetornoSat { get; set; } = string.Empty;
        public string CnpjSoftwareHouse { get; set; } = "16716114000172"; // Sat Homologação da Elgin
        public string CnpjEmitente { get; set; } = "14200166000166"; // Sat Homologação da Elgin
        public string AssinaturaAC { get; set; } = "SGR-SAT SISTEMA DE GESTAO E RETAGUARDA DO SAT";
    }

    private enum ModeloSat
    {
        SmartSat,
        SatGo
    }
}

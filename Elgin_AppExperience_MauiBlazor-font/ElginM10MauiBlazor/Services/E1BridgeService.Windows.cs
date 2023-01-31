using ElginM10MauiBlazor.Services.External;

namespace ElginM10MauiBlazor.Services;
internal partial class E1BridgeService
{
       private partial void DoConstructor() { }

    public partial string IniciaVenda(int idTransacao, string pdv, string valorTotal)
        => E1Bridge.IniciaVenda_RetornoDireto(idTransacao, pdv, valorTotal);

    public partial string IniciaVendaDebito(int idTransacao, string pdv, string valorTotal)
        => E1Bridge.IniciaVendaDebito_RetornoDireto(idTransacao, pdv, valorTotal);

    public partial string IniciaVendaCredito(int idTransacao, string pdv, string valorTotal, int tipoFinanciamento, int numParcelas)
        => E1Bridge.IniciaVendaCredito_RetornoDireto(idTransacao, pdv, valorTotal, tipoFinanciamento, numParcelas);

    public partial string IniciaCancelamentoVenda(int idTransacao, string pdv, string valorTotal, string dataHora, string nsu)
        => E1Bridge.IniciaCancelamentoVenda_RetornoDireto(idTransacao, pdv, valorTotal, dataHora, nsu);

    public partial string IniciaOperacaoAdministrativa(int idTransacao, string pvd, int operacao)
        => E1Bridge.IniciaOperacaoAdministrativa_RetornoDireto(idTransacao, pvd, operacao);

    public partial string ImprimirCupomNfce(string xml, int indexcsc, string csc)
        => E1Bridge.ImprimirCupomNfce_RetornoDireto(xml, indexcsc, csc);

    public partial string ImprimirCupomSat(string xml)
        => E1Bridge.ImprimirCupomSat_RetornoDireto(xml);

    public partial string ImprimirCupomSatCancelamento(string xml, string assQRCode)
        => E1Bridge.ImprimirCupomSatCancelamento_RetornoDireto(xml, assQRCode);

    public partial string SetSenha(string senha, bool habilitada)
        => E1Bridge.SetSenha_RetornoDireto(senha, habilitada);

    public partial string ConsultarStatus()
        => E1Bridge.ConsultarStatus_RetornoDireto();

    public partial string GetTimeout()
        => E1Bridge.GetTimeout_RetornoDireto();

    public partial string ConsultarUltimaTransacao(string pdv)
        => E1Bridge.ConsultarUltimaTransacao_RetornoDireto(pdv);

    public partial string SetSenhaServer(string senha, bool habilitada)
        => E1Bridge.SetSenhaServer_RetornoDireto(senha, habilitada);

    public partial string SetTimeout(int timeout)
        => E1Bridge.SetTimeout_RetornoDireto(timeout);

    public partial string GetServer()
        => E1Bridge.GetServer_RetornoDireto();

    public partial string SetServer(string ipTerminal, int portaTransacao, int portaStatus)
        => E1Bridge.SetServer_RetornoDireto(ipTerminal, portaTransacao, portaStatus);
}

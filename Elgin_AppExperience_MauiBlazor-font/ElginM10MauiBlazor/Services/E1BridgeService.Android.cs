using Com.Elgin.E1.Pagamento.Brigde;

namespace ElginM10MauiBlazor.Services;
internal partial class E1BridgeService
{
    private partial void DoConstructor() { }

    public partial string IniciaVenda(int idTransacao, string pdv, string valorTotal)
    {
        return Bridge.IniciaVenda(idTransacao, pdv, valorTotal);
    }

    public partial string IniciaVendaDebito(int idTransacao, string pdv, string valorTotal)
    {
        return Bridge.IniciaVendaDebito(idTransacao, pdv, valorTotal);
    }

    public partial string IniciaVendaCredito(int idTransacao, string pdv, string valorTotal, int tipoFinanciamento, int numParcelas)
    {
        return Bridge.IniciaVendaCredito(idTransacao, pdv, valorTotal, tipoFinanciamento, numParcelas);
    }

    public partial string IniciaCancelamentoVenda(int idTransacao, string pdv, string valorTotal, string dataHora, string nsu)
    {
        return Bridge.IniciaCancelamentoVenda(idTransacao, pdv, valorTotal, dataHora, nsu);
    }

    public partial string IniciaOperacaoAdministrativa(int idTransacao, string pvd, int operacao)
    {
        return Bridge.IniciaOperacaoAdministrativa(idTransacao, pvd, operacao);
    }

    public partial string ImprimirCupomNfce(string xml, int indexcsc, string csc)
    {
        return Bridge.ImprimirCupomNfce(xml, indexcsc, csc);
    }

    public partial string ImprimirCupomSat(string xml)
    {
        return Bridge.ImprimirCupomSat(xml);
    }

    public partial string ImprimirCupomSatCancelamento(string xml, string assQRCode)
    {
        return Bridge.ImprimirCupomSatCancelamento(xml, assQRCode);
    }

    public partial string SetSenha(string senha, bool habilitada)
    {
        return Bridge.SetSenha(senha, habilitada);
    }

    public partial string ConsultarStatus()
    {
        return Bridge.ConsultarStatus();
    }

    public partial string GetTimeout()
    {
        return Bridge.Timeout;
    }

    public partial string ConsultarUltimaTransacao(string pdv)
    {
        return Bridge.ConsultarUltimaTransacao(pdv);
    }

    public partial string SetSenhaServer(string senha, bool habilitada)
    {
        return Bridge.SetSenhaServer(senha, habilitada);
    }

    public partial string SetTimeout(int timeout)
    {
        return Bridge.SetTimeout(timeout);
    }

    public partial string GetServer()
    {
        return Bridge.Server;
    }

    public partial string SetServer(string ipTerminal, int portaTransacao, int portaStatus)
    {
        return Bridge.SetServer(ipTerminal, portaTransacao, portaStatus);
    }
}

namespace ElginM10MauiBlazor.Services;
internal partial class E1BridgeService
{
    public E1BridgeService()
    {
        DoConstructor();
    }

    private partial void DoConstructor();

    public partial string IniciaVenda(int idTransacao, string pdv, string valorTotal);
    public partial string IniciaVendaDebito(int idTransacao, string pdv, string valorTotal);
    public partial string IniciaVendaCredito(int idTransacao, string pdv, string valorTotal, int tipoFinanciamento, int numParcelas);
    public partial string IniciaCancelamentoVenda(int idTransacao, string pdv, string valorTotal, string dataHora, string nsu);
    public partial string IniciaOperacaoAdministrativa(int idTransacao, string pvd, int operacao);
    public partial string ImprimirCupomNfce(string xml, int indexcsc, string csc);
    public partial string ImprimirCupomSat(string xml);
    public partial string ImprimirCupomSatCancelamento(string xml, string assQRCode);
    public partial string SetSenha(string senha, bool habilitada);
    public partial string ConsultarStatus();
    public partial string GetTimeout();
    public partial string ConsultarUltimaTransacao(string pdv);
    public partial string SetSenhaServer(string senha, bool habilitada);
    public partial string SetTimeout(int timeout);
    public partial string GetServer();
    public partial string SetServer(string ipTerminal, int portaTransacao, int portaStatus);


    #region ==> Chamadas Assíncronas <==

    public async Task<string> IniciaVendaAsync(int idTransacao, string pdv, string valorTotal)
        => await Task.Run(() => IniciaVenda(idTransacao, pdv, valorTotal));

    public async Task<string> IniciaVendaDebitoAsync(int idTransacao, string pdv, string valorTotal)
        => await Task.Run(() => IniciaVendaDebito(idTransacao, pdv, valorTotal));

    public async Task<string> IniciaVendaCreditoAsync(int idTransacao, string pdv, string valorTotal, int tipoFinanciamento, int numParcelas)
        => await Task.Run(() => IniciaVendaCredito(idTransacao, pdv, valorTotal, tipoFinanciamento, numParcelas));

    public async Task<string> IniciaCancelamentoVendaAsync(int idTransacao, string pdv, string valorTotal, string dataHora, string nsu)
        => await Task.Run(() => IniciaCancelamentoVenda(idTransacao, pdv, valorTotal, dataHora, nsu));

    public async Task<string> IniciaOperacaoAdministrativaAsync(int idTransacao, string pvd, int operacao)
        => await Task.Run(() => IniciaOperacaoAdministrativa(idTransacao, pvd, operacao));

    public async Task<string> ImprimirCupomNfceAsync(string xml, int indexcsc, string csc)
        => await Task.Run(() => ImprimirCupomNfce(xml, indexcsc, csc));

    public async Task<string> ImprimirCupomSatAsync(string xml)
        => await Task.Run(() => ImprimirCupomSat(xml));

    public async Task<string> ImprimirCupomSatCancelamentoAsync(string xml, string assQRCode)
        => await Task.Run(() => ImprimirCupomSatCancelamento(xml, assQRCode));

    public async Task<string> SetSenhaAsync(string senha, bool habilitada)
        => await Task.Run(() => SetSenha(senha, habilitada));

    public async Task<string> ConsultarStatusAsync()
        => await Task.Run(() => ConsultarStatus());

    public async Task<string> GetTimeoutAsync()
        => await Task.Run(() => GetTimeout());

    public async Task<string> ConsultarUltimaTransacaoAsync(string pdv)
        => await Task.Run(() => ConsultarUltimaTransacao(pdv));

    public async Task<string> SetSenhaServerAsync(string senha, bool habilitada)
        => await Task.Run(() => SetSenhaServer(senha, habilitada));

    public async Task<string> SetTimeoutAsync(int timeout)
        => await Task.Run(() => SetTimeout(timeout));

    public async Task<string> GetServerAsync()
        => await Task.Run(() => GetServer());

    public async Task<string> SetServerAsync(string ipTerminal, int portaTransacao, int portaStatus)
        => await Task.Run(() => SetServer(ipTerminal, portaTransacao, portaStatus));

    #endregion ==> Chamadas Assíncronas <==
}

namespace ElginM10MauiBlazor.Services;
internal partial class SatService
{
    public SatService()
    {
        DoConstructor();
    }

    private partial void DoConstructor();

    internal partial string AssociarAssinatura(int num_session, string activation_code, string cnpj_set, string sign_ac);
    internal partial string AtivarSat(int num_session, int certification_type, string activation_code, string cnpj, int c_uf);
    internal partial string AtualizarSoftwareSat(int num_session, string activation_code);
    internal partial string BloquearSat(int num_session, string activation_code);
    internal partial string CancelarUltimaVenda(int num_session, string activation_code, string key, string cancellation_data);
    internal partial string ComunicarCertificadoIcpbrasil(int num_session, string activation_code, string transaction_data);
    internal partial string ConfigurarInterfaceDeRede(int num_session, string activation_code, string network_config);
    internal partial string ConsultarNumeroSessao(int num_session, string activation_code, int consult);
    internal partial string ConsultarSat(int num_session);
    internal partial string ConsultarStatusOperacional(int num_session, string activation_code);
    internal partial string ConsultarUltimaSessaoFiscal(int num_session, string activation_code);
    internal partial string DesbloquearSat(int num_session, string activation_code);
    internal partial string EnviarDadosVenda(int num_session, string activation_code, string transaction_data);
    internal partial string ExtrairLogs(int num_session, string activation_code);
    internal partial int GerarNumeroSessao();
    internal partial string TesteFimAFim(int num_session, string activation_code, string transaction_data);
    internal partial string TrocarCodigoDeAtivacao(int num_session, string current_activation_code, int option, string new_code, string new_code_confirmation);


    #region ==> Chamadas Assíncronas <==


    internal async Task<string> AssociarAssinaturaAsync(int num_session, string activation_code, string cnpj_set, string sign_ac)
        => await Task.Run(() => AssociarAssinatura(num_session, activation_code, cnpj_set, sign_ac));
    internal async Task<string> AtivarSatAsync(int num_session, int certification_type, string activation_code, string cnpj, int c_uf)
        => await Task.Run(() => AtivarSat(num_session, certification_type, activation_code, cnpj, c_uf));
    internal async Task<string> AtualizarSoftwareSatAsync(int num_session, string activation_code)
        => await Task.Run(() => AtualizarSoftwareSat(num_session, activation_code));
    internal async Task<string> BloquearSatAsync(int num_session, string activation_code)
        => await Task.Run(() => BloquearSat(num_session, activation_code));
    internal async Task<string> CancelarUltimaVendaAsync(int num_session, string activation_code, string key, string cancellation_data)
        => await Task.Run(() => CancelarUltimaVenda(num_session, activation_code, key, cancellation_data));
    internal async Task<string> ComunicarCertificadoIcpbrasilAsync(int num_session, string activation_code, string transaction_data)
        => await Task.Run(() => ComunicarCertificadoIcpbrasil(num_session, activation_code, transaction_data));
    internal async Task<string> ConfigurarInterfaceDeRedeAsync(int num_session, string activation_code, string network_config)
        => await Task.Run(() => ConfigurarInterfaceDeRede(num_session, activation_code, network_config));
    internal async Task<string> ConsultarNumeroSessaoAsync(int num_session, string activation_code, int consult)
        => await Task.Run(() => ConsultarNumeroSessao(num_session, activation_code, consult));
    internal async Task<string> ConsultarSatAsync(int num_session)
        => await Task.Run(() => ConsultarSat(num_session));
    internal async Task<string> ConsultarStatusOperacionalAsync(int num_session, string activation_code)
        => await Task.Run(() => ConsultarStatusOperacional(num_session, activation_code));
    internal async Task<string> ConsultarUltimaSessaoFiscalAsync(int num_session, string activation_code)
        => await Task.Run(() => ConsultarUltimaSessaoFiscal(num_session, activation_code));
    internal async Task<string> DesbloquearSatAsync(int num_session, string activation_code)
        => await Task.Run(() => DesbloquearSat(num_session, activation_code));
    internal async Task<string> EnviarDadosVendaAsync(int num_session, string activation_code, string transaction_data)
        => await Task.Run(() => EnviarDadosVenda(num_session, activation_code, transaction_data));
    internal async Task<string> ExtrairLogsAsync(int num_session, string activation_code)
        => await Task.Run(() => ExtrairLogs(num_session, activation_code));
    internal async Task<int> GerarNumeroSessaoAsync()
        => await Task.Run(() => GerarNumeroSessao());
    internal async Task<string> TesteFimAFimAsync(int num_session, string activation_code, string transaction_data)
        => await Task.Run(() => TesteFimAFim(num_session, activation_code, transaction_data));
    internal async Task<string> TrocarCodigoDeAtivacaoAsync(int num_session, string current_activation_code, int option, string new_code, string new_code_confirmation)
        => await Task.Run(() => TrocarCodigoDeAtivacao(num_session, current_activation_code, option, new_code, new_code_confirmation));


    #endregion ==> Chamadas Assíncronas <==

}

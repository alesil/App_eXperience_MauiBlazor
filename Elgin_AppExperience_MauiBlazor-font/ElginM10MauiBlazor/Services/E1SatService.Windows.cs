namespace ElginM10MauiBlazor.Services;
internal partial class E1SatService
{
    private partial void DoConstructor() { }

    internal partial string AssociarAssinatura(int num_session, string activation_code, string cnpj_set, string sign_ac) => throw new NotImplementedException();
    internal partial string AtivarSat(int num_session, int certification_type, string activation_code, string cnpj, int c_uf) => throw new NotImplementedException();
    internal partial string AtualizarSoftwareSat(int num_session, string activation_code) => throw new NotImplementedException();
    internal partial string BloquearSat(int num_session, string activation_code) => throw new NotImplementedException();
    internal partial string CancelarUltimaVenda(int num_session, string activation_code, string key, string cancellation_data) => throw new NotImplementedException();
    internal partial string ConfigurarInterfaceDeRede(int num_session, string activation_code, string network_config) => throw new NotImplementedException();
    internal partial string ConsultarNumeroSessao(int num_session, string activation_code, int consult) => throw new NotImplementedException();
    internal partial string ConsultarSat(int num_session) => throw new NotImplementedException();
    internal partial string ConsultarStatusOperacional(int num_session, string activation_code) => throw new NotImplementedException();
    internal partial string ConsultarUltimaSessaoFiscal(int num_session, string activation_code) => throw new NotImplementedException();
    internal partial string DesbloquearSat(int num_session, string activation_code) => throw new NotImplementedException();
    internal partial string EnviarDadosVenda(int num_session, string activation_code, string transaction_data) => throw new NotImplementedException();
    internal partial string ExtrairLogs(int num_session, string activation_code) => throw new NotImplementedException();
    internal partial int GerarNumeroSessao() => new Random().Next(1, 999_999);
    internal partial string TesteFimAFim(int num_session, string activation_code, string transaction_data) => throw new NotImplementedException();
    internal partial string TrocarCodigoDeAtivacao(int num_session, string current_activation_code, int option, string new_code, string new_code_confirmation) => throw new NotImplementedException();
}

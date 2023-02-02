using BR.Com.Elgin;

namespace ElginM10MauiBlazor.Services;
internal partial class SatService
{
    private partial void DoConstructor() { }

    internal partial string AssociarAssinatura(int num_session, string activation_code, string cnpj_set, string sign_ac) => Sat.AssociarAssinatura(num_session, activation_code, cnpj_set, sign_ac);
    internal partial string AtivarSat(int num_session, int certification_type, string activation_code, string cnpj, int c_uf) => Sat.AtivarSat(num_session, certification_type, activation_code, cnpj, c_uf);
    internal partial string AtualizarSoftwareSat(int num_session, string activation_code) => Sat.AtualizarSoftwareSat(num_session, activation_code);
    internal partial string BloquearSat(int num_session, string activation_code) => Sat.BloquearSat(num_session, activation_code);
    internal partial string CancelarUltimaVenda(int num_session, string activation_code, string key, string cancellation_data) => Sat.CancelarUltimaVenda(num_session, activation_code, key, cancellation_data);
    internal partial string ComunicarCertificadoIcpbrasil(int num_session, string activation_code, string transaction_data) => Sat.ComunicarCertificadoIcpbrasil(num_session, activation_code, transaction_data);
    internal partial string ConfigurarInterfaceDeRede(int num_session, string activation_code, string network_config) => Sat.ConfigurarInterfaceDeRede(num_session, activation_code, network_config);
    internal partial string ConsultarNumeroSessao(int num_session, string activation_code, int consult) => Sat.ConsultarNumeroSessao(num_session, activation_code, consult);
    internal partial string ConsultarSat(int num_session) => Sat.ConsultarSat(num_session);
    internal partial string ConsultarStatusOperacional(int num_session, string activation_code) => Sat.ConsultarStatusOperacional(num_session, activation_code);
    internal partial string ConsultarUltimaSessaoFiscal(int num_session, string activation_code) => Sat.ConsultarUltimaSessaoFiscal(num_session, activation_code);
    internal partial string DesbloquearSat(int num_session, string activation_code) => Sat.DesbloquearSat(num_session, activation_code);
    internal partial string EnviarDadosVenda(int num_session, string activation_code, string transaction_data) => Sat.EnviarDadosVenda(num_session, activation_code, transaction_data);
    internal partial string ExtrairLogs(int num_session, string activation_code) => Sat.ExtrairLogs(num_session, activation_code);
    internal partial int GerarNumeroSessao() => Sat.GerarNumeroSessao();
    internal partial string TesteFimAFim(int num_session, string activation_code, string transaction_data) => Sat.TesteFimAFim(num_session, activation_code, transaction_data);
    internal partial string TrocarCodigoDeAtivacao(int num_session, string current_activation_code, int option, string new_code, string new_code_confirmation) => Sat.TrocarCodigoDeAtivacao(num_session, current_activation_code, option, new_code, new_code_confirmation);
}

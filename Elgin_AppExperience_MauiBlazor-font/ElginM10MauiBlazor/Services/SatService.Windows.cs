using ElginM10MauiBlazor.Services.External.Windows;

using System.Runtime.InteropServices;

namespace ElginM10MauiBlazor.Services;
internal partial class SatService
{
    private partial void DoConstructor() { }

        // => Marshal.PtrToStringUTF8(Sat.ConsultarSAT(num_session));

    internal partial string AssociarAssinatura(int num_session, string activation_code, string cnpj_set, string sign_ac) => Marshal.PtrToStringUTF8(Sat.AssociarAssinatura(num_session, activation_code, cnpj_set, sign_ac));
    internal partial string AtivarSat(int num_session, int certification_type, string activation_code, string cnpj, int c_uf) => Marshal.PtrToStringUTF8(Sat.AtivarSAT(num_session, certification_type, activation_code, cnpj, c_uf));
    internal partial string AtualizarSoftwareSat(int num_session, string activation_code) => Marshal.PtrToStringUTF8(Sat.AtualizarSoftwareSAT(num_session, activation_code));
    internal partial string BloquearSat(int num_session, string activation_code) => Marshal.PtrToStringUTF8(Sat.BloquearSAT(num_session, activation_code));
    internal partial string CancelarUltimaVenda(int num_session, string activation_code, string key, string cancellation_data) => Marshal.PtrToStringUTF8(Sat.CancelarUltimaVenda(num_session, activation_code, key, cancellation_data));
    internal partial string ComunicarCertificadoIcpbrasil(int num_session, string activation_code, string transaction_data) => Marshal.PtrToStringUTF8(Sat.ComunicarCertificadoICPBRASIL(num_session, activation_code, transaction_data));
    internal partial string ConfigurarInterfaceDeRede(int num_session, string activation_code, string network_config) => Marshal.PtrToStringUTF8(Sat.ConfigurarInterfaceDeRede(num_session, activation_code, network_config));
    internal partial string ConsultarNumeroSessao(int num_session, string activation_code, int consult) => Marshal.PtrToStringUTF8(Sat.ConsultarNumeroSessao(num_session, activation_code, consult));
    internal partial string ConsultarSat(int num_session) => Marshal.PtrToStringUTF8(Sat.ConsultarSAT(num_session));
    internal partial string ConsultarStatusOperacional(int num_session, string activation_code) => Marshal.PtrToStringUTF8(Sat.ConsultarStatusOperacional(num_session, activation_code));
    internal partial string ConsultarUltimaSessaoFiscal(int num_session, string activation_code) => throw new NotImplementedException();
    internal partial string DesbloquearSat(int num_session, string activation_code) => Marshal.PtrToStringUTF8(Sat.DesbloquearSAT(num_session, activation_code));
    internal partial string EnviarDadosVenda(int num_session, string activation_code, string transaction_data) => Marshal.PtrToStringUTF8(Sat.EnviarDadosVenda(num_session, activation_code, transaction_data));
    internal partial string ExtrairLogs(int num_session, string activation_code) => Marshal.PtrToStringUTF8(Sat.ExtrairLogs(num_session, activation_code));
    internal partial int GerarNumeroSessao() => new Random().Next(1, 999_999);
    internal partial string TesteFimAFim(int num_session, string activation_code, string transaction_data) => Marshal.PtrToStringUTF8(Sat.TesteFimAFim(num_session, activation_code, transaction_data));
    internal partial string TrocarCodigoDeAtivacao(int num_session, string current_activation_code, int option, string new_code, string new_code_confirmation) => Marshal.PtrToStringUTF8(Sat.TrocarCodigoDeAtivacao(num_session, current_activation_code, option, new_code, new_code_confirmation));

}

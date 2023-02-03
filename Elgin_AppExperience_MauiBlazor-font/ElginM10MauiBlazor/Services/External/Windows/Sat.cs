using System.Runtime.InteropServices;

namespace ElginM10MauiBlazor.Services.External.Windows;
internal class Sat
{
    public const string DLL = @"Platforms\Windows\Library\dllsat.dll";


    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr ConsultarStatusOperacional(int sessao, string cod);


    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr EnviarDadosVenda(int sessao, string cod, string dados);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr CancelarUltimaVenda(int sessao, string cod, string chave, string dadoscancel);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr TesteFimAFim(int sessao, string cod, string dados);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr ConsultarSAT(int sessao);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr ConsultarNumeroSessao(int sessao, string cod, int sessao_a_ser_consultada);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr AtivarSAT(int sessao, int tipoCert, string cod_Ativacao, string cnpj, int uf);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr ComunicarCertificadoICPBRASIL(int sessao, string cod, string csr);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr ConfigurarInterfaceDeRede(int sessao, string cod, string xmlConfig);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr AssociarAssinatura(int sessao, string cod, string cnpj, string sign_cnpj);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr DesbloquearSAT(int sessao, string cod_ativacao);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr BloquearSAT(int sessao, string cod_ativacao);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr TrocarCodigoDeAtivacao(int sessao, string cod_ativacao, int opcao, string nova_senha, string conf_senha);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr ExtrairLogs(int sessao, string cod_ativacao);

    [DllImport(DLL, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr AtualizarSoftwareSAT(int sessao, string cod_ativacao);
}

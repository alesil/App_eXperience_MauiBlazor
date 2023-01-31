/* *** *** *** *** *** */
/*  Platform WINDOWS   */
/* *** *** *** *** *** */

using System.Runtime.InteropServices;

namespace ElginM10MauiBlazor.Services.External;
internal class E1Bridge
{
    public const string DLL = @"Platforms\Windows\Library\E1_Bridge01_x64.dll";

    #region Retorno Direto

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetServer();
        /// <summary>
        /// Função utilizada para obter configuração do servidor
        /// </summary>
        /// <returns>string no formato json Exemplo: 
        /// {"e1_bridge_code":0,"e1_bridge_msg":"192.168.0.1|3000|3001"}</returns>
        public static string GetServer_RetornoDireto()
        {
            return Marshal.PtrToStringAnsi(GetServer());
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr SetServer(String ipTerminal, int portaTransacao, int portaStatus);
        /// <summary>
        /// Configura servidor onde serão processadas as transações.
        /// </summary>
        /// <param name="ipTerminal">IP do terminal SmartPOS onde o APP E1_Bridge esta em execução. Exemplo: 192.168.0.10</param>
        /// <param name="portaTransacao">Identificação da porta de comunicação. A porta padrão é 3000. 
        /// O valor deve ser entre 0 e 65535, onde 0 será para definir com o valor padrão de 3000.</param>
        /// <param name="portaStatus">Identificação da porta onde serão obtido o status das transações. A porta padrão é 3001. 
        /// O valor deve ser entre 0 e 65535, onde 0 será para definir com o valor padrão de 3001.</param>
        /// <returns>string no formato json Exemplo: 
        /// {"e1_bridge_code":0,"e1_bridge_msg":"Sucesso"}</returns>
        public static string SetServer_RetornoDireto(String ipTerminal, int portaTransacao, int portaStatus)
        {
            return Marshal.PtrToStringAnsi(SetServer(ipTerminal, portaTransacao, portaStatus));
        }
        
        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr SetSenha(String senha, bool habilitada);
        /// <summary>
        /// Configura as senhas que a dll vai enviar para o terminal para as transações.
        /// </summary>
        /// <param name="senha">Senha configurada pelo usuário.</param>
        /// <param name="habilitada">boolean para saber se a senha vai estar habilitada ou não. 
        /// Ou seja se a senha será enviada para comunicar ou não.</param>
        /// <returns>string no formato json Exemplo: 
        /// {"e1_bridge_code":0,"e1_bridge_msg":"Sucesso"}</returns>
        public static string SetSenha_RetornoDireto(String senha, bool habilitada)
        {
            return Marshal.PtrToStringAnsi(SetSenha(senha, habilitada));
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetTimeout();
        /// <summary>
        /// Obtem o timeout definido para as transações em segundos; 
        /// O valor padrão é de 180 segundos(3 minutos);
        /// </summary>
        /// <returns>string no formato json Exemplo: 
        /// {"e1_bridge_code":0,"e1_bridge_msg":"180000"}</returns>
        public static string GetTimeout_RetornoDireto()
        {
            return Marshal.PtrToStringAnsi(GetTimeout());
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr SetTimeout(Int32 timeout);
        /// <summary>
        /// Configura um timeout para as funções de transação. 
        /// O valor padrão é de 180 segundos(3 minutos);
        /// </summary>
        /// <param name="timeout">Valor em segundos a ser definido.</param>
        /// <returns>string no formato json Exemplo: 
        /// {"e1_bridge_code":0,"e1_bridge_msg":"Sucesso"}</returns>
        public static string SetTimeout_RetornoDireto(Int32 timeout)
        {
            return Marshal.PtrToStringAnsi(SetTimeout(timeout));
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr ConsultarStatus();
        /// <summary>
        /// Obtém o status do terminal SmartPOS. 
        /// Essa função disponibiliza o status de transação e de tela.
        /// </summary>
        /// <returns>String no formato JSON. Exemplo: 
        /// {"e1_bridge_code":2,"e1_bridge_msg":"Terminal livre|Tela bloqueada"} 
        /// Essa função trabalha com os bits de um inteiro positivo para indicar o status. 
        /// Conforme descrição: 
        /// 0: LIGADO - Indica terminal ocupado, 
        /// 0: DESLIGADO - Indica terminal livre,  
        /// 1: LIGADO - Indica tela bloqueada, 
        /// 1: DESLIGADO - Indica tela desbloqueada. 
        /// Consulte Códigos de erro para mais informações.</returns>
        public static string ConsultarStatus_RetornoDireto()
        {
            return Marshal.PtrToStringAnsi(ConsultarStatus());
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]        
        private static extern IntPtr ConsultarUltimaTransacao(String pdv);
        /// <summary>
        /// Retorna ultima transação processada pelo terminal. Deve ser utilizada casos de timeout.
        /// </summary>
        /// <param name="pdv">Identificação do PDV utilizada nas transações.</param>
        /// <returns>string no formato json. 
        /// Consulte a sessão retorno para ter um exemplo de um json de saída e todos os dados.</returns>
        public static string ConsultarUltimaTransacao_RetornoDireto(String pdv)
        {
            return Marshal.PtrToStringAnsi(ConsultarUltimaTransacao(pdv));
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr ImprimirCupomSat(String xml);
        /// <summary>
        /// Imprimir Cupom Sat de acordo com a especificação da Sefaz para bobina de 55mm.
        /// Observação: Essa Função pode ser usada para impressão de Danfe do MFe(Ceará).
        /// </summary>
        /// <param name="xml">Dados do XML retornado da operação de venda do SAT.</param>
        /// <returns>string no formato json Exemplo: 
        /// {"e1_bridge_code":0,"e1_bridge_msg":"Sucesso"}</returns>
        public static string ImprimirCupomSat_RetornoDireto(String xml)
        {
            return Marshal.PtrToStringAnsi(ImprimirCupomSat(xml));
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr ImprimirCupomSatCancelamento(String xml, String assQRCode);
        /// <summary>
        /// Imprimir Cupom de cancelamento SAT de acordo com a especificação da Sefaz para bobina de 55mm.
        /// Observação: Essa Função pode ser usada para impressão de Danfe do MFe(Ceará).
        /// </summary>
        /// <param name="xml">Dados do XML retornado da operação de cancelamento do SAT.</param>
        /// <param name="assQRCode">Assinatura do QRcode retornado na venda cancelada.</param>
        /// <returns>string no formato json Exemplo: 
        /// {"e1_bridge_code":0,"e1_bridge_msg":"Sucesso"}</returns>
        public static string ImprimirCupomSatCancelamento_RetornoDireto(String xml, String assQRCode)
        {
            return Marshal.PtrToStringAnsi(ImprimirCupomSatCancelamento(xml, assQRCode));
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr ImprimirCupomNfce(String xml, Int32 indexcsc, String csc);
        /// <summary>
        /// Imprimir Cupom NFCe de acordo com a especificação da Sefaz para bobina de 55mm.
        /// </summary>
        /// <param name="xml">Dados do XML retornado da operação de venda nfce.</param>
        /// <param name="indexcsc">Identificador do CSC (Código de Segurança do Contribuinte no Banco de Dados da SEFAZ).
        /// Deve ser informado sem os “0” (zeros) não significativos. A identificação do CSC corresponde à ordem do CSC no banco de dados da SEFAZ, não confundir com o próprio CSC.</param>
        /// <param name="csc">Código de Segurança do Contribuinte. 
        /// Corresponde a um código de segurança alfanumérico (16 a 36 bytes) de conhecimento apenas da Secretaria da Fazenda da Unidade Federada do emitente e do próprio contribuinte.Anteriormente, o código de segurança CSC era chamado de “Token”.</param>
        /// <returns>string no formato json Exemplo: 
        /// {"e1_bridge_code":0,"e1_bridge_msg":"Sucesso"}</returns>
        public static string ImprimirCupomNfce_RetornoDireto(String xml, Int32 indexcsc, String csc)
        {
            return Marshal.PtrToStringAnsi(ImprimirCupomNfce(xml, indexcsc, csc));
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr SetSenhaServer(String senha, bool habilitada);
        /// <summary>
        /// configura a senha do terminal remotamente.
        /// </summary>
        /// <param name="senha">senha configurada pelo usuário</param>
        /// <param name="habilitada">booleano que configura se a senha vai ser ativada no servidor ou não.
        /// Se for true vai ser verificado as senhas que recebem as transações 
        /// e se for false significa que vai ter uma senha que não vai estar em uso,
        /// portanto qualquer transação que chegar no terminal vai ser aceito direto</param>
        /// <returns>string no formato json Exemplo: 
        /// {"e1_bridge_code":0,"e1_bridge_msg":"Sucesso"}</returns>
        public static string SetSenhaServer_RetornoDireto(String senha, bool habilitada)
        {
            return Marshal.PtrToStringAnsi(SetSenhaServer(senha, habilitada));
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr IniciaVenda(Int32 idTransacao, String pdv, String valorTotal);
        /// <summary>
        /// Inicia um operação de venda. 
        /// O tipo da operação será definido pelo operador como débito ou crédito.
        /// </summary>
        /// <param name="idTransacao">Código númerico gerenciado pelo PDV para identificar uma transação. Valor entre 0 e 999999.</param>
        /// <param name="pdv">Código identificador do PDV. Valor alfanumérico.</param>
        /// <param name="valorTotal">Valor total da venda em centavos, ex: 100 para venda de R$1,00.</param>
        /// <returns>String no formato Json com os dados da transação; Consulte a sessão retorno para ter um exemplo de um json de saída e todos os dados.</returns>
        public static string IniciaVenda_RetornoDireto(Int32 idTransacao, String pdv, String valorTotal)
        {
            return Marshal.PtrToStringAnsi(IniciaVenda(idTransacao, pdv, valorTotal));
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr IniciaVendaDebito(Int32 idTransacao, String pdv, String valorTotal);
        /// <summary>
        /// Inicia uma venda no débito.
        /// </summary>
        /// <param name="idTransacao">Código númerico gerenciado pelo PDV para identificar uma transação. Valor entre 0 e 999999.</param>
        /// <param name="pdv">Código identificador do PDV. Valor alfanumérico.</param>
        /// <param name="valorTotal">Valor total da venda em centavos, ex: 100 para venda de R$1,00.</param>
        /// <returns>String no formato Json com os dados da transação; Consulte a sessão retorno para ter um exemplo de um json de saída e todos os dados.</returns>
        public static string IniciaVendaDebito_RetornoDireto(Int32 idTransacao, String pdv, String valorTotal)
        {
            return Marshal.PtrToStringAnsi(IniciaVendaDebito(idTransacao, pdv, valorTotal));
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr IniciaVendaCredito(Int32 idTransacao, String pdv, String valorTotal, Int32 tipoFinanciamento, Int32 numParcelas);
        /// <summary>
        /// Inicia Venda no Crédito.
        /// </summary>
        /// <param name="idTransacao">Código númerico gerenciado pelo PDV para identificar uma transação. Valor entre 0 e 999999.</param>
        /// <param name="pdv">Código identificador do PDV. Valor alfanumérico.</param>
        /// <param name="valorTotal">Valor total da venda em centavos, ex: 100 para venda de R$1,00.</param>
        /// <param name="tipoFinanciamento">Tipo do financiamento (A vista = 1, parcelado emissor = 2 ou parcelado estabelecimento = 3).</param>
        /// <param name="numParcelas">Quantidade de parcelas para as transações parcelada. Para transação a vista o valor sera desconsiderado.</param>
        /// <returns>String no formato Json com os dados da transação; Consulte a sessão retorno para ter um exemplo de um json de saída e todos os dados.</returns>
        public static string IniciaVendaCredito_RetornoDireto(Int32 idTransacao, String pdv, String valorTotal, Int32 tipoFinanciamento, Int32 numParcelas)
        {
            return Marshal.PtrToStringAnsi(IniciaVendaCredito(idTransacao, pdv, valorTotal, tipoFinanciamento, numParcelas));
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr IniciaCancelamentoVenda(Int32 idTransacao, String pdv, String valorTotal, String dataHora, String nsu);
        /// <summary>
        /// Inicia um cancelamento de venda.
        /// </summary>
        /// <param name="idTransacao">Código númerico gerenciado pelo PDV para identificar uma transação. Valor entre 0 e 999999.</param>
        /// <param name="pdv">Código identificador do PDV. Valor alfanumérico.</param>
        /// <param name="valorTotal">Valor total da venda em centavos, ex: 100 para venda de R$1,00.</param>
        /// <param name="dataHora">Data e hora da transação no formato dd/MM/yyyy HH:mm:ss ou dd/MM/yyyy. 
        /// Este valor é retornado no JSON das vendas na chave dataHoraTransacao.</param>
        /// <param name="nsu"></param>
        /// <returns>String no formato Json com os dados da transação; Consulte a sessão retorno para ter um exemplo de um json de saída e todos os dados.</returns>
        public static string IniciaCancelamentoVenda_RetornoDireto(Int32 idTransacao, String pdv, String valorTotal, String dataHora, String nsu)
        {
            return Marshal.PtrToStringAnsi(IniciaCancelamentoVenda(idTransacao, pdv, valorTotal, dataHora, nsu));
        }

        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr IniciaOperacaoAdministrativa(Int32 idTransacao, String pdv, Int32 operacao);
        /// <summary>
        /// Inicia uma operação administrativa.
        /// </summary>
        /// <param name="idTransacao">Código númerico gerenciado pelo PDV para identificar uma transação. Valor entre 0 e 999999.</param>
        /// <param name="pdv">Código identificador do PDV. Valor alfanumérico.</param>
        /// <param name="operacao">Informa a operação a ser realizada. Operações disponiveis são:
        /// Operação administrativa = 0, 
        /// Operação de instalação = 1, 
        /// Operação de configuração = 2, 
        /// Operação de manutenção = 3, 
        /// Teste de comunicação = 4, 
        /// Operação de reimpressão de comprovante = 5.
        /// </param>
        /// <returns>String no formato Json com os dados da transação; Consulte a sessão retorno para ter um exemplo de um json de saída e todos os dados.</returns>
        public static string IniciaOperacaoAdministrativa_RetornoDireto(Int32 idTransacao, String pdv, Int32 operacao)
        {
            return Marshal.PtrToStringAnsi(IniciaOperacaoAdministrativa(idTransacao, pdv, operacao));
        }

        #endregion


}

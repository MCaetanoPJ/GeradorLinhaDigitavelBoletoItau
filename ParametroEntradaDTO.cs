using System;

namespace GeradorLinhaDigitavelBoletoItau
{
    public class ParametroEntrada
    {
        public int CdBanco { get; set; }
        public string DsCodigoBanco { get; set; }
        public string DsCodigoAgencia { get; set; }
        public int CdCedente { get; set; }
        public int NrAgencia { get; set; }
        public int? CdContaCorrente { get; set; }
        public int NrContaCorrente { get; set; }
        public int CdNossoNumero { get; set; }
        public char SnCobrancaRegistrada { get; set; }
        public int CdConvenioCobranca { get; set; }
        public DateTime DtVencimento { get; set; }
        public double VlMensalidade { get; set; }
        public double CfValorBruto { get; set; }
        public int CdCarteira { get; set; }
        public int CdMensContrato { get; set; }
        public char TpProcessCb { get; set; }
    }
}

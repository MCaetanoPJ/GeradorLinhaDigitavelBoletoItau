using System.Text;

namespace GeradorLinhaDigitavelBoletoItau
{
    public class LogicaItau
    {
        public static StringBuilder GerarLinhaDigitavelItau_Console(ParametroEntrada dadosEntrada)
        {
            try
            {
                dadosEntrada.TpProcessCb = 'A';

                //Verifica se o código do banco pertence ao Itaú
                if (dadosEntrada.CdBanco.Equals(341))
                {
                    return Itau_cfLinhaDigitavelformula(dadosEntrada);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static StringBuilder GerarLinhaDigitavelItau_DadosMocados()
        {
            try
            {
                var dadosMocados = new ParametroEntrada()
                {
                    CdBanco = 341,//Código do Itaú
                    DsCodigoBanco = "020",

                    NrAgencia = 1234,//Limitado a 4 caracteres
                    DsCodigoAgencia = "4321",
                    CdContaCorrente = 9,
                    NrContaCorrente = 54321,//Limitado a 5 caracteres

                    CdCarteira = 109,
                    
                    CdCedente = 13,
                    CdConvenioCobranca = 38,

                    CdMensContrato = 100,
                    CdNossoNumero = 234,
                    
                    DtVencimento = Convert.ToDateTime("07/02/2022"),
                    SnCobrancaRegistrada = 'A',
                    TpProcessCb = 'A',
                    VlMensalidade = 3000,

                    CfValorBruto = 4000
                };

                return Itau_cfLinhaDigitavelformula(dadosMocados);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private static StringBuilder Itau_cfLinhaDigitavelformula(ParametroEntrada dadosEntrada)
        {
            try
            {
                var vprimeirocampo = new StringBuilder();
                var vsegundocampo = new StringBuilder();
                var vterceirocampo = new StringBuilder();
                var vquartocampo = new StringBuilder();
                var vquintocampo = new StringBuilder();

                // BANCO ITAÚ
                vprimeirocampo = vprimeirocampo.Append("3419").Append(MetodosJavaToCSharp.Substring(Itau_cfCampoLivreformula(dadosEntrada).ToString(), MetodosJavaToCSharp.ToInt(1), MetodosJavaToCSharp.ToInt(5)));

                vprimeirocampo = vprimeirocampo.Append(Itau_fnModulo10(vprimeirocampo));

                //TODO: Lembrar de conferir a quantidade de casas que deve ser exibida
                //vprimeirocampo = MetodosJavaToCSharp.Substring(vprimeirocampo.ToString(),MetodosJavaToCSharp.ToInt(1),MetodosJavaToCSharp.ToInt(5))
                //    .Append(".")
                //    .Append(MetodosJavaToCSharp.Substring(vprimeirocampo.ToString(),MetodosJavaToCSharp.ToInt(6)
                //    )
                //);


                // Montagem do Segundo Campo
                vsegundocampo.Clear();
                vsegundocampo = vsegundocampo.Append(MetodosJavaToCSharp.Substring(Itau_cfCampoLivreformula(dadosEntrada).ToString(),
                    MetodosJavaToCSharp.ToInt(6), MetodosJavaToCSharp.ToInt(10)));

                vsegundocampo = vsegundocampo.Append(Itau_fnModulo10(vsegundocampo));
                vsegundocampo = MetodosJavaToCSharp.Substring(vsegundocampo.ToString(), MetodosJavaToCSharp.ToInt(1), MetodosJavaToCSharp.ToInt(5))
                .Append(".").Append(MetodosJavaToCSharp.Substring(vsegundocampo.ToString(), MetodosJavaToCSharp.ToInt(6)));


                // Montagem do Terceiro Campo
                vterceirocampo.Clear();
                vterceirocampo = vterceirocampo.Append(MetodosJavaToCSharp.Substring(Itau_cfCampoLivreformula(dadosEntrada).ToString(),
                    MetodosJavaToCSharp.ToInt(16), MetodosJavaToCSharp.ToInt(10)));

                vterceirocampo = vterceirocampo.Append(Itau_fnModulo10(vterceirocampo));

                vterceirocampo = MetodosJavaToCSharp.Substring(vterceirocampo.ToString(), MetodosJavaToCSharp.ToInt(1), MetodosJavaToCSharp.ToInt(5)).Append(
                ".").Append(MetodosJavaToCSharp.Substring(vterceirocampo.ToString(), MetodosJavaToCSharp.ToInt(6)));


                // Montagem do Quarto Campo
                vquartocampo = MetodosJavaToCSharp.Substring(Itau_cfBarraformula(dadosEntrada).ToString(), MetodosJavaToCSharp.ToInt(5), MetodosJavaToCSharp.ToInt(1));


                // Montagem do Quinto Campo
                vquintocampo = MetodosJavaToCSharp.Substring(Itau_cfBarraformula(dadosEntrada).ToString(), MetodosJavaToCSharp.ToInt(6), MetodosJavaToCSharp.ToInt(4)).Append(
                        MetodosJavaToCSharp.Substring(Itau_cfBarraformula(dadosEntrada).ToString(), MetodosJavaToCSharp.ToInt(10), MetodosJavaToCSharp.ToInt(10)));

                if (!dadosEntrada.TpProcessCb.Equals("D"))
                {
                    return vprimeirocampo
                        .Append(" ")
                        .Append(vsegundocampo)
                        .Append(" ")
                        .Append(vterceirocampo)
                        .Append(" ")
                        .Append(vquartocampo)
                        .Append(" ")
                        .Append(vquintocampo);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private static StringBuilder Itau_cfBarraformula(ParametroEntrada dadosEntrada)
        {
            try
            {
                var vbarcode = new StringBuilder();
                var vdv = new StringBuilder();
                var nfatorvencto = new StringBuilder();
                vbarcode.Clear();


                nfatorvencto.Append(dadosEntrada.DtVencimento.Subtract(Convert.ToDateTime("07/10/1997")));//Código adaptado para C#
                //nfatorvencto = toDate(MetodosJavaToCSharp.ToChar(dadosEntrada.DtVencimento, "dd/mm/yyyy"), "dd/mm/yyyy").subtract(toDate("07/10/1997", "dd/mm/yyyy"));//Código JAVA original

                vbarcode = vbarcode.Append("341");

                vbarcode = vbarcode.Append("9");


                vbarcode = vbarcode.Append(MetodosJavaToCSharp.RTrim(MetodosJavaToCSharp.LTrim(MetodosJavaToCSharp.ToChar(nfatorvencto, "0000"))));
                vbarcode = vbarcode.Append(MetodosJavaToCSharp.RTrim(MetodosJavaToCSharp.LTrim(MetodosJavaToCSharp.ToChar(MetodosJavaToCSharp.Multiply(dadosEntrada.VlMensalidade, 100), "0000000000"))));

                vbarcode = vbarcode.Append(Itau_cfCampoLivreformula(dadosEntrada));
                vdv = Itau_fDvBarcode(vbarcode);

                vbarcode = MetodosJavaToCSharp.Substring(vbarcode.ToString(), MetodosJavaToCSharp.ToInt(1), MetodosJavaToCSharp.ToInt(4)).Append(vdv)
                    .Append(MetodosJavaToCSharp.Substring(vbarcode.ToString(), MetodosJavaToCSharp.ToInt(5), Convert.ToInt32(MetodosJavaToCSharp.Subtract(vbarcode.Length, 4).ToString())));

                return vbarcode;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private static StringBuilder Itau_fDvBarcode(StringBuilder pNumero)
        {
            try
            {
                var vdvbarcode = new StringBuilder();
                var vprodutos = new StringBuilder();
                var npeso = new StringBuilder();
                var ncalculo = new StringBuilder();
                var nposition = new StringBuilder();
                var nacumulador = new StringBuilder();
                var nresto = new StringBuilder();

                // Multiplicando cada digito pelo seu peso correspondente
                vprodutos.Clear();
                npeso = MetodosJavaToCSharp.ToNumber(2);
                int size = pNumero.Length;

                for (int npointer = 1; npointer <= size; npointer++)
                {
                    nposition = MetodosJavaToCSharp.ToNumber(MetodosJavaToCSharp.Subtract(pNumero.Length, npointer -1));
                    ncalculo = MetodosJavaToCSharp.Multiply(
                        MetodosJavaToCSharp.ToNumber(MetodosJavaToCSharp.Substring(pNumero.ToString(), MetodosJavaToCSharp.ToInt(nposition), MetodosJavaToCSharp.ToInt(1))),
                        npeso
                    );

                    vprodutos = vprodutos.Append(MetodosJavaToCSharp.RTrim(MetodosJavaToCSharp.LTrim(MetodosJavaToCSharp.ToChar(ncalculo, "00"))));
                    if (npeso.Equals(9))
                    {
                        npeso = MetodosJavaToCSharp.ToNumber(2);
                    }
                    else
                    {
                        npeso = npeso.Append(1);
                    }
                }

                // Somando todos os produtos encontrados
                nacumulador = MetodosJavaToCSharp.ToNumber(0);
                size = vprodutos.Length;
                for (int npointer = 1; npointer <= size; npointer++)
                {
                    if (npointer % 2 != 0)
                    {
                        nacumulador = nacumulador.Append(MetodosJavaToCSharp.ToNumber(MetodosJavaToCSharp.Substring(vprodutos.ToString(),
                                npointer, MetodosJavaToCSharp.ToInt(2))));
                    }
                }
                // Achando o digito do codigo de Barras
                nresto = MetodosJavaToCSharp.ToNumber(MetodosJavaToCSharp.Subtract(MetodosJavaToCSharp.ToInt(11), MetodosJavaToCSharp.Mod(nacumulador, MetodosJavaToCSharp.ToNumber(11))));
                if (MetodosJavaToCSharp.Greater(nresto, 0) && MetodosJavaToCSharp.Lesser(nresto, 10))
                {
                    vdvbarcode = MetodosJavaToCSharp.RTrim(MetodosJavaToCSharp.LTrim(MetodosJavaToCSharp.ToChar(nresto)));
                }
                else
                {
                    vdvbarcode.Append("1");
                }
                return vdvbarcode;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static StringBuilder Itau_cfCampoLivreformula(ParametroEntrada dadosEntrada)
        {
            try
            {
                var ccampolivre = new StringBuilder();
                var nr_conta_corrente = new StringBuilder();

                //Verificação conta corrente
                nr_conta_corrente.Append(dadosEntrada.NrContaCorrente.ToString().Substring(1, dadosEntrada.CdCedente.ToString().Length - 1));
                nr_conta_corrente = MetodosJavaToCSharp.Lpad(nr_conta_corrente, 5, "0");

                ccampolivre.Append(MetodosJavaToCSharp.Substring(dadosEntrada.CdCarteira.ToString(), 1, 3));

                if (IsUnimed())
                {
                    ccampolivre = ccampolivre.Append(MetodosJavaToCSharp.Substring(MetodosJavaToCSharp.Replace(MetodosJavaToCSharp.Replace(Itau_cfNossoNumeroformula(dadosEntrada).ToString(), "/", ""), "-", "").ToString(), MetodosJavaToCSharp.ToInt(4), MetodosJavaToCSharp.ToInt(9)));
                }
                else if (dadosEntrada.CdCedente.Equals("835741") && dadosEntrada.CdCarteira.Equals("112"))
                {

                    ccampolivre = ccampolivre.Append(MetodosJavaToCSharp.Substring(MetodosJavaToCSharp.Replace(MetodosJavaToCSharp.Replace(Itau_cfNossoNumeroformula(dadosEntrada), "/", ""), "-", "").ToString(), MetodosJavaToCSharp.ToInt(4), MetodosJavaToCSharp.ToInt(8)));

                    //ccampolivre = ccampolivre.Append(getDao().fnModuloCarteira112(MetodosJavaToCSharp.Substring(
                    //        dadosEntrada.DsCodigoAgencia, MetodosJavaToCSharp.ToInt(1), MetodosJavaToCSharp.ToInt(4))
                    //        .Append(MetodosJavaToCSharp.Lpad(dadosEntrada.CdCedente, 6, "0"))
                    //        .Append(MetodosJavaToCSharp.Substring(dadosEntrada.CdCarteira.ToString(), MetodosJavaToCSharp.ToInt(1), MetodosJavaToCSharp.ToInt(3)))
                    //        .Append(MetodosJavaToCSharp.Substring(
                    //            MetodosJavaToCSharp.Replace(MetodosJavaToCSharp.Replace(Itau_cfNossoNumeroformula(dadosEntrada), "/", ""), "-", "").ToString(), 
                    //            MetodosJavaToCSharp.ToInt(4), 
                    //            MetodosJavaToCSharp.ToInt(8))
                    //        ))
                    //    );
                }
                else
                {
                    ccampolivre = ccampolivre.Append(
                        MetodosJavaToCSharp.Substring(
                            MetodosJavaToCSharp.Replace(
                                MetodosJavaToCSharp.Replace(Itau_cfNossoNumeroformula(dadosEntrada), "/", ""), "-", "").ToString(), 
                                MetodosJavaToCSharp.ToInt(4), 
                                MetodosJavaToCSharp.ToInt(8))
                        );
                    
                ccampolivre = ccampolivre.Append(
                    Itau_fnModulo10(
                            MetodosJavaToCSharp.Substring(dadosEntrada.DsCodigoAgencia, MetodosJavaToCSharp.ToInt(1), MetodosJavaToCSharp.ToInt(4))
                            .Append(MetodosJavaToCSharp.Substring(nr_conta_corrente.ToString(), MetodosJavaToCSharp.ToInt(1), MetodosJavaToCSharp.ToInt(5)))
                            .Append(MetodosJavaToCSharp.Substring(dadosEntrada.CdCarteira.ToString(), MetodosJavaToCSharp.ToInt(1), MetodosJavaToCSharp.ToInt(3)))
                            .Append(MetodosJavaToCSharp.Substring(MetodosJavaToCSharp.Replace(MetodosJavaToCSharp.Replace(Itau_cfNossoNumeroformula(dadosEntrada), "/", ""), "-", "").ToString(), MetodosJavaToCSharp.ToInt(4), MetodosJavaToCSharp.ToInt(8)))));
                }


                ccampolivre = ccampolivre.Append(MetodosJavaToCSharp.Substring(dadosEntrada.DsCodigoAgencia,1, 4));

                ccampolivre = ccampolivre.Append(nr_conta_corrente);
                ccampolivre = ccampolivre.Append(
                    Itau_fnModulo10(
                        MetodosJavaToCSharp.Substring(dadosEntrada.DsCodigoAgencia, 1, 4).Append(
                                MetodosJavaToCSharp.Substring(nr_conta_corrente.ToString(), 1, 5)
                            )
                        )
                    );

                ccampolivre = ccampolivre.Append(nr_conta_corrente);
                ccampolivre = ccampolivre.Append(
                    Itau_fnModulo10(
                        MetodosJavaToCSharp.Substring(
                            dadosEntrada.DsCodigoAgencia, 
                            MetodosJavaToCSharp.ToInt(1), 
                            MetodosJavaToCSharp.ToInt(4))
                        .Append(
                            MetodosJavaToCSharp.Substring(
                                nr_conta_corrente.ToString(), 
                                MetodosJavaToCSharp.ToInt(1), 
                                MetodosJavaToCSharp.ToInt(5))
                            )
                        )
                    );

                ccampolivre = ccampolivre.Append("000");
                return ccampolivre;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static StringBuilder Itau_fnModulo10(StringBuilder pNumero)
        {
            var retorno = new StringBuilder();
            var vdvlinhaDig = new StringBuilder();
            var vprodutos = new StringBuilder();
            var npeso = new StringBuilder();
            var ncalculo = new StringBuilder();
            var nposition = new StringBuilder();
            var nacumulador = new StringBuilder();
            var nresto = new StringBuilder();

            // Multiplicando cada digito pelo seu peso correspondente
            vprodutos.Clear();
            npeso.Append(2);
            int size = pNumero.Length;
            for (int npointer = 1; npointer <= size; npointer++)
            {
                nposition = MetodosJavaToCSharp.ToNumber(pNumero.Length - (npointer-1));
                ncalculo = MetodosJavaToCSharp.Multiply(
                    MetodosJavaToCSharp.ToNumber(
                        MetodosJavaToCSharp.Substring(
                            pNumero.ToString(), 
                            MetodosJavaToCSharp.ToInt(nposition), 
                            MetodosJavaToCSharp.ToInt(1)
                            )
                        ), 
                    npeso
                );

                if (MetodosJavaToCSharp.Greater(ncalculo,9))
                {
                    ncalculo = MetodosJavaToCSharp.ToNumber(
                            MetodosJavaToCSharp.Substring(
                                ncalculo.ToString(), 
                                MetodosJavaToCSharp.ToInt(1), 
                                MetodosJavaToCSharp.ToInt(1)))
                        .Append(

                        MetodosJavaToCSharp.ToNumber(
                            MetodosJavaToCSharp.Substring(
                                ncalculo.ToString(), 
                                MetodosJavaToCSharp.ToInt(2),
                                MetodosJavaToCSharp.ToInt(1))
                            )
                        );
                }
                vprodutos = vprodutos.Append(
                    MetodosJavaToCSharp.RTrim(
                        MetodosJavaToCSharp.LTrim(
                            MetodosJavaToCSharp.ToChar(ncalculo, "00")
                            )
                        )
                    );

                if (npeso.Equals(2))
                {
                    npeso = MetodosJavaToCSharp.ToNumber(1);
                }
                else
                {
                    npeso = MetodosJavaToCSharp.ToNumber(2);
                }

            }
            // Somando todos os produtos encontrados
            nacumulador = MetodosJavaToCSharp.ToNumber(0);
            size = vprodutos.Length;
            for (int npointer = 1; npointer <= size; npointer++)
            {
                if (npointer % 2 != 0)
                {
                    nacumulador = nacumulador.Append(
                        MetodosJavaToCSharp.ToNumber(
                            MetodosJavaToCSharp.Substring(
                                vprodutos.ToString(),
                                npointer, 
                                MetodosJavaToCSharp.ToInt(2)
                                )
                            )
                        );
                }
            }
            // Achando o digito do codigo de Barras

            nresto = MetodosJavaToCSharp.ToNumber(
                MetodosJavaToCSharp.Subtract(
                    MetodosJavaToCSharp.ToInt(10), 
                    MetodosJavaToCSharp.Mod(
                        nacumulador, 
                        MetodosJavaToCSharp.ToNumber(10)
                        )
                    )
                );

            if (MetodosJavaToCSharp.Lesser(nresto, 10))
            {
                vdvlinhaDig = MetodosJavaToCSharp.RTrim(MetodosJavaToCSharp.LTrim(MetodosJavaToCSharp.ToChar(nresto)));
            }
            else
            {
                vdvlinhaDig.Append("0");
                //vdvlinhaDig = toStr("0");//Linha original
            }
            return vdvlinhaDig;
        }

        public static StringBuilder Itau_cfNossoNumeroformula(ParametroEntrada dadosEntrada)
        {
            try
            {
                var cnossonumero = new StringBuilder();

                // BANCO ITAÚ
                StringBuilder cdCedente = MetodosJavaToCSharp.Substring(
                    dadosEntrada.CdCedente.ToString(),
                    MetodosJavaToCSharp.ToInt(1),
                    MetodosJavaToCSharp.ToInt(dadosEntrada.CdCedente.ToString().Length) - 1);

                if (IsUnimed())
                {
                    cnossonumero.Clear();
                    cnossonumero.Append(dadosEntrada.CdNossoNumero);
                }
                else if (MetodosJavaToCSharp.Greater(dadosEntrada.CdNossoNumero.ToString().Length, 8))
                {
                    cnossonumero = MetodosJavaToCSharp.Substring(
                        dadosEntrada.CdNossoNumero.ToString(),
                        MetodosJavaToCSharp.ToInt(dadosEntrada.CdNossoNumero.ToString().Length - 7),
                        MetodosJavaToCSharp.ToInt(dadosEntrada.CdNossoNumero.ToString().Length));
                }
                else
                {
                    cnossonumero.Clear();
                    cnossonumero.Append(dadosEntrada.CdNossoNumero);
                }

                if (IsUnimed() && (!dadosEntrada.CdCedente.Equals("300593") && !dadosEntrada.CdCarteira.Equals("109")))
                {
                    if (dadosEntrada.CdCarteira.Equals("112"))
                    {
                        cnossonumero.Clear();
                        cnossonumero.Append(dadosEntrada.CdCarteira);
                        cnossonumero.Append("/");
                        cnossonumero.Append(MetodosJavaToCSharp.Substring(MetodosJavaToCSharp.Lpad(cnossonumero, 9, "0").ToString(), 1, 8));
                        cnossonumero.Append("-");
                        cnossonumero.Append(MetodosJavaToCSharp.Substring(MetodosJavaToCSharp.Lpad(cnossonumero, 9, "0").ToString(), 9, 1));
                    }
                    else
                    {
                        cnossonumero.Clear();
                        cnossonumero.Append(dadosEntrada.CdCarteira);
                        cnossonumero.Append("/");
                        cnossonumero.Append(MetodosJavaToCSharp.Lpad(cnossonumero, 8, "0"));
                        cnossonumero.Append("-");
                        cnossonumero.Append(MetodosJavaToCSharp.Substring(MetodosJavaToCSharp.Lpad(cnossonumero, 9, "0").ToString(), 9, 1));
                    }

                }
                else
                {
                    if (dadosEntrada.CdCarteira.Equals("109"))
                    {
                        cnossonumero.Clear();
                        cnossonumero.Append(dadosEntrada.CdCarteira);
                        cnossonumero.Append('/');
                        cnossonumero.Append(MetodosJavaToCSharp.Lpad(cnossonumero, 8, "0"));
                        cnossonumero.Append("-");
                        cnossonumero.Append(Itau_fnModulo10(MetodosJavaToCSharp.Lpad(dadosEntrada.NrAgencia.ToString(), 4, "0")
                                    .Append(MetodosJavaToCSharp.Lpad(MetodosJavaToCSharp.Substring(dadosEntrada.NrContaCorrente.ToString(), 1, Convert.ToInt32(MetodosJavaToCSharp.Subtract(dadosEntrada.NrContaCorrente.ToString().Length, 1))), 5, "0"))
                                    .Append(dadosEntrada.CdCarteira)
                                    .Append(MetodosJavaToCSharp.Lpad(cnossonumero, 8, "0"))));
                    }
                    else if (dadosEntrada.CdCedente.Equals("835741") && dadosEntrada.CdCarteira.Equals("112"))
                    {
                        cnossonumero.Clear();
                        cnossonumero.Append(dadosEntrada.CdCarteira);
                        cnossonumero.Append("/");
                        cnossonumero.Append(MetodosJavaToCSharp.Lpad(cnossonumero, 8, "0"));
                        cnossonumero.Append("-");
                        //cnossonumero.Append(getDao().fnModuloCarteira112(MetodosJavaToCSharp.Lpad(dadosEntrada.DsCodigoAgencia, 4, "0")
                        //                .Append(MetodosJavaToCSharp.Lpad(dadosEntrada.CdCedente, 6, "0"))
                        //                .Append(dadosEntrada.CdCarteira)
                        //                .Append(MetodosJavaToCSharp.Lpad(cnossonumero, 8, "0"))));

                    }
                    else
                    {
                        cnossonumero.Clear();
                        cnossonumero.Append(dadosEntrada.CdCarteira);
                        cnossonumero.Append("/");
                        cnossonumero.Append(MetodosJavaToCSharp.Lpad(cnossonumero, 8, "0"));
                        cnossonumero.Append("-");
                        cnossonumero.Append(Itau_fnModulo10(MetodosJavaToCSharp.Lpad(dadosEntrada.DsCodigoAgencia, 4, "0")
                                    .Append(MetodosJavaToCSharp.Lpad(cdCedente, 5, "0"))
                                    .Append(dadosEntrada.CdCarteira)
                                    .Append(MetodosJavaToCSharp.Lpad(cnossonumero, 8, "0"))));
                    }
                }

                return cnossonumero;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static bool IsUnimed()
        {
            return false;
        }
    }
}

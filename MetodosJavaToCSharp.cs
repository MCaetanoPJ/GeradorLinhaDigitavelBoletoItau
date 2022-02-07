using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorLinhaDigitavelBoletoItau
{
    public class MetodosJavaToCSharp
    {
        public static StringBuilder Lpad(object valor, int v1, string v2)
        {
            var retorno = new StringBuilder();
            var stringToChar = Convert.ToChar(v2);
            return retorno.Append(valor.ToString().PadLeft(v1, stringToChar));
        }

        public static StringBuilder Substring(string texto, int v1, int v2 = 0)
        {
            try
            {
                var retorno = new StringBuilder();
                return retorno.Append(texto.Substring(v1, v2 - 1));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Metodo importado do Java6, possui a função de conveter um valor informado para inteiro e retornar um stringBuilder
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static StringBuilder ToNumber(object valor)
        {
            try
            {
                var retorno = new StringBuilder();
                var v = 0;
                int.TryParse(valor.ToString(), out v);
                return retorno.Append(v);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int ToInt(object valor)
        {
            try
            {
                var v = 0;
                int.TryParse(valor.ToString(), out v);
                return v;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método Importado do Java6 e adaptado para C#, possui o objetivo de verificar se o valor informado é maior ou igual a outro valor informado
        /// </summary>
        /// <param name="valor1"></param>
        /// <param name="valor2"></param>
        /// <returns></returns>
        public static bool Greater(object valor1, int valor2)
        {
            try
            {
                if (Convert.ToInt32(valor1.ToString()) >= valor2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método Importado do Java6 e adaptado para C#, possui o objetivo de verificar se o valor informado é menor ou igual a outro valor informado
        /// </summary>
        /// <param name="valor1"></param>
        /// <param name="valor2"></param>
        /// <returns></returns>
        public static bool Lesser(object valor1, int valor2)
        {
            try
            {
                if (Convert.ToInt32(valor1.ToString()) <= valor2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método importado do Java6, e possui a função de multiplicar um número por outro
        /// </summary>
        /// <param name="valor1"></param>
        /// <param name="valor2"></param>
        /// <returns></returns>
        public static StringBuilder Multiply(object valor1, object valor2)
        {
            try
            {
                var retorno = new StringBuilder();

                double v1 = 0;
                double v2 = 0;
                double.TryParse(valor1.ToString(), out v1);
                double.TryParse(valor2.ToString(), out v2);

                return retorno.Append(v1 * v2);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método adaptado do java6, possui a função de remover o espaço a direita do valor informado
        /// </summary>
        /// <param name="valor1"></param>
        /// <returns></returns>
        public static StringBuilder RTrim(StringBuilder valor1)
        {
            try
            {
                var retorno = new StringBuilder();

                return retorno.Append(valor1.ToString().TrimEnd());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método adaptado do java6, possui a função de remover o espaço a esquerda do valor informado
        /// </summary>
        /// <param name="valor1"></param>
        /// <returns></returns>
        public static StringBuilder LTrim(StringBuilder valor1)
        {
            try
            {
                var retorno = new StringBuilder();

                return retorno.Append(valor1.ToString().TrimStart());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método Importado do Java6 e adaptado para C#, possui o objetivo de converter um valor para char
        /// </summary>
        /// <param name="valor1"></param>
        /// <param name="valor2"></param>
        /// <returns></returns>
        public static StringBuilder ToChar(object valor1, string valor2 = "")
        {
            try
            {
                var retorno = new StringBuilder();
                return retorno.Append(valor1.ToString());

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método Importado do Java6 e adaptado para C#, possui o objetivo de calcular e retornar o Mod
        /// </summary>
        /// <param name="dividendo"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public static StringBuilder Mod(object dividendo, object divisor)
        {
            try
            {
                var v1 = 0;
                int.TryParse(dividendo.ToString(), out v1);

                var v2 = 0;
                int.TryParse(divisor.ToString(), out v2);

                var resultado = 0;
                Math.DivRem(v1, v2, out resultado);

                var retorno = new StringBuilder();
                return retorno.Append(resultado);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método Importado do Java6 e adaptado para C#, possui o objetivo de calcular e retornar o Mod
        /// </summary>
        /// <param name="valor1"></param>
        /// <param name="valor2"></param>
        /// <returns></returns>
        public static StringBuilder Subtract(object valor1, object valor2)
        {
            try
            {
                var retorno = new StringBuilder();

                var v1 = 0;
                int.TryParse(valor1.ToString(), out v1);

                var v2 = 0;
                int.TryParse(valor2.ToString(), out v2);

                var resultadoSubtracao = v1 - v2;

                return retorno.Append(resultadoSubtracao);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método Importado do Java6 e adaptado para C#, possui o objetivo de substituir um valor por outro dentro um texto informado
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="valorAntigo"></param>
        /// <param name="valorNovo"></param>
        /// <returns></returns>
        public static StringBuilder Replace(object texto, object valorAntigo, object valorNovo)
        {
            try
            {
                var retorno = new StringBuilder();
                return retorno.Append(texto.ToString().Replace(valorAntigo.ToString(), valorNovo.ToString()));

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

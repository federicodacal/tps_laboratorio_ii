using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public  Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando():this(0)
        {

        }

        public Operando(string numero)
        {
            this.Numero = numero;
        }

        private string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }

        private double ValidarOperando(string strNumero)
        {
            double numero;
            
            if(!double.TryParse(strNumero, out numero))
            {
                numero = 0;
            }

            return numero;
        }

        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if(binario[i]!= '1' && binario[i] != '0')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Permite convertir un valor binario a decimal
        /// </summary>
        /// <param name="binario">String a convertir</param>
        /// <returns>Valor convertido a decimal o "Valor invalido" si no fue posible la conversion</returns>
        public string BinarioDecimal(string binario)
        {
            double resultado = 0;
            int length = binario.Length;

            if (this.EsBinario(binario))
            {
                foreach (char caracter in binario)
                {
                    length--;
                    if (caracter == '1')
                    {
                        resultado += (int)Math.Pow(2, length);
                    }
                }
                return resultado.ToString();
            }
            else
            {
                return "Valor invalido";
            }
        }

        /// <summary>
        /// Permite convertir un numero decimal a binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Numero convertido a binario o "Valor invalido" si no lo pudo convertir</returns>
        public string DecimalBinario(double numero)
        {
            string binarioStr = string.Empty;
            int resultadoDivision = (int)numero;
            int restoDivision;
            if (resultadoDivision >= 0)
            {
                do
                {
                    restoDivision = resultadoDivision % 2;
                    resultadoDivision /= 2;
                    binarioStr = restoDivision.ToString() + binarioStr;
                } while (resultadoDivision > 0);

                return binarioStr;
            }
            else
            {
                return "Valor invalido";
            }
        }
        /// <summary>
        /// Permite convertir un numero decimal a binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Numero convertido a binario o "Valor invalido" si no lo pudo convertir</returns>
        public string DecimalBinario(string numero)
        {
            double numeroConvertido;
            if (double.TryParse(numero, out numeroConvertido))
            {
                return DecimalBinario(numeroConvertido);
            }
            else
            {
                return "Valor invalido";
            }
        }

        // Sobrecarga de operadores para realizar las operaciones aritmetica +,-,* o / del atributo numero de los Operandos
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }
    }
}

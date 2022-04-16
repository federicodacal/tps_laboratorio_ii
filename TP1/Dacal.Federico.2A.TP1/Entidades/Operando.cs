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

        /// <summary>
        /// Constructor parametrizado que recibe un double
        /// </summary>
        /// <param name="numero">Valor al que se inicializa el atributo numero</param>
        public  Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor sin parametros, al llamarse establece el atributo numero en 0
        /// </summary>
        public Operando():this(0)
        {

        }

        /// <summary>
        /// Constructor parametrizado que recibe un string
        /// </summary>
        /// <param name="numero">Valor al que se inicializa mediante Propiedad Numero</param>
        public Operando(string numero)
        {
            this.Numero = numero;
        }

        /// <summary>
        /// Propiedad que permite setear el atributo numero, valida el operando y asigna
        /// </summary>
        private string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }

        /// <summary>
        /// Valida que el operando sea de tipo numerico (double)
        /// </summary>
        /// <param name="strNumero">String a analizar</param>
        /// <returns>El operando validado double o en caso contrario devolvera 0</returns>
        private double ValidarOperando(string strNumero)
        {
            double numero;
            
            if(!double.TryParse(strNumero, out numero))
            {
                numero = 0;
            }

            return numero;
        }

        /// <summary>
        /// Analiza un string para reconocer si todos sus caracteres son 1s y 0s
        /// </summary>
        /// <param name="binario">String a analizar</param>
        /// <returns>True si es binario o False si no lo es</returns>
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
        /// Permite convertir un valor binario a decimal en caso de recibir un numero negativo o con parte decimal trabajara con su valor absoluto y entero
        /// </summary>
        /// <param name="binario">String a convertir</param>
        /// <returns>Valor convertido a decimal o "Valor invalido" si no fue posible la conversion</returns>
        public string BinarioDecimal(string binario)
        {
            double resultado = 0;
            double auxNumero;
            int length;

            if(double.TryParse(binario, out auxNumero))
            {
                auxNumero = Math.Truncate(auxNumero);
                if(auxNumero < 0)
                {
                    auxNumero*=-1;
                }
                binario = auxNumero.ToString();
            }

            length = binario.Length;

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
            numero = Math.Truncate(numero);
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
        /// Permite convertir un numero decimal a binario, en caso de recibir un numero negativo o con parte decimal trabajara con su valor absoluto y entero
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Numero convertido a binario o "Valor invalido" si no lo pudo convertir</returns>
        public string DecimalBinario(string numero)
        {
            double numeroConvertido;

            if(numero[0] == '-')
            {
                numero = numero.Remove(0, 1);
            }

            if (double.TryParse(numero, out numeroConvertido))
            {
                return DecimalBinario(numeroConvertido);
            }
            else
            {
                return "Valor invalido";
            }
        }

        // Sobrecarga de operadores para realizar las operaciones aritmeticas +,-,* o / del atributo numero de los objetos de tipo Operando
        
        // Suma de dos numeros
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        // Resta de dos numeros
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        // Multiplicacion de dos numeros
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        // Division de dos numeros, en caso que el segundo operando sea 0 devolverá el MinValue de double
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

using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el char operador recibido por parametro sea uno de los operadores aritmeticos +,-,* o /
        /// </summary>
        /// <param name="operador">Caracter a validar</param>
        /// <returns>Operador ingresado validado o por defecto el operador + (suma)</returns>
        private static char ValidarOperador(char operador)
        {
            char operadorValido = '+';
            if(operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                operadorValido = operador;
            }
            return operadorValido;
        }

        /// <summary>
        /// En caso de validar el char operador mediante el metodo ValidarOperador permite operar aritmeticamente con el atributo numero de la Clase Operando
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char auxOperador;
            double resultado = 0;

            auxOperador = Calculadora.ValidarOperador(operador);
            switch (auxOperador)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
    }
}

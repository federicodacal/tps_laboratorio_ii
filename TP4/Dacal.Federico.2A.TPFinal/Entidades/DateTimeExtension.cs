using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Extensora de DateTime
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// A partir de una fecha calcula la cantidad de anios hasta actualmente
        /// </summary>
        /// <param name="date">Fecha pasada por parametro</param>
        /// <returns>Un int que representa la cantidad de anios</returns>
        public static int FindYears(this DateTime date)
        {
            int years = DateTime.Now.Year - date.Year;
            if (DateTime.Now.Month < date.Month || (DateTime.Now.Month == date.Month && DateTime.Now.Day < date.Day))
            {
                years--;
            }
            return years;
        }
    }
}

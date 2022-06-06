using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class DateTimeExtension
    {
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

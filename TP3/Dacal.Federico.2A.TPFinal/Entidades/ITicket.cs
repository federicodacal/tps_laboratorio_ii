using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interface para imprimir Tickets.
    /// </summary>
    public interface ITicket
    {
        string PathTicket { get; }

        bool ImprimirTicket(string path);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TicketException : Exception
    {
        public TicketException(string message)
            :base(message)
        {

        }

        public TicketException(string message, Exception innerException)
            :base(message, innerException)
        {

        }
    }
}

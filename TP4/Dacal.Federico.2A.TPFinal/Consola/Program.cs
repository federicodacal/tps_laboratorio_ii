using System;
using System.Collections.Generic;
using Entidades;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Socio> misSocios = SocioDAO.Leer();

            Console.WriteLine(misSocios.Count);
            foreach (Socio item in misSocios)
            {
                Console.WriteLine(item.ObtenerInformacionCompleta());
            }

            //if (SocioDAO.Eliminar(6202109009))
            //{
            //    Console.WriteLine("Se eliminó!");
            //}

            //Socio s = new Socio("Juan", "Perez", 0042314283, Socio.EGenero.Masculino, new DateTime(1999, 10, 9), "juanperez@gmail.com", true);

            //if (SocioDAO.Modificar(s))
            //{
            //    Console.WriteLine("Se modificó!");
            //}

            //Socio s = new Socio("Romeo", "Lopez", 43534534, Socio.EGenero.Masculino, new DateTime(1998, 3, 4), "rlopez@yahoo.com", true);

            //if (SocioDAO.Guardar(s))
            //{
            //    Console.WriteLine("Se agregó!");
            //}
            //else
            //{
            //    Console.WriteLine("No");
            //}
        }
    }
}

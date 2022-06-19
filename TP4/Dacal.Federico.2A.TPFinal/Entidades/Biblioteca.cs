using System;
using System.Collections.Generic;
using System.IO;

namespace Entidades
{

    public delegate void LimitePrestamosDelegado(Socio socio, SocioEventArgs e);

    public static class Biblioteca
    {
        private static string denominacion;
        private static string email;
        private static List<Publicacion> publicaciones;
        private static List<Prestamo> prestamos;
        private static List<Socio> socios;

        public static event LimitePrestamosDelegado LimitePrestamosAlcanzado;

        /// <summary>
        /// Constructor estático de Biblioteca que inicializa sus atributos de clase
        /// </summary>
        static Biblioteca()
        {
            Biblioteca.denominacion = "Biblioteca UTN-Fra";
            Biblioteca.email = "utn-fra@sistemas.com.ar";

            Biblioteca.publicaciones = new List<Publicacion>();
            Biblioteca.prestamos = new List<Prestamo>();
            Biblioteca.socios = new List<Socio>();
        }


        /// <summary>
        /// Propiedad de L/E de Lista Socios
        /// </summary>
        public static List<Socio> Socios
        {
            get { return Biblioteca.socios; }
            set { Biblioteca.socios = value; }
        }

        /// <summary>
        /// Propiedad de L/E de Lista Publicaciones
        /// </summary>
        public static List<Publicacion> Publicaciones
        {
            get { return Biblioteca.publicaciones; }
            set { Biblioteca.publicaciones = value; }
        }

        /// <summary>
        /// Propiedad de L/E de Lista Prestamos
        /// </summary>
        public static List<Prestamo> Prestamos
        {
            get { return Biblioteca.prestamos; }
            set { Biblioteca.prestamos = value; }
        }

        /// <summary>
        /// Propiedad de Lectura de denominacion ('nombre' de la Biblioteca)
        /// </summary>
        public static string Denominacion
        {
            get { return Biblioteca.denominacion; }
        }

        /// <summary>
        /// Propiedad de lectura del atributo email
        /// </summary>
        public static string Email 
        {
            get { return Biblioteca.email; }            
        }

        /// <summary>
        /// Se verifica si el socio está en la Lista de la Biblioteca
        /// </summary>
        /// <param name="socio">Objeto de tipo socio ha validar</param>
        /// <returns>True si el socio se encuentra en la lista, caso contrario false</returns>
        private static bool ExisteSocio(Socio socio)
        {
            bool rta = false;
            if(socio is not null)
            {
                foreach (Socio item in Biblioteca.socios)
                {
                    if(item == socio)
                    {
                        rta = true;
                        break;
                    }
                }
            }
            return rta;
        }

        /// <summary>
        /// Se agrega nuevo socio a la lista en caso que no haya sido agregado previamente
        /// </summary>
        /// <param name="socio">Socio a agregar</param>
        /// <returns>True si se agrega el socio, falso caso contrario</returns>
        public static bool AgregarSocio(Socio socio)
        {
            bool rta = false;
            if(!Biblioteca.ExisteSocio(socio))
            {
                Biblioteca.socios.Add(socio);
                rta = true;
            }
            return rta;
        }

        /// <summary>
        /// Remueve el socio de la lista si este existe en ella
        /// </summary>
        /// <param name="socio">Socio a ser quitado</param>
        public static void QuitarSocio(Socio socio)
        {
            if (Biblioteca.ExisteSocio(socio))
            {
                Biblioteca.Socios.Remove(socio);
            }
        }

        /// <summary>
        /// Se valida que la Publicacion este en el catalogo (Lista de Publicaciones)
        /// </summary>
        /// <param name="publicacion">Publicacion a verificar</param>
        /// <returns>True si esta, falso caso contrario</returns>
        private static bool PublicacionEstaEnCatalogo(Publicacion publicacion)
        {
            bool rta = false;
            if(publicacion is not null)
            {
                foreach (Publicacion item in Biblioteca.publicaciones)
                {
                    if(item == publicacion)
                    {
                        rta = true;
                        break;
                    }
                }
            }
            return rta;
        }

        /// <summary>
        /// Asignara un prestamo al socio recibido por parámetro de la publicación recibada como segundo parámetro, en caso de ser posible. Se carga el prestamo en Biblioteca y en la lista del socio y se imprime el ticket.
        /// </summary>
        /// <param name="socio">Socio a recibir el prestamo</param>
        /// <param name="publicacion">Publicacion que forma parte del prestamo</param>
        /// <returns>True si se puede realziar, false si no pudo</returns>
        public static bool PrestarPublicacion(Socio socio, Publicacion publicacion)
        {
            bool rta = false;
            if(socio is not null && publicacion is not null && Biblioteca.PublicacionEstaEnCatalogo(publicacion) && Biblioteca.ExisteSocio(socio) && publicacion.EstaDisponible)
            {

                if(socio.ListaPrestamos.Count < 3)
                {
                    Prestamo prestamo = new Prestamo(publicacion, socio);
                    Biblioteca.Prestamos.Add(prestamo);
                    socio.ListaPrestamos.Add(prestamo);
                    publicacion.EstaDisponible = false;
                    prestamo.ImprimirTicket("Ticket");
                    rta = true;
                }
                else
                {
                    if(Biblioteca.LimitePrestamosAlcanzado is not null)
                    {
                        SocioEventArgs eventArgs = new SocioEventArgs();
                        eventArgs.PrestamosVigentes = socio.ListaPrestamos.Count;
                        Biblioteca.LimitePrestamosAlcanzado.Invoke(socio, eventArgs);
                    }
                }
            }
            return rta;
        }
        
        /// <summary>
        /// Recibe la devolución de un prestamo por parte de un socio.
        /// </summary>
        /// <param name="socio">Socio prestamo</param>
        /// <param name="prestamo">Publicacion del prestamo</param>
        public static void RecibirDevolucion(Socio socio, Prestamo prestamo)
        {
            if(socio is not null && prestamo is not null && socio == prestamo)
            {
                socio.ListaPrestamos.Remove(prestamo);
                Biblioteca.Prestamos.Remove(prestamo);
                foreach (Publicacion item in Biblioteca.Publicaciones)
                {
                    if(item == prestamo.Publicacion)
                    {
                        item.EstaDisponible = true;
                        break;
                    }
                }
            }
        }
        
        public static void CargarPrestamos()
        {
            if(Biblioteca.Socios is not null && Biblioteca.Prestamos is not null)
            {
                foreach (Socio socio in Biblioteca.Socios)
                {
                    foreach (Prestamo prestamo in Biblioteca.Prestamos)
                    {
                        if(socio.Dni == prestamo.DniSocio)
                        {
                            socio.ListaPrestamos.Add(prestamo);
                        }
                    }
                }
            }
        }


    }
}

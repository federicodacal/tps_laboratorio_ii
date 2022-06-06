using System;
using System.Collections.Generic;
using System.IO;

namespace Entidades
{
    public static class Biblioteca
    {
        private static string denominacion;
        private static string email;
        private static List<Publicacion> publicaciones;
        private static List<Prestamo> prestamos;
        private static List<Socio> socios;

        static Biblioteca()
        {
            Biblioteca.denominacion = "Biblioteca UTN-Fra";
            Biblioteca.email = "utn-fra@sistemas.com.ar";

            Biblioteca.publicaciones = new List<Publicacion>();
            Biblioteca.prestamos = new List<Prestamo>();
            Biblioteca.socios = new List<Socio>();
        }


        public static List<Socio> Socios
        {
            get { return Biblioteca.socios; }
            set { Biblioteca.socios = value; }
        }

        public static List<Publicacion> Publicaciones
        {
            get { return Biblioteca.publicaciones; }
            set { Biblioteca.publicaciones = value; }
        }

        public static List<Prestamo> Prestamos
        {
            get { return Biblioteca.prestamos; }
            set { Biblioteca.prestamos = value; }
        }

        public static string Denominacion
        {
            get { return Biblioteca.denominacion; }
        }

        public static string Email 
        {
            get { return Biblioteca.email; }            
        }


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

        public static void QuitarSocio(Socio socio)
        {
            if (Biblioteca.ExisteSocio(socio))
            {
                Biblioteca.Socios.Remove(socio);
            }
        }

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

        public static bool PrestarPublicacion(Socio socio, Publicacion publicacion)
        {
            bool rta = false;
            if(socio is not null && publicacion is not null && Biblioteca.PublicacionEstaEnCatalogo(publicacion) && Biblioteca.ExisteSocio(socio) && publicacion.EstaDisponible)
            {
                Prestamo prestamo = new Prestamo(publicacion, socio);
                Biblioteca.Prestamos.Add(prestamo);
                socio.ListaPrestamos.Add(prestamo);
                publicacion.EstaDisponible = false;
                prestamo.ImprimirTicket("Ticket");
                rta = true;
            }
            return rta;
        }
        
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
    }
}

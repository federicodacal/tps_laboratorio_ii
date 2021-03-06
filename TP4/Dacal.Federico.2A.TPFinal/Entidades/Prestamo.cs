using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    public class Prestamo : ITicket
    {
        private string id;
        private string titulo;
        private DateTime fechaPrestamo;
        private Publicacion publicacion;
        private Socio socio;
        private string datosSocio;
        private long dniSocio;
        private decimal costo;

        /// <summary>
        /// Constructor por defecto de Prestamo
        /// </summary>
        public Prestamo()
        {

        }

        /// <summary>
        /// Constructor parametrizado de Prestamo
        /// </summary>
        /// <param name="publicacion"></param>
        /// <param name="socio"></param>
        public Prestamo(Publicacion publicacion, Socio socio)
            : this(publicacion.Id, publicacion.Titulo, DateTime.Now, socio.Dni)
        {
            this.publicacion = publicacion;
            this.socio = socio;
            this.AsignarCostoPrestamo();
        }

        public Prestamo(string id, string titulo, DateTime fechaPrestamo, long dniSocio)
        {
            this.id = id;
            this.titulo = titulo;
            this.fechaPrestamo = fechaPrestamo;
            this.dniSocio = dniSocio;
        }

        public string Titulo
        {
            get
            {
                if (this.Publicacion is not null)
                {
                    return this.Publicacion.Titulo;
                }
                else
                {
                    return this.titulo;
                }
            }
        }

        public long DniSocio
        {
            get
            {
                if (this.Socio is not null)
                {
                    return this.Socio.Dni;
                }
                else
                {
                    return this.dniSocio;
                }
            }
        }

        public string Id
        {
            get
            {
                if(this.Publicacion is not null)
                {
                    return this.Publicacion.Id;
                }
                else
                {
                    return this.id;
                }
            }
        }

        /// <summary>
        /// Propiedad de L/E de atributo fechaPrestamo
        /// </summary>
        public DateTime FechaPrestamo
        {
            get { return this.fechaPrestamo; }
            set { this.fechaPrestamo = value; }
        }

        /// <summary>
        /// Propiedad de L/E de atributo socio
        /// </summary>
        private Socio Socio
        {
            get { return this.socio; }
            set { this.socio = value; }
        }

        /// <summary>
        /// Propiedad de L/E del costo
        /// </summary>
        public decimal Costo
        {
            get { return this.costo; }
            set { this.costo = value; }
        }

        /// <summary>
        /// Propiedad de L/E de datos del atributo socios
        /// </summary>
        public string DatosSocio
        {
            get 
            {
                if(this.socio is not null)
                {
                    return this.socio.ToString(); 
                }
                return "";
            }
            set { this.datosSocio = value; }
        }

        /// <summary>
        /// Propiedad de L/E de atributo publicacion
        /// </summary>
        public Publicacion Publicacion
        {
            get { return this.publicacion; }
            set { this.publicacion = value; }
        }

        /// <summary>
        /// Asigna el costo del prestamo segun tipo de publicacion y si el socio es estudiante UTN
        /// </summary>
        public void AsignarCostoPrestamo()
        {
            if(this.Publicacion.GetType() == typeof(PublicacionUniversitaria))
            {
                this.costo = 15;
                if (this.Socio.EsEstudiante)
                {
                    this.costo = 5;
                }
            }
            else if(this.Publicacion.GetType() == typeof(Paper))
            {
                this.costo = 20;
            }
            else if(this.Publicacion.GetType() == typeof(Novela))
            {
                this.costo = 30;
            }
        }

        /// <summary>
        /// Sobrescritura del metodo ToString()
        /// </summary>
        /// <returns>Retorna los datos del prestamo</returns>
        public override string ToString()
        {
            return $"{ this.Titulo} | Fecha: { this.FechaPrestamo.ToShortDateString()}";
        }


        public string Info
        {         
            get { return $"{this.DatosSocio} | {this.Publicacion} | {this.FechaPrestamo} | ${this.costo}"; }
        }

        /// <summary>
        /// Path del Ticket
        /// </summary>
        [JsonIgnore]
        public string PathTicket
        {
            get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Tickets"); }
        }

        /// <summary>
        /// Guarda un archivo .txt con los datos del prestamo
        /// </summary>
        /// <param name="path">Ruta</param>
        /// <returns>True si pudo, falso en caso contrario</returns>
        public bool ImprimirTicket(string path)
        {
            bool rta = false;
            try
            {
                if (!Directory.Exists(this.PathTicket))
                {
                    Directory.CreateDirectory(this.PathTicket);
                }

                using (StreamWriter sw = new StreamWriter(Path.Combine(this.PathTicket, $"{path}_{this.FechaPrestamo.ToString("HH_mm_ss")}.txt")))
                {
                    sw.WriteLine(Biblioteca.Denominacion);
                    sw.WriteLine(Biblioteca.Email);
                    sw.WriteLine("*****************************************");
                    sw.WriteLine(this.Info);
                    sw.WriteLine("*****************************************");
                }
            }
            catch (Exception e)
            {
                throw new TicketException($"Ocurrió un problema al imprimir ticket: {e.Message}", e);
            }
            return rta;
        }

    }
}

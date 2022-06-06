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
        private DateTime fechaPrestamo;
        private Publicacion publicacion;
        private Socio socio;
        private string datosSocio;
        private decimal costo;

        public Prestamo()
        {

        }

        public Prestamo(Publicacion publicacion, Socio socio)
        {
            this.publicacion = publicacion;
            this.socio = socio;
            this.fechaPrestamo = DateTime.Now;
            this.AsignarCostoPrestamo();
        }

        public DateTime FechaPrestamo
        {
            get { return this.fechaPrestamo; }
            set { this.fechaPrestamo = value; }
        }

        private Socio Socio
        {
            get { return this.socio; }
            set { this.socio = value; }
        }

        public decimal Costo
        {
            get { return this.costo; }
        }

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

        public Publicacion Publicacion
        {
            get { return this.publicacion; }
            set { this.publicacion = value; }
        }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.DatosSocio);
            sb.AppendLine(this.Publicacion.ToString());
            sb.AppendLine(this.FechaPrestamo.ToString());
            sb.AppendLine($"${this.costo}");

            return sb.ToString();
        }

        [JsonIgnore]
        public string PathTicket
        {
            get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Tickets"); }
        }

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
                    sw.WriteLine(this.ToString());
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

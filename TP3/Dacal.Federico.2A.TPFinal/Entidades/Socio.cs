using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Socio
    {
        public enum EGenero { Masculino, Femenino, NoBinario }

        private string nombre;
        private string apellido;
        private long dni;
        private EGenero genero;
        private DateTime fechaNacimiento;
        private bool esEstudiante;
        private string email;
        private List<Prestamo> listaPrestamos;

        public Socio() 
        { 

        }

        public Socio(string nombre, string apellido, long dni, EGenero genero, DateTime fechaNacimiento, string email, bool esEstudiante)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.genero = genero;
            this.fechaNacimiento = fechaNacimiento;
            this.email = email;
            this.esEstudiante = esEstudiante;
            this.listaPrestamos = new List<Prestamo>();
        }

        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.apellido = value;
                }
            }
        }

        public string Nombre 
        {
            get { return this.nombre; }
            set 
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.nombre = value; 
                }
            } 
        }

        public bool EsEstudiante
        {
            get { return this.esEstudiante; }
            set { this.esEstudiante = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public long Dni
        {
            get { return this.dni; }
            set { this.dni = value; }
        }

        public EGenero Genero
        {
            get { return this.genero; }
            set { this.genero = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return this.fechaNacimiento; }
            set { this.fechaNacimiento = value; }
        }
                
        public List<Prestamo> ListaPrestamos
        {
            get { return this.listaPrestamos; }
            set { listaPrestamos = value; }
        }
     
        public int Edad
        {
            get 
            {
                return this.FechaNacimiento.FindYears();
            }
        }

        public string ObtenerInformacionCompleta()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.ToString());
            sb.AppendLine($"Fecha de Nacimiento: {this.FechaNacimiento.ToShortDateString()}");
            sb.AppendLine($"Edad: {this.Edad} años");
            sb.AppendLine($"Genero: {this.Genero}");
            sb.AppendLine($"Email: {this.Email}");
            if (this.EsEstudiante)
            {
                sb.AppendLine($"Es estudiante UTN");
            }
            sb.AppendLine("*******************************************");
            if(this.ListaPrestamos.Count > 0)
            {
                sb.AppendLine("Material prestado: ");
                foreach (Prestamo item in this.ListaPrestamos)
                {
                    sb.AppendLine(item.ToString());
                    sb.AppendLine("<----------------------------------------->");
                }
            }
            else
            {
                sb.AppendLine("No tiene préstamos vigentes");
            }
            sb.AppendLine("*******************************************");

            return sb.ToString();
        }

        public static bool operator ==(Socio s1, Socio s2)
        {
            bool rta = false;
            if(s1 is not null && s2 is not null)
            {
                rta = s1.Nombre == s2.Nombre && s1.Apellido == s2.Apellido && s1.Dni == s2.Dni;
            }
            return rta;
        }

        public static bool operator !=(Socio s1, Socio s2)
        {
            return !(s1 == s2);
        }

        public static bool operator ==(Socio s, Prestamo p)
        {
            return s is not null && p is not null && s.ListaPrestamos.Contains(p);
        }

        public static bool operator !=(Socio s, Prestamo p)
        {
            return !(s == p);
        }

        public override bool Equals(object obj)
        {
            Socio unSocio = obj as Socio;
            return unSocio is not null && this == unSocio;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Socio: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"DNI: {this.Dni}");

            return sb.ToString();
        }
    }
}

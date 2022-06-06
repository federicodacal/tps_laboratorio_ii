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

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Socio() 
        { 

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="genero"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="email"></param>
        /// <param name="esEstudiante"></param>
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

        /// <summary>
        /// Propiedad de L/E de apellido
        /// </summary>
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

        /// <summary>
        /// Propiedad de L/E de nombre
        /// </summary>
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

        /// <summary>
        /// Propiedad de L/E de esEstudiante (UTN)
        /// </summary>
        public bool EsEstudiante
        {
            get { return this.esEstudiante; }
            set { this.esEstudiante = value; }
        }

        /// <summary>
        /// Propiedad de L/E de email
        /// </summary>
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        /// <summary>
        /// Propiedad de L/E de dni
        /// </summary>
        public long Dni
        {
            get { return this.dni; }
            set { this.dni = value; }
        }

        /// <summary>
        /// Propiedad de L/E de genero
        /// </summary>
        public EGenero Genero
        {
            get { return this.genero; }
            set { this.genero = value; }
        }

        /// <summary>
        /// Propiedad de L/E de Fecha de nacimiento
        /// </summary>
        public DateTime FechaNacimiento
        {
            get { return this.fechaNacimiento; }
            set { this.fechaNacimiento = value; }
        }

        /// <summary>
        /// Propiedad de L/E de lista prestamos
        /// </summary>
        public List<Prestamo> ListaPrestamos
        {
            get { return this.listaPrestamos; }
            set { listaPrestamos = value; }
        }

        /// <summary>
        /// Propiedad de Lectura de Edad
        /// </summary>
        public int Edad
        {
            get 
            {
                return this.FechaNacimiento.FindYears();
            }
        }

        /// <summary>
        /// Obtiene la informacion del socio
        /// </summary>
        /// <returns>Retorna la información completa del socio</returns>
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

        /// <summary>
        /// Compara por nombre, apellido y dni
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>True si coinciden, falso contrario</returns>
        public static bool operator ==(Socio s1, Socio s2)
        {
            bool rta = false;
            if(s1 is not null && s2 is not null)
            {
                rta = s1.Nombre == s2.Nombre && s1.Apellido == s2.Apellido && s1.Dni == s2.Dni;
            }
            return rta;
        }

        /// <summary>
        /// Comparar por nombre, apellido y dni
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>True si son distintos, false caso contrario</returns>
        public static bool operator !=(Socio s1, Socio s2)
        {
            return !(s1 == s2);
        }

        /// <summary>
        /// Verifica si el socio tiene el prestamo en su lista
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns>True si se encuentra, falso caso contrario</returns>
        public static bool operator ==(Socio s, Prestamo p)
        {
            return s is not null && p is not null && s.ListaPrestamos.Contains(p);
        }

        /// <summary>
        /// Verifica que el prestamo no este en socio
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns>True si no está, falso si lo encuentra</returns>
        public static bool operator !=(Socio s, Prestamo p)
        {
            return !(s == p);
        }

        /// <summary>
        /// Compara por mismo criterio que == (nombre, apellido y dni)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True si son iguales, falso caso contrario</returns>
        public override bool Equals(object obj)
        {
            Socio unSocio = obj as Socio;
            return unSocio is not null && this == unSocio;
        }

        /// <summary>
        /// Metodo ToString()
        /// </summary>
        /// <returns>Retorna nombre apellido y dni del socio</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Socio: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"DNI: {this.Dni}");

            return sb.ToString();
        }
    }
}

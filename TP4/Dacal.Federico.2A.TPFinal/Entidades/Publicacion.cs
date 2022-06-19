using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Paper))]
    [XmlInclude(typeof(Novela))]
    [XmlInclude(typeof(PublicacionUniversitaria))]
    public abstract class Publicacion
    {
        protected string id;
        protected string titulo;
        protected string autor;
        protected string editorial;
        protected int anioPublicacion;
        protected bool estaDisponible;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Publicacion()
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titulo"></param>
        /// <param name="autor"></param>
        /// <param name="editorial"></param>
        /// <param name="anioPublicacion"></param>
        public Publicacion(string id, string titulo, string autor, string editorial, int anioPublicacion)
        {
            this.id = id;
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
            this.anioPublicacion = anioPublicacion;
            this.estaDisponible = true;
        }

        /// <summary>
        /// Propiedad L/E de id
        /// </summary>
        public string Id 
        {
            get { return this.id; }
            set { this.id = value; } 
        }

        /// <summary>
        /// Propiedad L/E de titulo
        /// </summary>
        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }

        /// <summary>
        /// Propiedad L/E de autor
        /// </summary>
        public string Autor
        {
            get { return this.autor; }
            set { this.autor = value; }
        }

        /// <summary>
        /// Propiedad L/E de editorial
        /// </summary>
        public string Editorial
        {
            get { return this.editorial; }
            set { this.editorial = value; }
        }

        /// <summary>
        /// Propiedad L/E de anioPublicacion
        /// </summary>
        public int AnioPublicacion
        {
            get { return this.anioPublicacion; }
            set { this.anioPublicacion = value; }
        }

        /// <summary>
        /// Propiedad L/E de estaDisponible
        /// </summary>
        public bool EstaDisponible
        {
            get { return this.estaDisponible; }
            set { this.estaDisponible = value; }
        }

        /// <summary>
        /// Porpiedad de Lectura de Tipo devuelve un string del tipo del objeto
        /// </summary>
        public string Tipo 
        {
            get { return this.GetType().Name ; } 
        }

        /// <summary>
        /// Propeidad lectura de esMaterialUtnFra
        /// </summary>
        protected abstract bool EsMaterialDeUTNFra { get; }

        /// <summary>
        /// Sobrecarga del operador == compara dos publicaciones por Tipo y por atributo id
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True si se cumple la comparacion, falso caso contrario</returns>
        public static bool operator ==(Publicacion p1, Publicacion p2)
        {
            bool rta = false;
            if(p1 is not null && p2 is not null)
            {
                rta = p1.Equals(p2) && p1.Id == p2.Id;
            }
            return rta;
        }

        /// <summary>
        /// Operador =! compara si dos publicaciones son de distinto Tipo y/o id
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True si son distintos, falso caso contrario</returns>
        public static bool operator !=(Publicacion p1, Publicacion p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Método toString()
        /// </summary>
        /// <returns>Retorna los datos de la publicacion</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Titulo: '{this.Titulo}'");
            sb.AppendLine($"Autor: {this.Autor}");
            sb.AppendLine($"Editorial: {this.Editorial}");
            sb.AppendLine($"Año: {this.AnioPublicacion}");
            sb.AppendLine($"Codigo: {this.Id}");

            return sb.ToString();
        }
        

    }
}

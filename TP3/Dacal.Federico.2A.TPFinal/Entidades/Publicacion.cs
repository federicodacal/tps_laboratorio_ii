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

        public Publicacion()
        {

        }

        public Publicacion(string id, string titulo, string autor, string editorial, int anioPublicacion)
        {
            this.id = id;
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
            this.anioPublicacion = anioPublicacion;
            this.estaDisponible = true;
        }

        public string Id 
        {
            get { return this.id; }
            set { this.id = value; } 
        }

        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }

        public string Autor
        {
            get { return this.autor; }
            set { this.autor = value; }
        }

        public string Editorial
        {
            get { return this.editorial; }
            set { this.editorial = value; }
        }

        public int AnioPublicacion
        {
            get { return this.anioPublicacion; }
            set { this.anioPublicacion = value; }
        }

        public bool EstaDisponible
        {
            get { return this.estaDisponible; }
            set { this.estaDisponible = value; }
        }

        public string Tipo 
        {
            get { return this.GetType().Name ; } 
        }

        protected abstract bool EsMaterialDeUTNFra { get; }


        public static bool operator ==(Publicacion p1, Publicacion p2)
        {
            bool rta = false;
            if(p1 is not null && p2 is not null)
            {
                rta = p1.Equals(p2) && p1.Id == p2.Id;
            }
            return rta;
        }

        public static bool operator !=(Publicacion p1, Publicacion p2)
        {
            return !(p1 == p2);
        }

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

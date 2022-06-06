using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PublicacionUniversitaria : Publicacion
    {
        private List<ECampo> campos;
        private string catedra;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public PublicacionUniversitaria()
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titulo"></param>
        /// <param name="autor"></param>
        /// <param name="anioPublicacion"></param>
        /// <param name="campos"></param>
        /// <param name="catedra"></param>
        public PublicacionUniversitaria(string id, string titulo, string autor, int anioPublicacion, List<ECampo> campos, string catedra) 
            :base(id, titulo, autor, "UTN-Fra", anioPublicacion)
        {
            this.campos = campos;
            this.catedra = catedra;
        }

        /// <summary>
        /// Propiedad L/E de campos
        /// </summary>
        public List<ECampo> Campos
        {
            get { return this.campos; }
            set { this.campos = value; }
        }

        /// <summary>
        /// Propiedad L/E de catedra
        /// </summary>
        public string Catedra
        {
            get { return this.catedra; }
            set { this.catedra = value; }
        }

        /// <summary>
        /// Propiedad de Lectura que devuelve si es material de utn
        /// </summary>
        protected override bool EsMaterialDeUTNFra
        {
            get { return true; }
        }

        /// <summary>
        /// Equals compara que sean del mismo tipo
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si son del mismo tipo PublicacionUniversitario, falso caso contrario</returns>
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(PublicacionUniversitaria);
        }

        /// <summary>
        /// Metodo ToString()
        /// </summary>
        /// <returns>Retorna los datos del objeto PublicacionUniversitaria</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());           
            sb.AppendLine($"Catedra: {this.catedra}");
            sb.Append($"Area: ");

            for (int i = 0; i < this.Campos.Count; i++)
            {
                if (i == this.Campos.Count - 1)
                {
                    sb.Append($"{this.Campos[i]}.");
                }
                else
                {
                    sb.Append($"{this.Campos[i]}, ");
                }
            }

            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paper : Publicacion
    {       
        private List<ECampo> campos;

        /// <summary>
        /// Constructor por defecto de Paper
        /// </summary>
        public Paper()
        {

        }

        /// <summary>
        /// Constructor parametrizado de Paper
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titulo"></param>
        /// <param name="autor"></param>
        /// <param name="editorial"></param>
        /// <param name="anioPublicacion"></param>
        /// <param name="campos"></param>
        public Paper(string id, string titulo, string autor, string editorial, int anioPublicacion, List<ECampo> campos)
            :base(id, titulo, autor, editorial, anioPublicacion)
        {
            this.campos = campos;
        }

        /// <summary>
        /// Propiedad de L/E del atributo campos
        /// </summary>
        public List<ECampo> Campos
        {
            get { return this.campos; }
            set { this.campos = value; }
        }

        /// <summary>
        /// Propiedad de Lectura que retorna si es material de UTN-Fra
        /// </summary>
        protected override bool EsMaterialDeUTNFra
        {
            get { return false; }
        }

        /// <summary>
        /// Sobrescritura de metodo Equals que compara los tipos
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si son de la misma clase Paper, False en caso contrario</returns>
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Paper);
        }

        /// <summary>
        /// Sobrescritura del metodo ToString()
        /// </summary>
        /// <returns>Retorna los datos del objeto Paper</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append($"Área: ");

            for (int i = 0; i < this.Campos.Count; i++)
            {
                if(i == this.Campos.Count - 1)
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

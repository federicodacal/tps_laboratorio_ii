using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Novela : Publicacion
    {
        public enum EGeneroLiterario { CienciaFiccion, Drama, Aventura, Policial, Fantasia, Terror, Misterio, Realista, Distopia }

        private List<EGeneroLiterario> generos;

        /// <summary>
        /// Constructor por defecto de Novela
        /// </summary>
        public Novela()
        {

        }

        /// <summary>
        /// Constructor parametrizado de Novela
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titulo"></param>
        /// <param name="autor"></param>
        /// <param name="editorial"></param>
        /// <param name="anioPublicacion"></param>
        /// <param name="generos"></param>
        public Novela(string id, string titulo, string autor, string editorial, int anioPublicacion, List<EGeneroLiterario> generos) 
            :base(id, titulo, autor, editorial, anioPublicacion)
        {
            this.generos = generos;
        }

        /// <summary>
        /// Propiedad de L/E de los generos
        /// </summary>
        public List<EGeneroLiterario> Generos
        {
            get { return this.generos; }
            set { this.generos = value; }
        }

        /// <summary>
        /// Propiedad de Lectura que retorna si el material pertenece a UTN-Fra
        /// </summary>
        protected override bool EsMaterialDeUTNFra
        {
            get { return false; }
        }

        /// <summary>
        /// Sobrescritura del metodo Equals retorna la comparacion por tipo
        /// </summary>
        /// <param name="obj">Ojeto a comparar</param>
        /// <returns>True si son del mismo tipo Novela, false caso contrario</returns>
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Novela);
        }

        /// <summary>
        /// Sobrescritura del método ToString()
        /// </summary>
        /// <returns>Retorna los datos del objeto Novela</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append($"Genero: ");

            for (int i = 0; i < this.Generos.Count; i++)
            {
                if (i == this.Generos.Count - 1)
                {
                    sb.Append($"{this.Generos[i]}.");
                }
                else
                {
                    sb.Append($"{this.Generos[i]}, ");
                }
            }
            return sb.ToString();
        }

    }
}

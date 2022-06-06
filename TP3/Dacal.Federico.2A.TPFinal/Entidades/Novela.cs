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


        public Novela()
        {

        }

        public Novela(string id, string titulo, string autor, string editorial, int anioPublicacion, List<EGeneroLiterario> generos) 
            :base(id, titulo, autor, editorial, anioPublicacion)
        {
            this.generos = generos;
        }

        public List<EGeneroLiterario> Generos
        {
            get { return this.generos; }
            set { this.generos = value; }
        }

        protected override bool EsMaterialDeUTNFra
        {
            get { return false; }
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Novela);
        }

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

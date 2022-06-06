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

        public Paper()
        {

        }

        public Paper(string id, string titulo, string autor, string editorial, int anioPublicacion, List<ECampo> campos)
            :base(id, titulo, autor, editorial, anioPublicacion)
        {
            this.campos = campos;
        }

        public List<ECampo> Campos
        {
            get { return this.campos; }
            set { this.campos = value; }
        }

        protected override bool EsMaterialDeUTNFra
        {
            get { return false; }
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Paper);
        }

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

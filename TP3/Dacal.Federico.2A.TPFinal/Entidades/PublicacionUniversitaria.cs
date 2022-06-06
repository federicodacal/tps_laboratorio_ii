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

        public PublicacionUniversitaria()
        {

        }

        public PublicacionUniversitaria(string id, string titulo, string autor, int anioPublicacion, List<ECampo> campos, string catedra) 
            :base(id, titulo, autor, "UTN-Fra", anioPublicacion)
        {
            this.campos = campos;
            this.catedra = catedra;
        }

        public List<ECampo> Campos
        {
            get { return this.campos; }
            set { this.campos = value; }
        }

        public string Catedra
        {
            get { return this.catedra; }
            set { this.catedra = value; }
        }

        protected override bool EsMaterialDeUTNFra
        {
            get { return true; }
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(PublicacionUniversitaria);
        }

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

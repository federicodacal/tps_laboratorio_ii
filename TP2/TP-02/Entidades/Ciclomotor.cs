using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        /// <summary>
        /// Constructor parametrizado de objeto de tipo Ciclomotor
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            :base(chasis, marca, color)
        {
        }
        
        /// <summary>
        /// ReadOnly. Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get { return ETamanio.Chico; }
        }

        /// <summary>
        /// Muestra los datos de un objeto de tipo Ciclomotor
        /// </summary>
        /// <returns>Un string con los datos del Ciclomotor</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}

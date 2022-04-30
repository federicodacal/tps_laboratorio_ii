using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        /// <summary>
        /// Constructor parametrizado de objeto de tipo Suv
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Suv(Vehiculo.EMarca marca, string chasis, ConsoleColor color)
            :base(chasis, marca, color)
        {

        }

        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get { return ETamanio.Grande; }
        }

        /// <summary>
        /// Muestra los datos de un objeto Suv
        /// </summary>
        /// <returns>Un string con la informacion</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}

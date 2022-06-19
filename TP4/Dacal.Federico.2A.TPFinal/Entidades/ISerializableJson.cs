using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interface para Serializar Json
    /// </summary>
    /// <typeparam name="T">Tipo genérico T que sea de referencia</typeparam>
    public interface ISerializableJson<T>
        where T : class
    {

        void Serializar(string path, T contenido);

        T Deserializar(string path);
    }
}

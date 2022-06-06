using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ISerializableJson<T>
        where T : class
    {

        void Serializar(string path, T contenido);

        T Deserializar(string path);
    }
}

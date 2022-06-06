using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Serializadora<T> : ISerializableJson<T>
        where T : class, new()
    {
        public static void Serializar(string path, T objeto)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, objeto);
            }
        }

        public static T Deserializar(string path)
        {
            T objeto = null;
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    objeto = xs.Deserialize(sr) as T;                   
                }
            }
            return objeto;
        }

        void ISerializableJson<T>.Serializar(string path, T contenido)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fecha = DateTime.Now.ToString("HH_mm_ss");

            using (StreamWriter sw = new StreamWriter($@"{path}\socio_{fecha}.json"))
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string json = JsonSerializer.Serialize(contenido, options);
                sw.WriteLine(json);
            }
        }

        T ISerializableJson<T>.Deserializar(string path)
        {
            T contenido = null;
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string json = sr.ReadToEnd();
                    contenido = JsonSerializer.Deserialize<T>(json);
                }
            }
            return contenido;
        }
    }
}

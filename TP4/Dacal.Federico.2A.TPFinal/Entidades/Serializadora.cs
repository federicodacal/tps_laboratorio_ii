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
    /// <summary>
    /// Clase genérica para serializar y deserializar .xml y .json
    /// </summary>
    /// <typeparam name="T">Tipo de referencia con constructor por defecto</typeparam>
    public class Serializadora<T> : ISerializableJson<T>
        where T : class, new()
    {
        /// <summary>
        /// Serializa a xml
        /// </summary>
        /// <param name="path"></param>
        /// <param name="objeto"></param>
        public static void Serializar(string path, T objeto)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, objeto);
            }
        }

        /// <summary>
        /// Deserializa a partir de xml
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Serializa a json
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contenido"></param>
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

        /// <summary>
        /// Deserializa a partir de json
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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

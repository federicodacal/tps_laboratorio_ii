using System;
using System.Collections.Generic;
using System.IO;
using Entidades;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Socio s0 = new Socio("Pedro", "Perez", 42323765, Socio.EGenero.Masculino, new DateTime(2000, 12, 1), "pedroperez@gmail.com", true);
            Socio s1 = new Socio("Juana", "Lopez", 4323367, Socio.EGenero.Femenino, new DateTime(2001, 1, 2), "juanalop@gmail.com", true);
            Socio s2 = new Socio("Juan Carlos", "Perez", 31324445, Socio.EGenero.Masculino, new DateTime(1992, 2, 5), "juanca@yahoo.com", false);
            Socio s3 = new Socio("Alfonso", "Alonso", 32119768, Socio.EGenero.Masculino, new DateTime(1993, 11, 1), "alal@gmail.com", false);
            Socio s4 = new Socio("Ana", "Fernandez", 38333223, Socio.EGenero.Femenino, new DateTime(1993, 4, 11), "anaf@gmail.com", true);
            Socio s5 = new Socio("Miguel", "Carrasco", 40113800, Socio.EGenero.Masculino, new DateTime(1999, 12, 1), "miguecarrasco@hotmail.com", true);

            List<Socio> lista = new List<Socio>();

            lista.Add(s0);
            lista.Add(s1);
            lista.Add(s2);
            lista.Add(s3);
            lista.Add(s4);
            lista.Add(s5);

            

            List<Publicacion> lista = new List<Publicacion>();

            Novela n1 = new Novela("N100", "Brave New World", "Aldous Huxley", "Universal", 1932, new List<Novela.EGeneroLiterario> { Novela.EGeneroLiterario.CienciaFiccion, Novela.EGeneroLiterario.Distopia});

            Novela n2 = new Novela("N101", "1984", "George Orwell", "Universal", 1949, new List<Novela.EGeneroLiterario> { Novela.EGeneroLiterario.CienciaFiccion, Novela.EGeneroLiterario.Distopia });

            Novela n3 = new Novela("N102", "War and Peace", "Leo Tolstoy", "Serialised", 1869, new List<Novela.EGeneroLiterario> { Novela.EGeneroLiterario.Drama, Novela.EGeneroLiterario.Realista });

            Novela n4 = new Novela("N103", "Anna Karenina", "Leo Tolstoy", "Serialised", 1878, new List<Novela.EGeneroLiterario> { Novela.EGeneroLiterario.Drama, Novela.EGeneroLiterario.Realista });

            Novela n5 = new Novela("N104", "Cien años de Soledad", "Gabriel García Márquez", "Sudamericana", 1967, new List<Novela.EGeneroLiterario> { Novela.EGeneroLiterario.Drama, Novela.EGeneroLiterario.Realista });

            Novela n6 = new Novela("N105", "El amor en tiempos de cólera", "Gabriel García Márquez", "Sudamericana", 1985, new List<Novela.EGeneroLiterario> { Novela.EGeneroLiterario.Drama, Novela.EGeneroLiterario.Realista });

            Novela n7 = new Novela("N106", "The Waves", "Virginia Woolf", "Hogarth", 1931, new List<Novela.EGeneroLiterario> { Novela.EGeneroLiterario.Drama, Novela.EGeneroLiterario.Fantasia });

            Novela n8 = new Novela("N107", "Sense and Sensibility", "Jane Austen", "UK Print", 1811, new List<Novela.EGeneroLiterario> { Novela.EGeneroLiterario.Drama, Novela.EGeneroLiterario.Realista });

            Novela n9 = new Novela("N108", "Salem's Lot", "Stephen King", "Doubleday", 1975, new List<Novela.EGeneroLiterario> { Novela.EGeneroLiterario.Terror, Novela.EGeneroLiterario.Misterio });

            Novela n10 = new Novela("N109", "Murder on the Orient Express", "Agatha Christie", "US Print", 1934, new List<Novela.EGeneroLiterario> { Novela.EGeneroLiterario.Policial, Novela.EGeneroLiterario.Misterio });

            Novela n11 = new Novela("N110", "Historias de Cronopios y de Famas", "Julio Cortázar", "Minotauro", 1962, new List<Novela.EGeneroLiterario> { Novela.EGeneroLiterario.Fantasia });

            
            PublicacionUniversitaria puniv1 = new PublicacionUniversitaria("PUNIV001", "C# Avanzado", "Federico Dávila", 2019, new List<ECampo>() { ECampo.Computacion }, "Laboratorio II");

            PublicacionUniversitaria puniv2 = new PublicacionUniversitaria("PUNIV002", "Programación Multi-hilo", "Lucas Rodriguez", 2021, new List<ECampo>() { ECampo.Computacion }, "Laboratorio II");

            PublicacionUniversitaria puniv3 = new PublicacionUniversitaria("PUNIV003", "Principios SOLID", "Mauricio Cerizza", 2021, new List<ECampo>() { ECampo.Computacion, ECampo.IT }, "Laboratorio II");
            
            PublicacionUniversitaria puniv4 = new PublicacionUniversitaria("PUNIV004", "Guía de Arduino con C", "Christian Baus", 2018, new List<ECampo>() { ECampo.Computacion, ECampo.Electronica }, "Sist. Procesamiento de Datos");

            PublicacionUniversitaria puniv5 = new PublicacionUniversitaria("PUNIV005", "Problemáticas Sociales del Siglo XXI", "Jorge Suarez", 2018, new List<ECampo>() { ECampo.Sociologia }, "Ciencias Sociales");

            PublicacionUniversitaria puniv6 = new PublicacionUniversitaria("PUNIV006", "Analisis de Datos y Sistemas", "Romeo Rescaldani", 2018, new List<ECampo>() { ECampo.IT, ECampo.CienciaDeDatos}, "Analisis de Sistemas");

            PublicacionUniversitaria puniv7 = new PublicacionUniversitaria("PUNIV007", "Ciencia de Datos para Negocios", "José Suar", 2022, new List<ECampo>() { ECampo.Negocios, ECampo.CienciaDeDatos}, "Ciencia de Datos");

            PublicacionUniversitaria puniv8 = new PublicacionUniversitaria("PUNIV008", "Teoría de Juegos y Geopolítica", "Laura Gómez", 2020, new List<ECampo>() { ECampo.Economia, ECampo.Matematica}, "Probabilidad y Estadística");

            PublicacionUniversitaria puniv9 = new PublicacionUniversitaria("PUNIV009", "Energía Nuclear", "Florencia J. Rossini", 2014, new List<ECampo>() { ECampo.Energias}, "Ing. Civil");

            PublicacionUniversitaria puniv10 = new PublicacionUniversitaria("PUNIV010", "Algoritmos: Inteligencia Artificial", "Roberto Miguelete", 2021, new List<ECampo>() { ECampo.Computacion, ECampo.IA}, "Programación Avanzada");

            

            Paper p1 = new Paper("P-001", "Machine learning: Trends, perspectives, and prospects", "T.M. Mitchell", "Science AAAS", 2015, new List<ECampo>() { ECampo.IA, ECampo.Computacion});

            Paper p2 = new Paper("P-002", "Machine Learning in Agriculture", "Konstantinos Liakos", "LIAT", 2018, new List<ECampo>() { ECampo.IA, ECampo.Economia});

            Paper p3 = new Paper("P-003", "Fundamental Algorithms", "Donald Knuth", "LIAT", 1973, new List<ECampo>() { ECampo.Computacion, ECampo.IT});

            Paper p4 = new Paper("P-004", "Data Mining Algorithms", "Cristóbal Romero", "U. de Córdoba", 2021, new List<ECampo>() { ECampo.Computacion, ECampo.CienciaDeDatos});

            Paper p5 = new Paper("P-005", "Oil in the Seas", "Franklyn Hobart", "National Research", 2003, new List<ECampo>() { ECampo.Energias, ECampo.Quimica});



            lista.Add(n1);
            lista.Add(n2);
            lista.Add(n3);
            lista.Add(n4);
            lista.Add(n5);
            lista.Add(n6);
            lista.Add(n7);
            lista.Add(n8);
            lista.Add(n9);
            lista.Add(n10);
            lista.Add(n11);

            lista.Add(puniv1);
            lista.Add(puniv2);
            lista.Add(puniv3);
            lista.Add(puniv4);
            lista.Add(puniv5);
            lista.Add(puniv6);
            lista.Add(puniv7);
            lista.Add(puniv8);
            lista.Add(puniv9);
            lista.Add(puniv10);

            lista.Add(p1);
            lista.Add(p2);
            lista.Add(p3);
            lista.Add(p4);
            lista.Add(p5);

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "publicaciones.xml");

            Serializadora<List<Publicacion>>.Serializar(path, lista);

            List<Publicacion> auxLista = Serializadora<List<Publicacion>>.Deserializar(path);

            foreach (Publicacion item in auxLista)
            {
                Console.WriteLine("****************************************");
                Console.WriteLine(item.ToString());
                Console.WriteLine("****************************************");
            }
            */

        }
    }
}

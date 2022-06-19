using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class SocioDAO
    {
        private static string connectionString;
        private static SqlCommand command;
        private static SqlConnection connection;

        static SocioDAO()
        {
            connectionString = @"Data Source=localhost;Initial Catalog=BIBLIOTECA_UTN; Integrated Security=True";

            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
        }

        public static List<Socio> Leer()
        {
            List<Socio> socios = new List<Socio>();
            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Socios";
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    socios.Add(new Socio(dataReader["nombre"].ToString(),
                                         dataReader["apellido"].ToString(),
                                         Convert.ToInt64(dataReader["dni"]),
                                         (Socio.EGenero)Convert.ToInt32(dataReader["genero"]),
                                         Convert.ToDateTime(dataReader["fecha_nacimiento"]),
                                         dataReader["email"].ToString(),
                                         Convert.ToBoolean(dataReader["es_estudiante"])));
                }

                return socios;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static bool Eliminar(long dni)
        {
            bool rta;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"DELETE FROM Socios WHERE dni = {dni}";

                int affectedRows = command.ExecuteNonQuery();

                if(affectedRows == 0)
                {
                    rta = false;
                }
                else
                {
                    rta = true;
                }
            }
            catch (Exception e)
            {
                rta = false;
                throw new Exception(e.Message, e);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return rta;
        }

        public static bool Guardar(Socio socio)
        {
            bool rta;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "INSERT INTO Socios (dni, nombre, apellido, email, fecha_nacimiento, genero, es_estudiante) VALUES (@dni, @nombre, @apellido, @email, @fecha_nacimiento, @genero, @es_estudiante)";
                command.Parameters.AddWithValue("@dni", socio.Dni);
                command.Parameters.AddWithValue("@nombre", socio.Nombre);
                command.Parameters.AddWithValue("@apellido", socio.Apellido);
                command.Parameters.AddWithValue("@email", socio.Email);
                command.Parameters.AddWithValue("@es_estudiante", socio.EsEstudiante);
                command.Parameters.AddWithValue("@genero", socio.Genero);
                command.Parameters.AddWithValue("@fecha_nacimiento", socio.FechaNacimiento);

                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    rta = false;
                }
                else
                {
                    rta = true;
                }

            }
            catch (Exception e)
            {
                rta = false;
                throw new Exception(e.Message, e);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return rta;
        }

        public static bool Modificar(Socio socio)
        {
            bool rta;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE Socios SET nombre = @nombre, apellido = @apellido, email = @email, es_estudiante = @es_estudiante, genero = @genero, fecha_nacimiento = @fecha_nacimiento WHERE dni = {socio.Dni}";
                command.Parameters.AddWithValue("@dni", socio.Dni);
                command.Parameters.AddWithValue("@nombre", socio.Nombre);
                command.Parameters.AddWithValue("@apellido", socio.Apellido);
                command.Parameters.AddWithValue("@email", socio.Email);
                command.Parameters.AddWithValue("@es_estudiante", socio.EsEstudiante);
                command.Parameters.AddWithValue("@genero", socio.Genero);
                command.Parameters.AddWithValue("@fecha_nacimiento", socio.FechaNacimiento);

                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    rta = false;
                }
                else
                {
                    rta = true;
                }

            }
            catch (Exception e)
            {
                rta = false;
                throw new Exception(e.Message, e);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return rta;
        }

    }
}

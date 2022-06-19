using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PrestamoDAO
    {
        private static string connectionString;
        private static SqlCommand command;
        private static SqlConnection connection;

        static PrestamoDAO()
        {
            connectionString = @"Data Source=localhost;Initial Catalog=DB_BIBLIOTECA_UTN; Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
        }

        public static List<Prestamo> Leer()
        {
            List<Prestamo> prestamos = new List<Prestamo>();

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Prestamos";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    prestamos.Add(new Prestamo(dataReader["id"].ToString(),
                                               dataReader["titulo"].ToString(),
                                               Convert.ToDateTime(dataReader["fecha_prestamo"]),
                                               Convert.ToInt64(dataReader["dni_socio"])));
                }

                return prestamos;
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

        public static bool Borrar(Prestamo p)
        {
            bool rta;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"DELETE FROM Prestamos WHERE id = @idPrestamo";
                command.Parameters.AddWithValue("@idPrestamo", p.Id);

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


        public static bool Guardar(Prestamo p)
        {
            bool rta;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "INSERT INTO Prestamos (id, fecha_prestamo, dni_socio, titulo) VALUES (@id, @fecha_prestamo, @dni_socio, @titulo)";
                command.Parameters.AddWithValue("@id", p.Id);
                command.Parameters.AddWithValue("@fecha_prestamo", p.FechaPrestamo);
                command.Parameters.AddWithValue("@dni_socio", p.DniSocio);
                command.Parameters.AddWithValue("@titulo", p.Titulo);

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

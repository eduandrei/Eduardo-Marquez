using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final.ADO.NET
{
    public class UsuarioHandler : DataBaseHandler
    {
        public void DeleteUsuario(int Id)
        {
            string query = "DELETE FROM Usuario " +
                "WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", Id);

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("Hay un error en la definición de la consulta! " + ex.Message);
                }
            }
        }
        public void UpdateUsuario(int Id, string Nombre, string Apellido, string NombreUsuario, string Contrasena, string Mail)
        {
            string query = "UPDATE Usuario " +
                "SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreUsuario, Contraseña = @contrasena, Mail = @mail " +
                "WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", Id);
                sqlCommand.Parameters.AddWithValue("@nombre", Nombre);
                sqlCommand.Parameters.AddWithValue("@apellido", Apellido);
                sqlCommand.Parameters.AddWithValue("@nombreUsuario", NombreUsuario);
                sqlCommand.Parameters.AddWithValue("@contrasena", Contrasena);
                sqlCommand.Parameters.AddWithValue("@mail", Mail);

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("Hay un error en la definición de la consulta! " + ex.Message);
                }
            }
        }
        public void InsertUsuario(string Nombre, string Apellido, string NombreUsuario, string Contrasena, string Mail)
        {
            string query = "INSERT INTO Usuario" +
                "(Nombre, Apellido, NombreUsuario, Contraseña, Mail)" +
                "VALUES (@nombre, @apellido, @nombreUsuario, @contrasena, @mail)";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nombre", Nombre);
                sqlCommand.Parameters.AddWithValue("@apellido", Apellido);
                sqlCommand.Parameters.AddWithValue("@nombreUsuario", NombreUsuario);
                sqlCommand.Parameters.AddWithValue("@contrasena", Contrasena);
                sqlCommand.Parameters.AddWithValue("@mail", Mail);

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("Hay un error en la definición de la consulta! " + ex.Message);
                }
            }
        }
        public List<Usuario> GetUsuario()
        {
            Console.WriteLine("***** Showing Usuario Table from SQL DataBase ***** \r\n");
            Console.WriteLine($"Id|   Nombre|    Apellido|  Nombre Usuario|  Contraseña|  Mail");
            List<Usuario> listausuario = new List<Usuario>();

            string query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        usuario.Nombre = sqlDataReader["Nombre"].ToString();
                        usuario.Apellido = sqlDataReader["Apellido"].ToString();
                        usuario.NombreUsuario = sqlDataReader["NombreUsuario"].ToString();
                        usuario.Contrasena = sqlDataReader["Contraseña"].ToString();
                        usuario.Mail = sqlDataReader["Mail"].ToString();
                        listausuario.Add(usuario);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la definición de la consulta! " + ex.Message);
                }
            }

            foreach (var item in listausuario)
            {
                Console.WriteLine($"{item.Id}|  {item.Nombre}|    {item.Apellido}|  {item.NombreUsuario}|  {item.Contrasena}|  {item.Mail}");
            }

            return listausuario;
        }
        public List<User> GetUsuarioById(int id)
        {
            Console.WriteLine("***** Showing Usuario Table from SQL DataBase ***** \r\n");
            Console.WriteLine($"Id|   Nombre|    Apellido|  Nombre Usuario|  Contraseña|  Mail");
            List<Usuario> listausuario = new List<Usuario>();
            string query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario " +
                "WHERE Id = @id;";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        usuario.Nombre = sqlDataReader["Nombre"].ToString();
                        usuario.Apellido = sqlDataReader["Apellido"].ToString();
                        usuario.NombreUsuario = sqlDataReader["NombreUsuario"].ToString();
                        usuario.Contrasena = sqlDataReader["Contraseña"].ToString();
                        usuario.Mail = sqlDataReader["Mail"].ToString();
                        listausuario.Add(usuario);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("THay un error en la definición de la consulta! " + ex.Message);
                }
            }

            foreach (var item in listausuario)
            {
                Console.WriteLine($"{item.Id}|  {item.Nombre}|    {item.Apellido}|  {item.NombreUsuario}|  {item.Contrasena}|  {item.Mail}");
            }

            return listausuario;
        }
        public List<Usuario> GetUsuario()
        {
            Console.WriteLine("***** Showing Usuario Table from SQL DataBase ***** \r\n");
            Console.WriteLine($"Id|   Nombre|    Apellido|  Nombre Usuario|  Contraseña|  Mail");
            List<Usuario> listausuario = new List<Usuario>();
            string query = "SELECT Top(1) Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario ORDER BY Id DESC";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        usuario.Nombre = sqlDataReader["Nombre"].ToString();
                        usuario.Apellido = sqlDataReader["Apellido"].ToString();
                        usuario.NombreUsuario = sqlDataReader["NombreUsuario"].ToString();
                        usuario.Contrasena = sqlDataReader["Contraseña"].ToString();
                        usuario.Mail = sqlDataReader["Mail"].ToString();
                        listausuario.Add(usuario);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
            }

            foreach (var item in listausuario)
            {
                Console.WriteLine($"{item.Id}|  {item.Nombre}|    {item.Apellido}|  {item.NombreUsuario}|  {item.Contrasena}|  {item.Mail}");
            }

            return listausuario;
        }
        public bool GetUsersByUserName(string NombreUsuario, string Password)
        {
            List<Usuario> listausuario = new List<Usuario>();
            string query = "SELECT Nombre FROM Usuario  " +
                "WHERE NombreUsuario = @userName AND Contraseña = @password; ";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@userName", NombreUsuario);
                sqlCommand.Parameters.AddWithValue("@password", Password);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (!sqlDataReader.Read())
                    {
                        Console.WriteLine("El nombre de usuario o la contraseña son incorrectos, es imposible iniciar sesión");

                        return false;
                    }
                    while (sqlDataReader.Read())
                    {
                        Usuario usuariobje = new Usuario();
                        usuariobje.Contrasena = sqlDataReader["Nombre"].ToString();
                        listausuario.Add(usuariobje);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la definición de la consulta!! " + ex.Message);
                }
            }

            return true;
        }
    }
}

   
        
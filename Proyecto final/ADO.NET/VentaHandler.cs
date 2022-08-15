using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final.ADO.NET
{
    public class VentaHandler : DataBaseHandler
    {
        public void DeleteVenta(int Id)
        {
            string query = "DELETE FROM Venta " +
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

                    throw new Exception("Hay un error en la definición de la consulta!! " + ex.Message);
                }
            }
        }
        public void UpdateVenta(int Id, string Comentarios)
        {
            string query = "UPDATE Venta " +
                "SET Comentarios = @comentarios " +
                "WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", Id);
                sqlCommand.Parameters.AddWithValue("@comentarios", Comentarios);

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("Hay un error en la definición de la consulta!! " + ex.Message);
                }
            }
        }
        public void InsertVEnta(string Comentarios)
        {
            string query = "INSERT INTO Venta" +
                "(Comentarios)" +
                "VALUES (@comentarios)";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@comentarios", Comentarios);

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("Hay un error en la definición de la consulta " + ex.Message);
                }
            }
        }
        public List<Venta> GetVentas()
        {
            Console.WriteLine("***** Showing Venta Table from SQL DataBase ***** \r\n");
            Console.WriteLine($"Id|   Comentarios");
            List<Venta> listaventas = new List<Venta>();
            string query = "SELECT Id, Comentarios FROM Venta";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Venta venta = new Venta();
                        venta.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        venta.Comentarios = sqlDataReader["Comentarios"].ToString();
                        listaventas.Add(venta);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la definición de la consulta! " + ex.Message);
                }
            }

            foreach (var item in listaventas)
            {
                Console.WriteLine($"{item.Id}|      {item.Comentarios}");
            }

            return listaventas;
        }
        public List<Ventas> GetVentasById(int id)
        {
            Console.WriteLine("***** SMostrando la tabla Venta de la base de datos SQL ***** \r\n");
            Console.WriteLine($"Id|   Comentarios");
            List<Venta> listaventa = new List<Venta>();
            string query = "SELECT Id, Comentarios FROM Venta " +
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
                        Venta venta = new Sales();
                        venta.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        venta.Comentarios = sqlDataReader["Comentarios"].ToString();
                        listaventa.Add(venta);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la definición de la consulta! " + ex.Message);
                }
            }

            foreach (var item in listaventa)
            {
                Console.WriteLine($"{item.Id}|      {item.Comentarios}");
            }

            return listaventa;
        }
        public List<Ventas> GetListaVenta()
        {
            Console.WriteLine("***** Showing Venta Table from SQL DataBase ***** \r\n");
            Console.WriteLine($"Id|   Comentarios");
            List<Venta> listaventa = new List<Venta>();
            string query = "SELECT Top(1) Id, Comentarios FROM Venta ORDER BY Id DESC";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Venta venta = new Venta();
                        venta.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        venta.Comentarios = sqlDataReader["Comentarios"].ToString();
                        listaventa.Add(venta);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la definición de la consulta! " + ex.Message);
                }
            }

            foreach (var item in listaventa)
            {
                Console.WriteLine($"{item.Id}|      {item.Comentarios}");
            }

            return listaventa;
        }
    }
}
    
      
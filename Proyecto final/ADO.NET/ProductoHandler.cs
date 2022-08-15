using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final.ADO.NET
{
    public class ProductoHandler : DataBaseHandler
    {
        public void DeleteProducto(int Id)
        {
            string query = "DELETE FROM Producto " +
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
        public void UpdateProducto(int Id, string Descripciones, double Costo, double PrecioVenta, int Stock)
        {
            string query = "UPDATE Producto " +
                "SET Descripciones = @descripciones, Costo = @costo, PrecioVenta = @precioVenta, Stock = @stock " +
                "WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", Id);
                sqlCommand.Parameters.AddWithValue("@descripciones", Descripciones);
                sqlCommand.Parameters.AddWithValue("@costo", Costo);
                sqlCommand.Parameters.AddWithValue("@precioVenta", PrecioVenta);
                sqlCommand.Parameters.AddWithValue("@stock", Stock);

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception(" Hay un error en la definición de consulta! " + ex.Message);
                }
            }
        }
        public void InsertProducto(string Descripciones, double Costo, double PrecioVenta, int Stock)
        {
            string query = "INSERT INTO Producto" +
                "(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" +
                "VALUES (@descripciones, @costo, @precioVenta, @stock, 1)";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@descripciones", Descripciones);
                sqlCommand.Parameters.AddWithValue("@costo", Costo);
                sqlCommand.Parameters.AddWithValue("@precioVenta", PrecioVenta);
                sqlCommand.Parameters.AddWithValue("@stock", Stock);

                try
                {
                    sqlConnection.Open();|
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("Hay un error en la definición de la consulta! " + ex.Message);
                }
            }
        }
        public static List<Producto> GetProducto()
        {
            Console.WriteLine("***** Showing Producto Table from SQL DataBase ***** \r\n");
            Console.WriteLine($"Id|   Descripciones|    Costo|  PrecioVenta|  Stock|  IdUsuario");
            List<Producto> listaproducto = new List<Producto>();
            string query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Producto Producto = new Producto();
                        Producto.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        Producto.Descripciones = sqlDataReader["Descripciones"].ToString();
                        Producto.Costo = Convert.ToDouble(sqlDataReader["Costo"]);
                        Producto.PrecioVenta = Convert.ToDouble(sqlDataReader["PrecioVenta"]);
                        Producto.Stock = Convert.ToInt32(sqlDataReader["Stock"]);
                        Producto.IdUsuario = Convert.ToInt32(sqlDataReader["IdUsuario"]);
                        listaproducto.Add(Producto);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
            }

            foreach (var item in listaproducto)
            {
                Console.WriteLine($"{item.Id}|  {item.Descripciones}|    {item.Costo}|  {item.PrecioVenta}|  {item.Stock}|  {item.IdUsuario}");
            }

            return listaproducto;
        }
        public List<Producto> GetProductosById(int id)
        {
            Console.WriteLine("***** Showing Producto Table By ID from SQL DataBase ***** \r\n");
            Console.WriteLine($"Id|   Descripciones|    Costo|  PrecioVenta|  Stock|  IdUsuario");
            List<Producto> listaproducto = new List<Producto>();
            string query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto " +
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
                        Producto Producto = new Producto();
                        Producto.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        Producto.Descripciones = sqlDataReader["Descripciones"].ToString();
                        Producto.Costo = Convert.ToDouble(sqlDataReader["Costo"]);
                        Producto.PrecioVenta = Convert.ToDouble(sqlDataReader["PrecioVenta"]);
                        Producto.Stock = Convert.ToInt32(sqlDataReader["Stock"]);
                        Producto.IdUsuario = Convert.ToInt32(sqlDataReader["IdUsuario"]);
                        listaproducto.Add(Producto);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
            }

            foreach (var item in listaproducto)
            {
                Console.WriteLine($"{item.Id}|  {item.Descripciones}|    {item.Costo}|  {item.PrecioVenta}|  {item.Stock}|  {item.IdUsuario}");
            }

            return listaproducto;
        }
        public List<Producto> GetLastProducto()
        {
            Console.WriteLine("***** Mostrando la tabla de productos de la base de datos SQL ***** \r\n");
            Console.WriteLine($"Id|   Descripciones|    Costo|  PrecioVenta|  Stock|  IdUsuario");
            List<Producto> listaproducto = new List<Producto>();
            string query = "SELECT Top(1) Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto ORDER BY Id DESC";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Producto Producto = new Producto();
                        Producto.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        Producto.Descripciones = sqlDataReader["Descripciones"].ToString();
                        Producto.Costo = Convert.ToDouble(sqlDataReader["Costo"]);
                        Producto.PrecioVenta = Convert.ToDouble(sqlDataReader["PrecioVenta"]);
                        Producto.Stock = Convert.ToInt32(sqlDataReader["Stock"]);
                        Producto.IdUsuario = Convert.ToInt32(sqlDataReader["IdUsuario"]);
                        listaproducto.Add(Producto);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("Hay un error en la definición de la consulta! " + ex.Message);
                }
            }

            foreach (var item in listaproducto)
            {
                Console.WriteLine($"{item.Id}|  {item.Descripciones}|    {item.Costo}|  {item.PrecioVenta}|  {item.Stock}|  {item.IdUsuario}");
            }

            return listaproducto;
        }

    }
}
}
    
        
      
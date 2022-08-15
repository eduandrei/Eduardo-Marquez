using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final.ADO.NET
{
    public class ProductoVendidoHandler : DataBaseHandler
    {
        public void DeleteProductoVendido(int Id)
        {
            string query = "DELETE FROM ProductoVendido " +
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
        public void UpdateProductoVendido(int Id, int Stock, int IdProducto)
        {
            string query = "UPDATE ProductoVendido " +
                "SET Stock = @stock, IdProducto = @idProducto " +
                "WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", Id);
                sqlCommand.Parameters.AddWithValue("@stock", Stock);
                sqlCommand.Parameters.AddWithValue("@idProducto", IdProducto);

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
            }
        }
        public void InsertProductoVendido(int Stock, int IdProducto)
        {
            string query = "INSERT INTO ProductoVendido" +
                "(Stock, IdProducto, IdVenta)" +
                "VALUES (@stock, @idProducto, 1)";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@stock", Stock);
                sqlCommand.Parameters.AddWithValue("@idProducto", IdProducto);

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
        public List<ProductoVendido> GetProductoVendido()
        {
            Console.WriteLine("***** Showing ProductVendido Table from SQL DataBase ***** \r\n");
            Console.WriteLine($"Id|   Stock|    IdProducto|  IdVenta");
            List<ProductoVendido> listaproductovendido = new List<ProductoVendido>();
            string query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProductoVendido productovendido = new ProductoVendido();
                        productovendido.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        productovendido.Stock = Convert.ToInt32(sqlDataReader["Stock"]);
                        productovendido.IdProducto = Convert.ToInt32(sqlDataReader["IdProducto"]);
                        productovendido.IdVenta = Convert.ToInt32(sqlDataReader["IdVenta"]);

                       listaproductovendido.Add(ProductoVendido);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la definición de la consulta " + ex.Message);
                }
            }

            foreach (var item in ListaProductoVendidos)
            {
                Console.WriteLine($"{item.Id}|      {item.Stock}|           {item.IdProducto}|           {item.IdVenta}");
            }

            return listaproductovendido;
        }
        public List<ProductoVendido> GetProductoVendidoById(int id)
        {
            Console.WriteLine("***** Showing ProductVendido Table from SQL DataBase ***** \r\n");
            Console.WriteLine($"Id|   Stock|    IdProducto|  IdVenta");
            List<ProductoVendido> listaproductovendido = new List<ProductoVendido>();
            string query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido " +
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
                        ProductoVendido productovendido = new ProductoVendido();
                        productovendido.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        productovendido.Stock = Convert.ToInt32(sqlDataReader["Stock"]);
                        productovendido.IdProducto = Convert.ToInt32(sqlDataReader["IdProducto"]);
                        productovendido.IdVenta = Convert.ToInt32(sqlDataReader["IdVenta"]);

                        listaproductovendido.Add(productovendido);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la definición de la consulta! " + ex.Message);
                }
            }

            foreach (var item in listaproductovendido)
            {
                Console.WriteLine($"{item.Id}|      {item.Stock}|           {item.IdProducto}|           {item.IdVenta}");
            }

            return listaproductovendido;
        }
        public List<ProductoVendido> GetLastIdSoldProducts()
        {
            Console.WriteLine("***** Showing ProductVendido Table from SQL DataBase ***** \r\n");
            Console.WriteLine($"Id|   Stock|    IdProducto|  IdVenta");
            List<productoVendido> listaproductovendido = new List<ProductoVendido>();
            string query = "SELECT Top(1) Id, Stock, IdProducto, IdVenta FROM ProductoVendido ORDER BY Id DESC";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProductoVendido productovendido = new ProductoVendido();
                        productovendido.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        productovendido.Stock = Convert.ToInt32(sqlDataReader["Stock"]);
                        productovendido.IdProducto = Convert.ToInt32(sqlDataReader["IdProducto"]);
                        productovendido.IdVenta = Convert.ToInt32(sqlDataReader["IdVenta"]);

                        listaproductovendido.Add(productovendido);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
            }

            foreach (var item in listaproductovendido)
            {
                Console.WriteLine($"{item.Id}|      {item.Stock}|           {item.IdProducto}|           {item.IdVenta}");
            }

            return listaproductovendido;
        }

    }
}
}
        
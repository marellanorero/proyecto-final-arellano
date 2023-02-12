using proyecto_final_arellano.clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_arellano.handlers
{
    internal static class ProductoVendidoHandler
    {
        public static string cadenaConexion = "Data Source=Lauri;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<ProductoVendido> ObtenerProductosVendidos(long idUsuario)
        {
            List<ProductoVendido> productos = new List<ProductoVendido>();
            //Función que me permita obtener todos los productos de la base
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand($"  SELECT * FROM Venta INNER JOIN ProductoVendido  ON Venta.Id = ProductoVendido.IdVenta  WHERE IdUsuario = {idUsuario} ", conn);

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductoVendido producto = new ProductoVendido();
                        producto.Id = reader.GetInt64(0);
                        producto.Stock = reader.GetInt32(1);
                        producto.IdProducto = reader.GetInt64(2);
                        producto.IdVenta = reader.GetInt64(3);

                        productos.Add(producto);
                    }
                }
                return productos;
            }
        }
    }
}

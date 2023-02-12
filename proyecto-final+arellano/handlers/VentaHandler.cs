using proyecto_final_arellano.clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_arellano.handlers
{
    internal class VentaHandler
    {
        public static string cadenaConexion = "Data Source=Lauri;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Venta> ObtenerVentas(long idUsuario)
        {
            List<Venta> ventas = new List<Venta>();
            //Función que me permita obtener todos los productos de la base
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand($" SELECT * FROM ProductoVendido INNER JOIN Producto ON ProductoVendido.IdProducto = Producto.Id  WHERE IdUsuario = {idUsuario}", conn);

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta venta = new Venta();
                        venta.Id = reader.GetInt64();
                        venta.Comentarios = reader.GetString(1);
                        

                        ventas.Add(venta);
                    }
                }
                return ventas;
            }
        }
    }
}

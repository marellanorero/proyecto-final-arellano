using proyecto_final_arellano.clases;
using proyecto_final_arellano.handlers;

namespace Clase2_13_4095
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UsuarioHandler usuario = new UsuarioHandler();
            ProductoHandler producto = new ProductoHandler();
            ProductoVendidoHandler productoVendido = new ProductoVendidoHandler();
            VentaHandler venta = new VentaHandler();
            
            //Función que me permita obtener 1 usuario
            Usuario usuarioTipo = UsuarioHandler.ObtenerUsuario(1);

            Console.WriteLine(usuarioTipo);

            //Función que me permita obtener todos los productos dado el id de un usuario
            List<Producto> productos = ProductoHandler.ObtenerProductos(1);

            foreach (var item in productos)
            {
                Console.WriteLine(productos);
            }

            //Función que me permita obtener todos los productos vendidos dado el id de un usuario
            List<ProductoVendido> productosVendidos = ProductoVendidoHandler.ObtenerProductosVendidos(1);

            foreach (var item in productosVendidos)
            {
                Console.WriteLine(productosVendidos);
            }

            //Función que me permita obtener todos las ventas  dado el id de un usuario
            List<Venta> ventas = VentaHandler.ObtenerVentas(1);

            foreach (var item in ventas)
            {
                Console.WriteLine(ventas);
            }



        }
    }
}


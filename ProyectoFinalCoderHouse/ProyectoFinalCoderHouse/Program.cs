using System.Collections.Generic;
using ProyectoFinalCoderHouse;

class Program
{
    static void Main(string[] args)
    {
        Datos datos = new Datos();

        Usuario usuario = datos.TraerUsuario("Karen");
        Usuario usuarioLogin = datos.InicioDeSesion("Karen", "123");
        List<Producto> listaProductosUsuarios = datos.TraerProductosUsuario(2);
        List<ProductoVenta> listaProductosVenta = datos.TraerProductosVendidosUsuario(2);
    }
}

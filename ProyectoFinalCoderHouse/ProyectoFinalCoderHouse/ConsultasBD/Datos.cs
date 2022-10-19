using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalCoderHouse
{
    public class Datos
    {
        public SqlConnectionStringBuilder ObtenerConfiguracionBase()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "LAPTOP-PS2SCEJT";
            connectionStringBuilder.InitialCatalog = "ProyectoFinalCoderHouse";
            connectionStringBuilder.IntegratedSecurity = true;
            return connectionStringBuilder;
        }

        public Usuario TraerUsuario(string nombreBuscado)
        {
            Usuario usuarioRetorno = null;
            SqlConnectionStringBuilder connectionStringBuilder = ObtenerConfiguracionBase();
            var cs = connectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT id, nombre, apellido, edad, genero, mail, pass, dni FROM usuario
                where nombre like '" + nombreBuscado + "'";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuarioTabla = new Usuario();
                    usuarioTabla.Id = Convert.ToInt32(reader.GetValue(0));
                    usuarioTabla.Nombre = reader.GetValue(1).ToString();
                    usuarioTabla.Apellido = reader.GetValue(2).ToString();
                    usuarioTabla.Edad = Convert.ToInt32(reader.GetValue(3));
                    usuarioTabla.Genero = reader.GetValue(4).ToString();
                    usuarioTabla.Mail = reader.GetValue(5).ToString();
                    usuarioTabla.Pass = reader.GetValue(6).ToString();
                    usuarioTabla.DNI = reader.GetValue(7).ToString();

                    usuarioRetorno = usuarioTabla;
                }

                connection.Close();
            }
            return usuarioRetorno;
        }
        public Usuario TraerUsuarioPorId(int Id)
        {
            Usuario usuarioRetorno = null;
            SqlConnectionStringBuilder connectionStringBuilder = ObtenerConfiguracionBase();
            var cs = connectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT id, nombre, apellido, edad, genero, mail, pass, dni FROM usuario
                where id = " + Id;

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuarioTabla = new Usuario();
                    usuarioTabla.Id = Convert.ToInt32(reader.GetValue(0));
                    usuarioTabla.Nombre = reader.GetValue(1).ToString();
                    usuarioTabla.Apellido = reader.GetValue(2).ToString();
                    usuarioTabla.Edad = Convert.ToInt32(reader.GetValue(3));
                    usuarioTabla.Genero = reader.GetValue(4).ToString();
                    usuarioTabla.Mail = reader.GetValue(5).ToString();
                    usuarioTabla.Pass = reader.GetValue(6).ToString();
                    usuarioTabla.DNI = reader.GetValue(7).ToString();

                    usuarioRetorno = usuarioTabla;
                }

                connection.Close();
            }
            return usuarioRetorno;
        }

        public List<Producto> TraerProductosUsuario(int idBuscado)
        {
            List<Producto> ProductosARetornar = new List<Producto>();
            SqlConnectionStringBuilder connectionStringBuilder = ObtenerConfiguracionBase();
            var cs = connectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM producto WHERE idUsuario = " + idBuscado;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto productoTabla = new Producto();
                    productoTabla.Id = Convert.ToInt32(reader.GetValue(0));
                    productoTabla.Descripcion = reader.GetValue(1).ToString();
                    productoTabla.ValorCosto = Convert.ToInt32(reader.GetValue(2));
                    productoTabla.ValorVenta = Convert.ToInt32(reader.GetValue(3));
                    productoTabla.IdUsuario = Convert.ToInt32(reader.GetValue(4));
                    productoTabla.Stock = Convert.ToInt32(reader.GetValue(5));

                    ProductosARetornar.Add(productoTabla);
                }

                connection.Close();
            }

            return ProductosARetornar;
        }

        public List<ProductoVenta> TraerProductoVendidoPorIdProducto(int IdProducto)
        {
            List<ProductoVenta> PruductosVendidos = new List<ProductoVenta>();
            SqlConnectionStringBuilder connectionStringBuilder = ObtenerConfiguracionBase();
            var cs = connectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM ProductoVenta WHERE idProducto = " + IdProducto;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductoVenta productoTabla = new ProductoVenta();
                    productoTabla.Id = Convert.ToInt32(reader.GetValue(0));
                    productoTabla.IdProducto = Convert.ToInt32(reader.GetValue(1));
                    productoTabla.IdVenta = Convert.ToInt32(reader.GetValue(2));
                    productoTabla.IdUsuario = Convert.ToInt32(reader.GetValue(3));
                    productoTabla.StockVendido = Convert.ToInt32(reader.GetValue(4));

                    PruductosVendidos.Add(productoTabla);
                }

                connection.Close();
            }

            return PruductosVendidos;
        }
    
        public List<ProductoVenta> TraerProductosVendidosUsuario(int idUsuario)
        {
            List<Producto> ProductosUsuario = TraerProductosUsuario(idUsuario);
            List<ProductoVenta> ProductosVendidosTotal = new List<ProductoVenta>();

            if (ProductosUsuario.Count > 0)
            {
                for (int i = 0; i < ProductosUsuario.Count; i++)
                {
                    List<ProductoVenta> ProductosVendidos = TraerProductoVendidoPorIdProducto(ProductosUsuario[i].Id);

                    foreach (ProductoVenta productoVenta in ProductosVendidos)
                    {
                        ProductosVendidosTotal.Add(productoVenta);
                    }
                }

            }
            return ProductosVendidosTotal;
        }

        public List<Venta> TraerVentasUsuario(int idBuscado)
        {
            List<Venta> VentasARetornar = new List<Venta>();
            SqlConnectionStringBuilder connectionStringBuilder = ObtenerConfiguracionBase();
            var cs = connectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"select PV.idVenta, V.descripcion from ProductoVenta as PV
                    inner join Venta as V
                    on V.Id = PV.idVenta
                    where PV.idUsuario = " + idBuscado;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta ventaTabla = new Venta();
                    ventaTabla.Id = Convert.ToInt32(reader.GetValue(0));
                    ventaTabla.Descripcion = reader.GetValue(1).ToString();                   

                    VentasARetornar.Add(ventaTabla);
                }

                connection.Close();
            }

            return VentasARetornar;
        }

        public Usuario InicioDeSesion(string nombreUsuario, string passUsuario)
        {
            Usuario usuarioRetorno = new Usuario();
            SqlConnectionStringBuilder connectionStringBuilder = ObtenerConfiguracionBase();
            var cs = connectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = String.Format(@"select * from usuario
                                    where nombre ='{0}' and pass = '{1}'", nombreUsuario, passUsuario);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuarioTabla = new Usuario();
                    usuarioTabla.Id = Convert.ToInt32(reader.GetValue(0));
                    usuarioTabla.Nombre = reader.GetValue(1).ToString();
                    usuarioTabla.Apellido = reader.GetValue(2).ToString();
                    usuarioTabla.Edad = Convert.ToInt32(reader.GetValue(3));
                    usuarioTabla.Genero = reader.GetValue(4).ToString();
                    usuarioTabla.Mail = reader.GetValue(5).ToString();
                    usuarioTabla.Pass = reader.GetValue(6).ToString();
                    usuarioTabla.DNI = reader.GetValue(7).ToString();

                    usuarioRetorno = usuarioTabla;
                }

                connection.Close();
            }
            return usuarioRetorno;
        }
    
    }
}

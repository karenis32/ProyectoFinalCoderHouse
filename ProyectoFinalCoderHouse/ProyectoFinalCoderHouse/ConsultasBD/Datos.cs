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
        List<Usuario> ListaUsuarios;
        List<Producto> ListaProductos;
        List<ProductoVenta> ListaVentas;

        public Datos()
        {
            ListaUsuarios = new List<Usuario>();
            ListaProductos = new List<Producto>();
            ListaVentas = new List<ProductoVenta>();
        }

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
                cmd.CommandText = @"SELECT id, nombre, apellido, edad, genero, mail, pass, dni FROM persona
                where nombre like '" + nombreBuscado + "'";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuarioTabla = new Usuario();
                    usuarioTabla.Id = Convert.ToInt32(reader.GetValue(0));
                    usuarioTabla.Nombre = reader.GetValue(1).ToString();
                    usuarioTabla.Apellido = reader.GetValue(2).ToString();
                    usuarioTabla.Edad = Convert.ToInt32(reader.GetValue(3));
                    usuarioTabla.Genero = reader.GetValue(5).ToString();
                    usuarioTabla.Mail = reader.GetValue(6).ToString();
                    usuarioTabla.Pass = reader.GetValue(7).ToString();
                    usuarioTabla.DNI = reader.GetValue(8).ToString();

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
                cmd.CommandText = @"SELECT id, nombre, apellido, edad, genero, mail, pass, dni FROM persona
                where id = " + Id;

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuarioTabla = new Usuario();
                    usuarioTabla.Id = Convert.ToInt32(reader.GetValue(0));
                    usuarioTabla.Nombre = reader.GetValue(1).ToString();
                    usuarioTabla.Apellido = reader.GetValue(2).ToString();
                    usuarioTabla.Edad = Convert.ToInt32(reader.GetValue(3));
                    usuarioTabla.Genero = reader.GetValue(5).ToString();
                    usuarioTabla.Mail = reader.GetValue(6).ToString();
                    usuarioTabla.Pass = reader.GetValue(7).ToString();
                    usuarioTabla.DNI = reader.GetValue(8).ToString();

                    usuarioRetorno = usuarioTabla;
                }

                connection.Close();
            }
            return usuarioRetorno;
        }

        public List<Producto> TraerProducto(int idBuscado)
        {
            List <Producto> ProductosARetornar = new List<Producto> ();
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
    }
}

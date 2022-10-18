using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalCoderHouse
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public float ValorCosto { get; set; }
        public float ValorVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public Producto ()
        {
            Id = 0;
            Descripcion = string.Empty;
            ValorCosto = 0;
            ValorVenta = 0;
            Stock = 0;
            IdUsuario = 0;
            Usuario = new Usuario ();
        }
        
        public Producto (string Descripcion, float ValorCosto, float ValorVenta, int Stock, int IdUsuario, Usuario usuario)
        {
            this.Descripcion=Descripcion;
            this.ValorCosto=ValorCosto;
            this.ValorVenta=ValorVenta;
            this.Stock = Stock;
            this.IdUsuario =IdUsuario;
            this.Usuario = usuario;
        }
    }
}

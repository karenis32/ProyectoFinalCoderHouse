using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalCoderHouse
{
    public class ProductoVenta
    {
        public int Id { get; set; }
        public int StockVendido { get; set; }
        public Producto Producto { get; set; }
        public Usuario Usuario { get; set; }
        public Venta Venta { get; set; }
        public ProductoVenta()
        {
            Id = 0;
            StockVendido = 0;
            Producto = new Producto();
            Usuario = new Usuario();
            Venta = new Venta();
        }

        public ProductoVenta(int StockVendido, Producto producto, Usuario usuario, Venta venta)
        {
            this.StockVendido=StockVendido;
            this.Producto = producto;
            this.Usuario = usuario;
            this.Venta = venta;
        }
    }
}

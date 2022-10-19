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
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        public ProductoVenta()
        {
            Id = 0;
            StockVendido = 0;
            IdProducto = 0;
            IdVenta = 0;
            IdUsuario = 0;
        }

        public ProductoVenta(int StockVendido, int IdUsuario, int IdVenta, int IdProducto)
        {
            this.StockVendido=StockVendido;
            this.IdUsuario = IdUsuario;
            this.IdUsuario = IdUsuario;
            this.IdVenta = IdVenta;
        }
    }
}

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

        public Producto ()
        {
            Id = 0;
            Descripcion = string.Empty;
            ValorCosto = 0;
            ValorVenta = 0;
            Stock = 0;
        }
        
        public Producto (string Descripcion, float ValorCosto, float ValorVenta, int Stock)
        {
            this.Descripcion=Descripcion;
            this.ValorCosto=ValorCosto;
            this.ValorVenta=ValorVenta;
            this.Stock = Stock;
        }
    }
}

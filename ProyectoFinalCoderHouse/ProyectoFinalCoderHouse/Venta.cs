using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalCoderHouse
{
    public class Venta
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        
        public Venta ()
        {
            Id = 0;
        }

        public Venta (int Id, List <ProductoVenta> ProductosVendidos)
        {
            this.Id = Id;
        }
    }
}

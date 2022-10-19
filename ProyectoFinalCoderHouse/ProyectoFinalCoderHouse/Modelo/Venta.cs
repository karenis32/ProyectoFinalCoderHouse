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
            Descripcion = "";
        }

        public Venta (int Id, string Descripcion)
        {
            this.Id = Id;
            this.Descripcion = Descripcion; 
        }
    }
}

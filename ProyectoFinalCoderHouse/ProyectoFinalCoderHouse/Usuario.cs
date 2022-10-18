using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalCoderHouse
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string  Apellido { get; set; }
        public int Edad { get; set; }
        public string Pass { get; set; }
        public string Mail { get; set; }
        public string Genero { get; set; }
        public string DNI { get; set; }

        public Usuario ()
        {
            Id = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Edad = 0;
            Pass = string.Empty;
            Mail = string.Empty;
            Genero = string.Empty;
        }

        public Usuario (string Nombre, string Apellido, int Edad, string Pass, string Mail, string Genero)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Edad = Edad;
            this.Pass = Pass;
            this.Mail = Mail;
            this.Genero = Genero;
        }

    }
}

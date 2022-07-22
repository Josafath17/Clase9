using System;
using System.Collections.Generic;
using System.Text;

namespace CapaPresentacion
{
    class Libro
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public Persona autor { get; set; }
        public int añoPublicado { get; set; }
        public string resumen { get; set; }

        public Libro() { 
                
        }

        public Libro(int codigo, string nombre, Persona autor, int añoPublicado, string resumen)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.autor = autor;
            this.añoPublicado = añoPublicado;
            this.resumen = resumen;
        }


    }
}

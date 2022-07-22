using System;
using System.Collections.Generic;
using System.Text;

namespace CapaPresentacion
{
    class Persona
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string nacionalidad { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string sexo { get; set; }

        public Persona() {

        }

        public Persona(string id, string nombre, string nacionalidad, DateTime fechaNacimiento, string sexo)
        {
            this.id = id;
            this.nombre = nombre;
            this.nacionalidad = nacionalidad;
            this.fechaNacimiento = fechaNacimiento;
            this.sexo = sexo;
        }


    }
}

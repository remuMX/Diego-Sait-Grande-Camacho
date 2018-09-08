using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactosMAVI
{
    class Contacto
    {
        public int id_contacto { get; set; }

        public string nombre { get; set; }

        public char tipo_contacto { get; set; }

        public string telefono_fijo { get; set; }

        public string telefono_movil { get; set; }

        public DateTime fecha_nacimiento { get; set; }

        public char sexo { get; set; }

        public char estado_civil { get; set; }

        public Contacto(int id_contacto, string nombre, char tipo_contacto, string telefono_fijo, string telefono_movil, DateTime fecha_nacimiento, char sexo, char estado_civil)
        {
            this.id_contacto = id_contacto;
            this.nombre = nombre;
            this.tipo_contacto = tipo_contacto;
            this.telefono_fijo = telefono_fijo;
            this.telefono_movil = telefono_movil;
            this.fecha_nacimiento = fecha_nacimiento;
            this.sexo = sexo;
            this.estado_civil = estado_civil;
        }

        public Contacto()
        {
        }
    }
}

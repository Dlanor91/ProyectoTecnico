using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTecnico.Models
{
    public class Formacion
    {
        public int id { get; set; }
        protected static int ultimoId = 1;
        public string formacion { get; set; }

        public Formacion(string formacion)
        {
            this.id = ultimoId;
            ultimoId++;
            this.formacion=formacion;
        }

        public static Boolean validar(string formacion) {
            return formacion!="";
        }
    }
}

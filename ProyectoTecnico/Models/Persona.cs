using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTecnico.Models
{
    public abstract class Persona
    {
        public int id { get; set; }
        protected static int ultimoId = 1;
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }     
    }
}

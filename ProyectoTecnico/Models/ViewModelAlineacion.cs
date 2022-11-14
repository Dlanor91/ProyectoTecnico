using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTecnico.Models
{
    public class ViewModelAlineacion
    {
        public IEnumerable<Formacion> Formacion { get; set; }
        public IEnumerable<Jugador> Jugador { get; set; }
    }
}

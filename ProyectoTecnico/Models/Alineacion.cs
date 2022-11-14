using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTecnico.Models
{
    public class Alineacion
    {
        public Formacion Formacion { get; set; }
        public List<Jugador> Jugadores { get; set; }

        public Alineacion()
        {
        }
        public Alineacion(Formacion formacion, List<Jugador> jugadores)
        {
            Formacion=formacion;
            this.Jugadores=jugadores;
        }
    }
}

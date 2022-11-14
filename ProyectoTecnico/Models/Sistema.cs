using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProyectoTecnico.Models.Jugador;

namespace ProyectoTecnico.Models
{
    public class Sistema
    {
        public Sistema()
        {
            PrecargaDatos();
        }

        private static Sistema instancia = null;
        
        public static Sistema GetInstancia()
        {
            if (instancia == null) {
                instancia = new Sistema();
            }
            return instancia;
        }

        public int posicion { get; set; }
        private List<Jugador> jugadores = new List<Jugador>();                
        private List<Formacion> formaciones = new List<Formacion>();
        private List<Alineacion> alineaciones = new List<Alineacion>();

        public List<Jugador> getJugadores()
        {
            return jugadores;
        }
        public List<Formacion> getFormaciones()
        {
            return formaciones;
        }

        public List<Alineacion> getAlineaciones()
        {
            return alineaciones;
        }        

        #region jugadores
        public Boolean altaJugador(string nombre, string apellido,  string posCampo)
        {
            if (Jugador.validar(nombre, apellido))
            {
                jugadores.Add(new Jugador(nombre, apellido,posCampo));
                return true;
            }
            return false;
        }

        public Jugador buscarJugador(int id) {
            Jugador buscado = null;

            foreach (Jugador j in jugadores) {
                if (j.id.Equals(id))
                {
                    return buscado = j;
                }
            }

            return buscado;        

        }
        
        #endregion

        #region Alineacion
        public List<Alineacion> almacenarAlineacion(string[] seleccionados, int formacion)
        {            
            Alineacion unaAlineacion = new Alineacion();
            List<Jugador> jugadores = new List<Jugador>();
            
            foreach (string s in seleccionados)
            {
                int id = Int32.Parse(s);
                jugadores.Add(buscarJugador(id));                
            }

            unaAlineacion.Formacion = buscarFormacion(formacion);
            unaAlineacion.Jugadores = jugadores;
            alineaciones.Add(unaAlineacion);
            return alineaciones;

        }

        public Alineacion unaAlineacion(int posicion)
        {
            return alineaciones[posicion];
        }
        #endregion

        #region Formacion
        public Boolean altaFormacion(string formacion) {

            if (Formacion.validar(formacion))
            {
                formaciones.Add(new Formacion(formacion));
                return true;
            }
            return false;
        }

        public Formacion buscarFormacion(int id)
        {
            Formacion buscado = null;

            foreach (Formacion f in formaciones)
            {
                if (f.id.Equals(id))
                {
                    return buscado = f;
                }
            }

            return buscado;

        }
        #endregion

        #region InstanciasDatos
        public void PrecargaDatos() {

            altaJugador("Luis", "Aragonez","DT");
            altaJugador("Jose", "Perez", "AT");
            
            altaJugador("Anabel", "Rubio", "MD");
            altaJugador("Miguel", "Turi", "MD");

            altaJugador("Luis", "Bonilla", "POR");
            altaJugador("Armando", "Casilla", "POR");
            altaJugador("Tulio", "Rojo", "DEF");
            altaJugador("Jose", "Jota", "DEF");
            altaJugador("Leonel", "Rocha", "DEF");
            altaJugador("Javier", "Mendoza", "MED");
            altaJugador("Lucas", "Paredes", "MED");
            altaJugador("Agustin", "Feliciano", "MED");
            altaJugador("Diego", "Torres", "DEL");
            altaJugador("Frank", "Norlan", "DEL");
            altaJugador("Alex", "Morgan", "DEL");

            altaFormacion("3-4-3");
            altaFormacion("4-4-2");
            altaFormacion("4-3-3");
            altaFormacion("5-4-1");
        }
        #endregion

    }
}

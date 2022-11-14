using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTecnico.Models
{
    public class Jugador : Persona
    {
        public string posCampo { get; set; }        
        public string rolCuerpoTecnico { get; set; }             

        public Jugador(string nombre,string apellido , string posCampo)
        {
            this.id = ultimoId;
            ultimoId++;
            this.Nombre = nombre;
            this.Apellido = apellido;
            almacenar(posCampo);                        
        }

        private void almacenar(string posCampo)
        {
            if (posCampo == "DT" || posCampo == "AT" || posCampo == "MD") this.rolCuerpoTecnico = posCampo;
            if (posCampo == "POR" || posCampo == "DEF" || posCampo == "MED" || posCampo =="DEL") this.posCampo = posCampo;

        }

        public static Boolean validar(string nombre, string apellido) => nombre!="" && apellido !="";      
    }
}

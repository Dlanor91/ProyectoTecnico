using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoTecnico.Models;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTecnico.Controllers
{
    public class PersonaController : Controller
    {
        Sistema s = Sistema.GetInstancia();        
        // GET: PersonaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonaController/Details/5
        public ActionResult List()
        {            
            traerListas();
            return View();
        }

        [HttpPost]
        public ActionResult List(string[] seleccionados,string formacion)
        {
            int form = Int32.Parse(formacion);
            s.almacenarAlineacion(seleccionados, form);
            ViewBag.msg = "Alineación ingresada correctamente";
            traerListas();
            return View(); ;
        }

        // GET: PersonaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonaController/Create
        [HttpPost]
        public ActionResult Create(string nombre, string apellido, string jugadores, string cuerpoTecnico)
        {
            try
            {
                if (!Jugador.validar(nombre, apellido))
                {
                    throw new Exception("Complete los campos del formulario.");
                }
                else
                {
                    if (!String.IsNullOrEmpty(jugadores)) s.altaJugador(nombre, apellido, jugadores);
                    if (!String.IsNullOrEmpty(cuerpoTecnico)) s.altaJugador(nombre, apellido, cuerpoTecnico);

                    return RedirectToAction(nameof(List));
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult listarAlineaciones()
        {
            ViewBag.cant = s.getAlineaciones().Count;
            return View();
        }

        [HttpPost]
        public ActionResult listarAlineaciones(string pos)
        {
           
            ViewBag.cant = s.getAlineaciones().Count;
            if (!pos.Equals("0"))
            {
                int posBuscar = Int32.Parse(pos);
                s.posicion = posBuscar-1;
                Alineacion encontrada = s.unaAlineacion(s.posicion);
                ViewBag.formacion = encontrada.Formacion.formacion;
                return View(encontrada.Jugadores);
            }
            return View();
        }
        
        public ActionResult crearPDF()
        {
            Alineacion encontrada = s.unaAlineacion(s.posicion);
            ViewBag.form = encontrada.Formacion.formacion;
            return new ViewAsPdf("crearPDF", encontrada.Jugadores)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Legal,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                FileName = "Alineacion.pdf"
            };
        }

        private void traerListas()
        {
            ViewModelAlineacion VMAlineacion = new ViewModelAlineacion();
            VMAlineacion.Formacion = s.getFormaciones();
            ViewBag.Formacion =  VMAlineacion.Formacion;
            VMAlineacion.Jugador = s.getJugadores();
            ViewBag.Jugador = VMAlineacion.Jugador;
        }  

    }
}

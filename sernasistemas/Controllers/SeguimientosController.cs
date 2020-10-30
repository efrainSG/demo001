using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SernaSistemas.Controllers
{
    public class SeguimientosController : Controller
    {
        // GET: Seguimientos
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult opcionesMenu() {
            return Json("hola");
        }

        public JsonResult getProyectos() {
            return Json("Proyecto 1");
        }

        public JsonResult getProyecto(int idproyecto) {
            return Json("proyecto " + idproyecto.ToString());
        }

        public JsonResult getActividades(int idproyecto) {
            return Json("Actividades del proyecto id " + idproyecto.ToString());
        }

        public JsonResult getActividad(int idactividad) {
            return Json("Actividad " + idactividad.ToString());
        }
    }
}
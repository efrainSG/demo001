using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoTeDiv.Controllers {
    public class EstudianteController : Controller {
        // GET: Estudiante
        public ActionResult Index() {
            return View();
        }
        public ActionResult Inicio() {
            return View();
        }
        public ActionResult Nuevo() {
            return View("Registrar");
        }
        public ActionResult Perfil() {
            return View();
        }
        public ActionResult Conceptuar() {
            return View();
        }
        public ActionResult ListarConceptos() {
            return View();
        }
        [HttpPost, ActionName("Perfil")]
        public ActionResult GuardarPerfil() {
            return View();
        }
        [HttpPost, ActionName("Conceptuar")]
        public ActionResult GuardarConcepto() {
            return View();
        }

    }
}
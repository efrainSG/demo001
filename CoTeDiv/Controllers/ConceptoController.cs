using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoTeDiv.Controllers {
    public class ConceptoController : Controller {
        // GET: Concepto
        public ActionResult MostrarConcepto() {
            return View();
        }
        public ActionResult CrearConcepto() {
            return View();
        }
        public ActionResult EditarConcepto() {
            return View();
        }

        [HttpPost, ActionName("Valorar")]
        public ActionResult PuntuarConcepto() {
            return View();
        }
        [HttpPost, ActionName("Evaluar")]
        public ActionResult EvaluarConcepto() {
            return View();
        }
        [HttpPost, ActionName("Borrar")]
        public ActionResult BorrarConcepto() {
            return View();
        }
        [HttpPost, ActionName("Guardar")]
        public ActionResult GuardarConcepto() {
            return View();
        }

    }
}
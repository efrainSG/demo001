using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SernaSistemas.Controllers
{
    public class NegociosController : Controller
    {
        // GET: Negocios
        public ActionResult Index() {
            return View();
        }

        public JsonResult BuscarNegocio(string consulta) {
            return Json(new { consulta = consulta });
        }

        public ActionResult Login(/*string usuario, string password*/) {
            //if (usuario == "efrain")
            //    return View("adminNegocio");
            return View("adminNegocio");
        }

        public ActionResult verNegocio(/*int id*/) {
            return View("Negocio");
        }
    }
}
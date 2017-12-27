using SernaSistemas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFCotedivLib;

namespace CoTeDiv.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            CotedivServices cs = new CotedivServices();
            ViewData.Add("Posts", cs.getPosts(1));
            return View();
        }
        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Registrar() {
            return RedirectToAction("Nuevo", "Estudiante");
        }

        public ActionResult Login() {
            return View();
        }

        public ActionResult buscar() {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public ActionResult HazLogin(LoginModel model) {
            if (model.NombreUsuario == "yo")
                return RedirectToAction("Index", "Estudiante", model);
            return View();
        }
        [HttpPost, ActionName("buscar")]
        public ActionResult HazBusqueda(LoginModel model, string query) {
            return View(new {
                model, query
            });
        }
    }
}
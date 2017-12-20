using SernaSistemas.Core.Models;
using System;
using System.Web.Mvc;

namespace Tiendas.Controllers {
    public class HomeController : Controller {
        public ActionResult About() {
            ViewBag.Message = "Tu negocio en línea";
            return View();
        }
        public ActionResult Browse() {
            return PartialView();
        }
        public ActionResult Contact() {
            return PartialView();
        }
        public ActionResult Index() {
            return View();
        }
        public ActionResult loadMap() {
            return PartialView();
        }
        public ActionResult Login() {
            return PartialView();
        }
        public ActionResult verNegocio(int id) {
            return RedirectToAction("Index", "Tienda", new {
                id
            });
        }

        [HttpPost, ActionName("Browse")]
        public ActionResult DoBrowse() {
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost, ActionName("Contact")]
        public ActionResult DoContact(ContactoModel model) {
            model.Registrado = DateTime.Today;
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost, ActionName("loadMap")]
        public ActionResult DoMap() {
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult loadResults() {
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost, ActionName("Login")]
        public ActionResult DoLogin(LoginModel model) {
            model.UltimoLogin = DateTime.Now;
            if (!model.Nuevo) {
                string strAction = string.Empty;
                switch (model.NombreUsuario) {
                    case "admin":
                        return RedirectToAction("Index", "Admin", model);
                    case "yo":
                        return RedirectToAction("Index", "Propietario", model);
                    default:
                        break;
                }
                return View("Index");
            } else {
                return View("Registrar");
            }
        }
    }
}
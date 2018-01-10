using SernaSistemas.Core.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Tiendas.Controllers {
    public class HomeController : Controller {
        private void getEtiquetas() {
            Dictionary<string, string> Etiquetas = new Dictionary<string, string>();
            Etiquetas.Add("Etiqueta1", "Etiqueta #1");
            Etiquetas.Add("Etiqueta2", "Etiqueta #2");
            Etiquetas.Add("Etiqueta3", "Etiqueta #3");
            Etiquetas.Add("Etiqueta4", "Etiqueta #4");
            ViewData.Add("Etiquetas", Etiquetas);
        }
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
            getEtiquetas();
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

        //[HttpPost, ActionName("Browse")]
        //public ActionResult DoBrowse() {
        //    return Redirect(Request.UrlReferrer.ToString());
        //}
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
            getEtiquetas();
            Dictionary<int, Models.TiendaModel> Resultados = new Dictionary<int, Models.TiendaModel>();
            Resultados.Add(1, new Models.TiendaModel() { Nombre = "Gallito feliz", Telefono = "(222)123-4567", Direccion = "Calle 3 oriente 214" });
            Resultados.Add(2, new Models.TiendaModel() { Nombre = "La codorniz frita", Telefono = "(222)234-5678", Direccion = "Calle 4 norte 418" });
            Resultados.Add(3, new Models.TiendaModel() { Nombre = "El policcinella", Telefono = "(222)345-6789", Direccion = "Calle 7 poniente 307" });
            Resultados.Add(7, new Models.TiendaModel() { Nombre = "La fufurufa", Telefono = "(222)456-7890", Direccion = "Calle 2 sur 528" });
            Resultados.Add(9, new Models.TiendaModel() { Nombre = "Acrílicos acrilex", Telefono = "(222)567-8901", Direccion = "Calle 5 oriente 230" });
            Resultados.Add(14, new Models.TiendaModel() { Nombre = "Sambombazo", Telefono = "(222)678-9012", Direccion = "Calle 10 poniente 314" });
            ViewData.Add("Resultados", Resultados);
            return View("Index");
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
                        model.IdUsuario = DateTime.Today.DayOfYear;
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
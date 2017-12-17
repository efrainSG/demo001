using SernaSistemas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tiendas.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact() {
            return PartialView();
        }

        public ActionResult Browse() {
            return PartialView();
        }

        public ActionResult Login() {
            return PartialView();
        }

        public ActionResult loadMap() {
            return PartialView();
        }

        [HttpPost, ActionName("Contact")]
        public ActionResult DoContact(ContactoModel model) {
                model.Registrado = DateTime.Today;
                return Redirect(Request.UrlReferrer.ToString());
            }
        [HttpPost, ActionName("Browse")]
        public ActionResult DoBrowse() {
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost, ActionName("Login")]
        public ActionResult DoLogin(LoginModel model) {
            model.UltimoLogin = DateTime.Now;

            return View();
        }
        [HttpPost, ActionName("loadMap")]
        public ActionResult DoMap() {
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult loadResults() {
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
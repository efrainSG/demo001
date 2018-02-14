using CoTeDiv.Models;
using SernaSistemas.Core.Models;
using System.Web.Mvc;
using WCFCotedivLib;
using WCFCotedivLib.Contracts;

namespace CoTeDiv.Controllers {
    public class HomeController : Controller {
        CotedivServices cs = new CotedivServices();

        public ActionResult Index() {
            ViewData.Add("Posts", cs.ListarEntradas(10).Resultados);
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

        public ActionResult Buscar() {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public ActionResult HazLogin(LoginModel model) {
            var response = cs.Login(new LoginRequest() { UserId = model.NombreUsuario, Password = model.LoginPass });
            if (response.Success) {
                TempData.Clear();
                TempData.Add("login", new LoginModel() {
                    Hash = response.Modelo.Hash,
                    IdNivel = response.Modelo.IdNivel,
                    IdRol = response.Modelo.IdRol,
                    IdUsuario = response.Modelo.IdUsuario,
                    NombreUsuario = response.Modelo.NombreUsuario,
                    Permisos = response.Modelo.Permisos,
                    UltimoLogin = response.Modelo.UltimoLogin
                });
                string controlador = (response.Modelo.IdRol.Equals((int)Roles.Alumno)) ? "Estudiante" :
                    ((response.Modelo.IdRol.Equals((int)Roles.Experto)) ? "Experto" : "Administrador");
                return RedirectToAction("Index", controlador, response.Modelo.Hash);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("buscar")]
        public ActionResult HazBusqueda(string query) {
            return View(new {
                query
            });
        }
    }
}
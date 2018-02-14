using CoTeDiv.Models;
using SernaSistemas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFCotedivLib.Contracts;

namespace CoTeDiv.Controllers {
    public class AdministradorController : Controller {
        WCFCotedivLib.CotedivServices cs = new WCFCotedivLib.CotedivServices();
        private ResponseModel GetPerfil(int id) {
            PerfilResponse response = cs.VerPerfil(new PerfilRequest() { IdUsuario = id });
            ResponseModel model = new ResponseModel() {
                Perfil = new PerfilModel() {
                    Id = response.Id,
                    Nombres = response.Nombres,
                    Resumen = response.Resumen,
                    Correo = response.Correo,
                    Nacimiento = response.Nacimiento,
                    Telefono = response.Telefono,
                    IdStatus = response.IdStatus,
                    Usuario = response.Usuario,
                    Direccion = response.Direccion,
                    Instituciones = new List<Models.InstitucionModel>()
                }
            };
            return model;
        }

        public ActionResult Index(string hash) {
            Session.Add("Usuario", (TempData["login"] as LoginModel));
            return RedirectToAction("Inicio", hash);
        }

        public ActionResult Inicio(string hash) {
            ResponseModel model = new ResponseModel() {
                Posts = new Dictionary<int, Models.ConceptoModel>(),
                LoginData = new LoginModel() {
                    Hash = hash,
                    IdRol = (int)Roles.Administrador,
                    IdUsuario = (Session["Usuario"] as LoginModel).IdUsuario,
                    UltimoLogin = (Session["Usuario"] as LoginModel).UltimoLogin
                }
            };
            return View(model);
        }

        public ActionResult About(string hash, int id) {
            return View();
        }

        public ActionResult Perfil(string hash, int id) {
            var model = GetPerfil(id);
            model.LoginData = new LoginModel() {
                Hash = hash,
                IdUsuario = id
            };
            return View(model);
        }

        public ActionResult EditarPerfil(string hash, int id) {
            var model = GetPerfil(id);
            model.LoginData = new LoginModel() {
                Hash = hash,
                IdUsuario = id
            };
            var TipoElementoDireccion = (from ed in cs.getTipoElementoDireccion()
                                         select new {
                                             ed.Id, ed.Nombre
                                         }).ToDictionary(ed => ed.Id, ed => ed.Nombre);
            ViewData.Add("TipoElementoDireccion", TipoElementoDireccion);
            return View(model);
        }

        public ActionResult ListarExpertos(string hash, int id) {
            return View();
        }

        public ActionResult RegistrarExperto(string hash, int id) {
            return View();
        }

        public ActionResult ListarAlumnos(string hash, int id) {
            return View();
        }

        public ActionResult ListarInstituciones(string hash, int id) {
            return View();
        }

        [HttpPost, ActionName("Perfil")]
        public ActionResult GuardarPerfil(ResponseModel model) {
            var perfil = new PerfilRequest() {
                Id = model.Perfil.Id,
                IdStatus = model.Perfil.IdStatus,
                Correo = model.Perfil.Correo,
                Direccion = model.Perfil.Direccion,
                IdUsuario = (Session["Usuario"] as LoginModel).IdUsuario,
                Nacimiento = model.Perfil.Nacimiento,
                Nombres = model.Perfil.Nombres,
                Resumen = model.Perfil.Resumen,
                Telefono = model.Perfil.Telefono,
            };
            var respose = cs.GuardarPerfil(perfil);
            var model_1 = GetPerfil((Session["Usuario"] as LoginModel).IdUsuario);
            model_1.LoginData = new LoginModel() {
                Hash = (Session["Usuario"] as LoginModel).Hash,
                IdUsuario = (Session["Usuario"] as LoginModel).IdUsuario
            };
            return View(viewName: "Perfil", model: model_1);
        }
    }
}
using CoTeDiv.Models;
using SernaSistemas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFCotedivLib.Contracts;

namespace CoTeDiv.Controllers {
    public class ExpertoController : Controller {
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

            if (response.Instituciones != null) {
                foreach (var item in response.Instituciones) {
                    model.Perfil.Instituciones.Add(new Models.InstitucionModel() {
                        Id = item.Id,
                        IdLocacion = item.IdLocacion,
                        Lat = item.Lat,
                        Lon = item.Lon,
                        Nombre = item.Nombre
                    });
                }
            };

            return model;
        }
        // GET: Experto
        public ActionResult Index(string hash) {
            Session.Add("Usuario", (TempData["login"] as LoginModel));
            return RedirectToAction("Inicio", hash);
        }

        public ActionResult Inicio(string hash) {
            //var resultados = cs.ListarEntradas(10);

            ResponseModel model = new ResponseModel() {
                Posts = new Dictionary<int, Models.ConceptoModel>(),
                LoginData = new LoginModel() {
                    Hash = hash,
                    IdUsuario = (Session["Usuario"] as LoginModel).IdUsuario,
                    UltimoLogin = (Session["Usuario"] as LoginModel).UltimoLogin
                }
            };

            //foreach (var item in resultados.Resultados) {
            //    model.Posts.Add(item.Key, new Models.ConceptoModel() {
            //        Contenido = item.Value.Contenido,
            //        Id = item.Value.Id,
            //        Titulo = item.Value.Titulo
            //    });
            //}

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

            var instituciones = (from i in cs.getInstituciones()
                                 select new Models.InstitucionModel() {
                                     Id = i.Id,
                                     IdLocacion = i.IdLocacion,
                                     Lat = i.Lat,
                                     Lon = i.Lon,
                                     Nombre = i.Nombre
                                 }).ToList();
            ViewData.Add("Instituciones", instituciones);
            var TipoElementoDireccion = (from ed in cs.getTipoElementoDireccion()
                                         select new {
                                             ed.Id, ed.Nombre
                                         }).ToDictionary(ed => ed.Id, ed => ed.Nombre);
            ViewData.Add("TipoElementoDireccion", TipoElementoDireccion);
            return View(model);
        }

        [HttpPost,
            ActionName("Perfil")
            ]
        public ActionResult GuardarPerfil(ResponseModel model) {
            var perfil = new PerfilRequest() {
                Id = model.Perfil.Id,
                IdInstitucion = model.Perfil.IdInstitucion,
                IdStatus = model.Perfil.IdStatus,
                Correo = model.Perfil.Correo,
                Direccion = model.Perfil.Direccion,
                IdUsuario = (Session["Usuario"] as LoginModel).IdUsuario,
                Nacimiento = model.Perfil.Nacimiento,
                Nombres = model.Perfil.Nombres,
                Resumen = model.Perfil.Resumen,
                Telefono = model.Perfil.Telefono,
                //Institucion = new WCFCotedivLib.Contracts.InstitucionModel() {
                //    Id = model.Perfil.IdInstitucion,
                //    IdLocacion = 0,
                //    Lat = string.Empty,
                //    Lon = string.Empty,
                //    Nombre = string.Empty
                //}
            };
            var respose = cs.GuardarPerfil(perfil);
            var model_1 = GetPerfil((Session["Usuario"] as LoginModel).IdUsuario);
            model_1.LoginData = new LoginModel() {
                Hash = (Session["Usuario"] as LoginModel).Hash,
                IdUsuario = (Session["Usuario"] as LoginModel).IdUsuario
            };
            return View(viewName: "Perfil", model: model_1);
        }

        public ActionResult BuscarConceptos(string query) {
            ViewData.Add("Layout", "~/Views/Shared/Estudiante.cshtml");
            ResponseModel model = new ResponseModel() {
                Posts = new Dictionary<int, Models.ConceptoModel>()
            };
            var response = cs.ListarEntradas(query);
            foreach (var item in response.Resultados) {
                model.Posts.Add(item.Key, new Models.ConceptoModel() {
                    Id = item.Value.Id,
                    Contenido = item.Value.Contenido,
                    Titulo = item.Value.Titulo
                });
            }
            return View("HazBusqueda", model);
        }

        [HttpPost]
        public ActionResult EvaluarConcepto(int idConcepto, int evaluacion) {
            return View();
        }
    }
}
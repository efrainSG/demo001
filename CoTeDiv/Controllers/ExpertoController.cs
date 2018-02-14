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

        public ActionResult Index(string hash) {
            if (TempData.Keys.Contains("login")) {
                Session.Add("Usuario", (TempData["login"] as LoginModel));
                TempData.Clear();
                return RedirectToAction("Inicio", hash);
            } else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult Inicio(string hash) {
            if (Session.Count == 0) {
                return RedirectToAction("Index", "Home");
            }
            ResponseModel model = new ResponseModel() {
                Posts = new Dictionary<int, Models.ConceptoModel>(),
                LoginData = new LoginModel() {
                    Hash = hash,
                    IdUsuario = (Session["Usuario"] as LoginModel).IdUsuario,
                    UltimoLogin = (Session["Usuario"] as LoginModel).UltimoLogin
                }
            };
            return View(model);
        }

        public ActionResult About(string hash, int id) {
            if (Session.Count == 0) {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Perfil(string hash, int id) {
            if (Session.Count == 0) {
                return RedirectToAction("Index", "Home");
            }
            var model = GetPerfil(id);
            model.LoginData = new LoginModel() {
                Hash = hash,
                IdUsuario = id
            };
            return View(model);
        }

        public ActionResult EditarPerfil(string hash, int id) {
            if (Session.Count == 0) {
                return RedirectToAction("Index", "Home");
            }
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

        public ActionResult Buscar(string query) {
            if (Session.Count == 0) {
                return RedirectToAction("Index", "Home");
            }
            ViewData.Add("Layout", "~/Views/Shared/Experto.cshtml");
            ViewData.Add("Accion", "EvaluarConcepto");
            ResponseModel model = new ResponseModel() {
                Posts = new Dictionary<int, Models.ConceptoModel>()
            };
            var response = cs.ListarEntradas(query);
            foreach (var item in response.Resultados) {
                var concepto = new Models.ConceptoModel() {
                    Id = item.Value.Id,
                    Contenido = item.Value.Contenido,
                    Titulo = item.Value.Titulo
                };
                concepto.Evaluacion = (item.Value.Evaluacion.HasValue) ? item.Value.Evaluacion.Value : (int)Calificaciones.Nulo;
                concepto.Valor = (item.Value.Valoracion);
                concepto.EvalValorPor = (item.Value.Evaluacion.HasValue) ? item.Value.EvalValorPor.Value : (int)Calificaciones.Nulo;
                model.Posts.Add(item.Key, concepto);
            }
            return View("HazBusqueda", model);
        }

        public ActionResult ListarConceptos(string hash, int id) {
            if (Session.Count == 0) {
                return RedirectToAction("Index", "Home");
            }
            ResponseModel model = new ResponseModel() {
                Posts = new Dictionary<int, Models.ConceptoModel>()
            };
            var response = cs.ListarEntradas(new LoginModel() {
                IdUsuario = id,
                Hash = hash,
                IdRol = (int)Roles.Experto,
                NombreUsuario = (Session["Usuario"] as LoginModel).NombreUsuario,
                UltimoLogin = (Session["Usuario"] as LoginModel).UltimoLogin
            });
            foreach (var item in response.Resultados) {
                model.Posts.Add(item.Key, new Models.ConceptoModel() {
                    Id = item.Value.Id,
                    Contenido = item.Value.Contenido,
                    Titulo = item.Value.Titulo,
                    Evaluacion = item.Value.Evaluacion.Value
                });
            }
            return View(model);
        }

        public ActionResult Logout(string hash, int id) {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Perfil")]
        public ActionResult GuardarPerfil(ResponseModel model) {
            if (Session.Count == 0) {
                return RedirectToAction("Index", "Home");
            }
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
            };
            var respose = cs.GuardarPerfil(perfil);
            var model_1 = GetPerfil((Session["Usuario"] as LoginModel).IdUsuario);
            model_1.LoginData = new LoginModel() {
                Hash = (Session["Usuario"] as LoginModel).Hash,
                IdUsuario = (Session["Usuario"] as LoginModel).IdUsuario
            };
            return View(viewName: "Perfil", model: model_1);
        }

        public ActionResult EvaluarConcepto(int id, int valor) {
            if (Session.Count == 0) {
                return RedirectToAction("Index", "Home");
            }
            if ((Session["Usuario"] as LoginModel) != null) {
                if ((Session["Usuario"] as LoginModel).IdRol == (int)Roles.Experto) {
                    var response = cs.EvaluarEntrada(new EntradaRequest() {
                        Fecha = DateTime.Today,
                        Id = id,
                        IdAutor = (Session["Usuario"] as LoginModel).IdUsuario,
                        Valor = valor
                    });
                }
            }
            return RedirectToAction("Buscar", new {
                query = string.Empty
            });
        }
    }
}
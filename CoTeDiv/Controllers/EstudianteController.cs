using CoTeDiv.Models;
using SernaSistemas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WCFCotedivLib.Contracts;

namespace CoTeDiv.Controllers {
    public class EstudianteController : Controller {
        WCFCotedivLib.CotedivServices cs = new WCFCotedivLib.CotedivServices();
        private ResponseModel getPerfil(int id) {
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
                    Institucion = new Models.InstitucionModel(){ 
                        Id = response.Institucion.Id,
                        IdLocacion = response.Institucion.IdLocacion,
                        Lat = response.Institucion.Lat,
                        Lon = response.Institucion.Lon,
                        Nombre = response.Institucion.Nombre
                    }
                }
            };

            if (response.Institucion != null) {
                model.Perfil.Institucion.Id = response.Institucion.Id;
                model.Perfil.Institucion.IdLocacion = response.Institucion.IdLocacion;
                model.Perfil.Institucion.Lat = response.Institucion.Lat;
                model.Perfil.Institucion.Lon = response.Institucion.Lon;
                model.Perfil.Institucion.Nombre = response.Institucion.Nombre;
            };

            return model;
        }
        // GET: Estudiante

        public ActionResult Index(string hash) {
            Session.Add("Usuario", (TempData["login"] as LoginModel));
            return RedirectToAction("Inicio", hash);
        }

        public ActionResult Nuevo() {
            return View("Registrar");
        }

        public ActionResult Inicio(string hash) {
            var resultados = cs.ListarEntradas(10);

            ResponseModel model = new ResponseModel() {
                Posts = new Dictionary<int, Models.ConceptoModel>(),
                LoginData = new LoginModel() {
                    Hash = hash,
                    IdUsuario = (Session["Usuario"] as LoginModel).IdUsuario,
                    UltimoLogin = (Session["Usuario"] as LoginModel).UltimoLogin
                }
            };

            foreach (var item in resultados.Resultados) {
                model.Posts.Add(item.Key, new Models.ConceptoModel() {
                    Contenido = item.Value.Contenido,
                    Id = item.Value.Id,
                    Titulo = item.Value.Titulo
                });
            }

            return View(model);
        }

        public ActionResult About(string hash, int id) {
            return View();
        }

        public ActionResult Perfil(string hash, int id) {
            var model = getPerfil(id);
            model.LoginData = new LoginModel() {
                Hash = hash,
                IdUsuario = id
            };
            return View(model);
        }

        public ActionResult editarPerfil(string hash, int id) {
            var model = getPerfil(id);
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

        public ActionResult Conceptuar(string hash, int id) {
            ResponseModel model = new ResponseModel() {
                Concepto = new Models.ConceptoModel()
            };
            return View(model);
        }

        public ActionResult EditarPost(int id) {
            ResponseModel model = new ResponseModel();
            var response = cs.VerEntrada(new EntradaRequest() {
                Id = id
            });
            model.Concepto = new Models.ConceptoModel() {
                Contenido = response.Contenido,
                Id = id,
                Fecha = DateTime.Today,
                Titulo = response.Titulo
            };
            return View(viewName: "Conceptuar", model: model);
        }

        public ActionResult ListarConceptos(string hash, int id) {
            ResponseModel model = new ResponseModel() {
                Posts = new Dictionary<int, Models.ConceptoModel>()
            };
            var response = cs.ListarEntradas(new LoginModel() {
                IdUsuario = id,
                Hash = hash,
                NombreUsuario = (Session["Usuario"] as LoginModel).NombreUsuario,
                UltimoLogin = (Session["Usuario"] as LoginModel).UltimoLogin
            });
            foreach (var item in response.Resultados) {
                model.Posts.Add(item.Key, new Models.ConceptoModel() {
                    Id = item.Value.Id,
                    Contenido = item.Value.Contenido,
                    Titulo = item.Value.Titulo
                });
            }
            return View(model);
        }

        [HttpPost, ActionName("Registrar")]
        public ActionResult NuevaCuenta(ResponseModel model) {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Perfil")]
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
                Institucion = new WCFCotedivLib.Contracts.InstitucionModel() {
                    Id = model.Perfil.IdInstitucion,
                    IdLocacion = 0,
                    Lat = string.Empty,
                    Lon = string.Empty,
                    Nombre = string.Empty
                }
            };
            var respose = cs.GuardarPerfil(perfil);
            var model_1 = getPerfil((Session["Usuario"] as LoginModel).IdUsuario);
            model_1.LoginData = new LoginModel() {
                Hash = (Session["Usuario"] as LoginModel).Hash,
                IdUsuario = (Session["Usuario"] as LoginModel).IdUsuario
            };
            return View(viewName: "Perfil", model: model_1);
        }

        [HttpPost, ActionName("Conceptuar")]
        public ActionResult GuardarConcepto(ResponseModel model) {
            var response = cs.GuardarEntrada(new EntradaRequest() {
                Id = model.Concepto.Id,
                Contenido = model.Concepto.Contenido,
                Fecha = DateTime.Today,
                IdAutor = (Session["Usuario"] as LoginModel).IdUsuario,
                Titulo = model.Concepto.Titulo
            });
            if (response.Success)
                return View(viewName: "Inicio");
            else
                return View(model: model);
        }

        public ActionResult Buscar(string query) {
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
        public ActionResult Valorar(ResponseModel model) {
            var response = cs.ValorarEntrada(new EntradaRequest() {
                Contenido = model.Concepto.Contenido,
                Fecha = model.Concepto.Fecha,
                Id = model.Concepto.Id,
                IdAutor = model.LoginData.IdUsuario,
                Titulo = model.Concepto.Titulo,
                Valor = model.Concepto.Valor
            });
            return View(model);
        }
    }
}
using SernaSistemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFTiendasLib;
using WCFTiendasLib.Contracts;

namespace SernaSistemas.Controllers
{
    public class NegociosController : Controller
    {
        TiendasServices servicios = new TiendasServices();
        // GET: Negocios
        public ActionResult Index() {

            return View();
        }

        public JsonResult SendContacto(string nombre, string telefono, string correo, string comentario, int IdNegocio = 0) {
            WCFSernaSistemasLib.SernaSistemasServices servicio = new WCFSernaSistemasLib.SernaSistemasServices();
            var response = servicio.registrarContacto(new WCFSernaSistemasLib.ContactoRequest() {
                Nombre = nombre,
                Telefono = telefono,
                eMail = correo,
                Comentario = comentario,
                FechaContacto = DateTime.Today,
                Id = IdNegocio
            });
            if (response.tieneError)
                return Json(new { error = "SI", msg = response.Mensaje });
            return Json(new { error = "NO", msg = "Pronto me pondré en contacto contigo." });
        }

        public JsonResult BuscarNegocio(string consulta, string giro) {
            ListarTiendasRequest request = new ListarTiendasRequest() {
                Consulta = consulta,
                Giro = giro
            };
            ListarTiendasResponse response = servicios.ListarTiendas(request);
            return Json(new { resultados = response.Resultados });
        }

        public JsonResult listarGiros() {
            ListarGirosRequest request = new ListarGirosRequest();
            ListarGirosResponse response = servicios.ListarGiros(request);
            return Json(new { resultados = response.Giros.ToArray() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Login(string usuario, string password) {

            var response = servicios.Login(new LoginRequest() {
                loginModel = new Core.Models.LoginModel() {
                    NombreUsuario = usuario,
                    LoginPass = password
                }
            });
            if (response.Mensaje.StartsWith("Hecho") && !string.IsNullOrEmpty(response.loginModel.Hash)) {
                Session.Add("usuario", response.loginModel.NombreUsuario);
                Session.Add("IdUsuario", response.loginModel.IdUsuario);
                Session.Add("token", response.loginModel.Hash);
                Session.Add("login", response.loginModel.UltimoLogin);
                Session.Add("IdTienda", response.Mensaje.Substring(5)); 
            }
            return Json(new { response.Mensaje, response.tieneError, response.loginModel });
        }
        [HttpGet]
        public ActionResult LoginGet() {
            if (Session["usuario"] != null && Session["token"] != null) {
                 
                return View("adminNegocio", new sesionModel() {
                    IdUsuario = (int)Session["IdUsuario"],
                    Usuario = Session["usuario"].ToString(),
                    UltimoLogin = Session["login"].ToString(),
                    IdTienda = (int)Session["IdTienda"]
                });
            } else {
                Session.Clear();
                return View("Index");
            }
        }
        #region métodos de controlador que son utilizados desde JS para las secciones en el front de cliente
        public ActionResult verNegocio(int Id) {
            TiendaRequest request = new TiendaRequest() {
                Id = Id
            };
            TiendaResponse response = servicios.VerTienda(request);
            ViewData.Add("Id", Id);
            ViewData.Add("Nombre", response.Nombre);
            ViewData.Add("Direccion", response.Direccion);
            ViewData.Add("Telefono", response.Telefono);
            ViewData.Add("Correo", response.Correo);
            ViewData.Add("Horario", response.Horario);

            switch (response.IdGiro) {
                case 1:
                    ViewData.Add("css", "manualidades.css");
                    ViewData.Add("font", "Kalam");
                    break;
                case 2:
                    ViewData.Add("css", "mantenimiento.css");
                    ViewData.Add("font", "Playfair+Display");
                    break;
                case 3:
                    ViewData.Add("css", "arte.css");
                    ViewData.Add("font", "Playfair+Display");
                    break;
                case 4:
                    ViewData.Add("css", "nutricion.css");
                    ViewData.Add("font", "Open+Sans+Condensed:700");
                    break;
                case 5:
                    ViewData.Add("css", "mascotas.css");
                    ViewData.Add("font", "Overlock:900i");
                    break;
                case 6:
                    ViewData.Add("css", "impresion.css");
                    ViewData.Add("font", "Playfair+Display");
                    break;
                default:
                    ViewData.Add("css", "blue.css");
                    ViewData.Add("font", "Open+Sans+Condensed:700");
                    break;
            }

            return View("Negocio");
        }

        public ActionResult obtenerProductos(int Id) {
            ListarOfertasRequest request = new ListarOfertasRequest() {
                IdNegocio = Id,
                TipoOferta = "PRODUCTO"
            };
            ListarOfertasResponse response = servicios.ListarOfertas(request);
            var seccionresponse = servicios.VerSeccion(new TiendaRequest() {
                Id = Id,
                IdSeccion = 2
            });
            return Json(new {
                seccionTitulo = seccionresponse.Titulo,
                seccionContenido = seccionresponse.Seccion,
                productos = response.Productos
            });
        }

        public ActionResult verProducto(int Id) {
            OfertaRequest request = new OfertaRequest() {
                Id = Id
            };
            OfertaResponse response = servicios.VerOferta(request);
            return Json(new { producto = response.Producto });
        }

        public ActionResult obtenerServicios(int Id) {
            ListarOfertasRequest request = new ListarOfertasRequest() {
                IdNegocio = Id,
                TipoOferta = "SERVICIO"
            };
            ListarOfertasResponse response = servicios.ListarOfertas(request);
            var seccionresponse = servicios.VerSeccion(new TiendaRequest() {
                Id = Id,
                IdSeccion = 3
            });
            return Json(new {
                seccionTitulo = seccionresponse.Titulo,
                seccionContenido = seccionresponse.Seccion,
                servicios = response.Servicios
            });
        }

        public ActionResult AcercaDe(int Id) {

            List<TiendaResponse> seccionresponse = new List<TiendaResponse>();
            seccionresponse.Add(servicios.VerSeccion(new TiendaRequest() {
                Id = Id,
                IdSeccion = 7
            }));
            seccionresponse.Add(servicios.VerSeccion(new TiendaRequest() {
                Id = Id,
                IdSeccion = 8
            }));
            seccionresponse.Add(servicios.VerSeccion(new TiendaRequest() {
                Id = Id,
                IdSeccion = 9
            }));
            seccionresponse.Add(servicios.VerSeccion(new TiendaRequest() {
                Id = Id,
                IdSeccion = 10
            }));
            return Json(seccionresponse);
        }

        public ActionResult verServcio(int Id) {
            OfertaRequest request = new OfertaRequest() {
                Id = Id
            };
            OfertaResponse response = servicios.VerOferta(request);
            return Json(new { servicio = response.Servicio });
        }

        public ActionResult obtenerNovedades(int Id) {
            ListarNovedadesRequest request = new ListarNovedadesRequest() {
                IdNegocio = Id
            };
            ListarNovedadesResponse response = servicios.ListarNovedades(request);
            var seccionresponse = servicios.VerSeccion(new TiendaRequest() {
                Id = Id,
                IdSeccion = 1
            });
            return Json(new {
                seccionTitulo = seccionresponse.Titulo,
                seccionContenido = seccionresponse.Seccion,
                novedades = response.Novedades
            });

        }

        public ActionResult obtenerFotos(int Id) {
            ListarFotoRequest request = new ListarFotoRequest() {
                IdNegocio = Id
            };
            ListarFotoResponse response = servicios.ListarFotos(request);
            var seccionresponse = servicios.VerSeccion(new TiendaRequest() {
                Id = Id,
                IdSeccion = 4
            });
            return Json(new {
                seccionTitulo = seccionresponse.Titulo,
                seccionContenido = seccionresponse.Seccion,
                Fotos = response.Fotos.ToArray()
            });
        }

        public ActionResult verFoto(int Id) {
            FotoRequest request = new FotoRequest() {
                IdFoto = Id
            };
            FotoResponse response = servicios.VerFoto(request);
            return Json(new { response.Foto });
        }

        public ActionResult obtenerComentarios(int Id) {
            return Json(new { Comentarios = Id });
        }
        #endregion

        #region métodos relacionados con vistas para el front de usuario

        public ActionResult obtenerInfoNegocio(int Id) {
            InfoTiendaRequest request = new InfoTiendaRequest(Session["usuario"].ToString(), Session["token"].ToString(), Id);
            InfoTiendaResponse response = servicios.obtenerInfoNegocio(request);
            if (!response.tieneError)
                return Json(new { InfoTienda = response.Resultado });
            else
                return null;
        }

        public ActionResult guardarInfoNegocio() {
            return null;
        }

        public ActionResult obtenerInfoPerfil(int Id) {
            var response = servicios.VerPropietario(new VerPropietarioRequest() {
                Id = Id
            });
            if (!response.tieneError) {
                return Json(new {
                    response.Propietario
                });
            } else {
                return null;
            }
        }

        public ActionResult guardarInfoPerfil() {
            return null;
        }

        public ActionResult obtenerOfertas(int Id, int Tipo) {
            var response = servicios.ListarOfertas(new ListarOfertasRequest() {
                IdNegocio = Id,
                TipoOferta = Tipo == 1 ? "PRODUCTO" : "SERVICIO"
            });
            if (!response.tieneError)
                return Json(new { response.Productos, response.Servicios });
            else
                return null;
        }

        public ActionResult obtenerOferta(int IdOferta) {
            var response = servicios.VerOferta(new OfertaRequest() {
                Id = IdOferta
            });
            if (!response.tieneError)
                return Json(new { response.Producto, response.Servicio });
            else
                return null;
        }

        public ActionResult guardarOferta() {
            return null;
        }

        public ActionResult borrarOferta() {
            return null;
        }

        public ActionResult obtenerFotosAdmin(int Id) {
            var response = servicios.ListarFotos(new ListarFotoRequest() {
                IdNegocio = Id
            });
            if (!response.tieneError)
                return Json(new { response.Fotos });
            else
                return null;
        }

        public ActionResult obtenerFotoAdmin(int Id) {
            var response = servicios.VerFoto(new FotoRequest() {
                IdFoto = Id
            });
            if (!response.tieneError)
                return Json(new { response.Foto });
            else
                return null;
        }

        public ActionResult guardarFotoAdmin() {
            return null;
        }

        public ActionResult borrarFotoAdmin(int Id) {
            return null;
        }

        #endregion
    }
}
using SernaSistemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFTiendasLib;
using WCFTiendasLib.Contracts;

namespace SernaSistemas.Controllers {
    public class NegociosController : Controller {
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

        public JsonResult listarSecciones(int? idTienda) {
            ListarSeccionesRequest request = new ListarSeccionesRequest() {
                Id = idTienda.HasValue ? idTienda.Value : 0
            };
            ListarSeccionesResponse response = servicios.ListarSecciones(request);
            return Json(new { resultados = response.Secciones.ToArray() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarTiposSucursales() {
            var request = new ListarGirosRequest();
            ListarTiposSucursalesResponse response = servicios.ListarTiposSucursales(request);
            return Json(new { resultados = response.TiposSucursales.ToArray() }, JsonRequestBehavior.AllowGet);
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
                var model = new sesionModel() {
                    IdUsuario = (int)Session["IdUsuario"],
                    Usuario = Session["usuario"].ToString(),
                    UltimoLogin = Session["login"].ToString(),
                    IdTienda = int.Parse(Session["IdTienda"].ToString())
                };
                return View("adminNegocio", model);
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

        public ActionResult obtenerProductos(int Id, bool? visible) {
            ListarOfertasRequest request = new ListarOfertasRequest() {
                IdNegocio = Id,
                TipoOferta = "PRODUCTO",
                Visible = visible
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

        public ActionResult obtenerServicios(int Id, bool? visible) {
            ListarOfertasRequest request = new ListarOfertasRequest() {
                IdNegocio = Id,
                TipoOferta = "SERVICIO",
                Visible = visible
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

        public ActionResult listarSucursales(int IdTienda) {
            var response = servicios.ListarLocales(new ListarLocalesRequest() {
                IdTienda = IdTienda
            });
            return Json(response);
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

        public ActionResult guardarInfoNegocio(int id, string nombre, string direccion, string telefono, string razonsocial, string latitud, string longitud, string correo, int giro) {
            RegistroTiendaRequest request = new RegistroTiendaRequest() {
                Usuario = Session["usuario"].ToString(),
                Token = Session["token"].ToString(),
                Datos = new InfoTienda() {
                    Id = id,
                    Nombre = nombre,
                    Direccion = direccion,
                    Telefono = telefono,
                    RazonSocial = razonsocial,
                    Latitud = latitud,
                    Longitud = longitud,
                    CorreoElectronico = correo,
                    Giro = giro
                }
            };
            var response = servicios.guardarDatosTienda(request);
            return Json(new { respuesta = response });
        }

        public ActionResult obtenerInfoPerfil(int Id) {
            var response = servicios.VerPropietario(new VerPropietarioRequest() {
                Id = Id
            });
            if (!response.tieneError) {
                return Json(new {
                    Propietario = new {
                        response.Propietario.Id,
                        response.Propietario.Nombre,
                        response.Propietario.Telefono,
                        response.Propietario.Correo,
                        response.Propietario.Usuario
                    },
                    tieneError = !response.tieneError
                });
            } else {
                return Json(new {
                    Propietario = new {
                        Nombre = "",
                        Telefono = "",
                        Correo = "",
                        Usuario = "",
                        Id = 0
                    },
                    tieneError = true
                });
            }
        }

        public ActionResult guardarInfoPerfil(int Id, string nombre, string correo, string telefono, string password = "") {
            var request = new RegistrarPropietarioRequest() {
                Id = Id,
                Usuario = Session["usuario"].ToString(),
                Token = Session["token"].ToString(),
                Nombre = nombre,
                Correo = correo,
                Telefono = telefono,
                Password = password
            };
            var response = servicios.GuardarDatos(request);
            return Json(new { response });
        }

        public ActionResult guardarSeccion(int IdSeccion, int IdTienda, string Descripcion, string Titulo) {
            SeccionRequest request = new SeccionRequest() {
                idSeccion = IdSeccion,
                idTienda = IdTienda,
                descripcion = Descripcion,
                titulo = Titulo
            };
            SeccionResponse response = servicios.guardarSeccion(request);
            return Json(new { IdSeccion, IdTienda, Descripcion });
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

        public ActionResult obtenerSucursal(int idSucursal) {
            var response = servicios.verSucursal(new SucursalRequest() {
                Id = idSucursal
            });
            if (!response.tieneError) {
                return Json(new { response.Sucursal });
            } else
                return null;
        }
        public ActionResult guardarOferta(int idTienda, int id, string nombre, string DescripcionBreve,
            string Descripcion, float Precio, string Unidad, int Tipo, int IdSucursal, int IdOS) {
            var response = servicios.RegistrarOferta(new OfertaRequest() {
                Oferta = new Oferta() {
                    Id = id,
                    Descripcion = Descripcion,
                    DescripcionBreve = DescripcionBreve,
                    IdTienda = idTienda,
                    IdTipo = Tipo,
                    Nombre = nombre,
                    Precio = Precio,
                    Unidad = Unidad,
                    IdSucursal = IdSucursal,
                    IdOS = IdOS
                }
            });
            return Json(new { response.Producto, response.Servicio });
        }

        public ActionResult invertirOferta(int id, int idTipo) {
            var response = servicios.cambiarVisibilidadOferta(new OfertaRequest() {
                Id = id,
                Oferta = new Oferta() {
                    Id = id,
                    IdTipo = idTipo
                }
            });
            return Json(new { response });
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

        public ActionResult guardarSucursal(int Id, int IdTienda, int Status, int IdTipo, string Direccion, string Telefono, string Correo) {
            SucursalResponse response = servicios.guardarSucursal(new SucursalRequest() {
                Id = Id,
                IdTienda = IdTienda,
                Status = Status,
                IdTipo = IdTipo,
                Direccion = Direccion,
                Telefono = Telefono,
                Correo = Correo
            });
            return Json(new { response.Sucursal });
        }

        public ActionResult invertirSucursal(int id) {
            var response = servicios.cambiarVisibilidadSucursal(new SucursalRequest() {
                Id = id
            });
            return Json(new { response });
        }
        #endregion
    }
}
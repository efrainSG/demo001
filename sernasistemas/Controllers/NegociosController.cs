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
            return Json(new { resultados = response.Giros.ToArray() },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login(/*string usuario, string password*/) {
            //if (usuario == "efrain")
            //    return View("adminNegocio");
            return View("adminNegocio");
        }

        public ActionResult verNegocio(int Id) {
            TiendaRequest request = new TiendaRequest() {
                IdNegocio = Id
            };
            TiendaResponse response = servicios.VerTienda(request);
            ViewData.Add("Id", Id);
            ViewData.Add("Nombre", response.Nombre);
            ViewData.Add("Direccion", response.Direccion);
            ViewData.Add("Telefono", response.Telefono);
            ViewData.Add("Correo", response.Correo);
            ViewData.Add("Horario", response.Horario);
            return View("Negocio");
        }

        public ActionResult obtenerProductos(int Id) {
            ListarOfertasRequest request = new ListarOfertasRequest() {
                IdNegocio = Id,
                TipoOferta = "PRODUCTO"
            };
            ListarOfertasResponse response = servicios.ListarOfertas(request);
            return Json(new { productos = response.Productos });
        }

        public ActionResult verProducto(int Id) {
            OfertaRequest request = new OfertaRequest() {
                IdProducto = Id
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
            return Json(new { servicios = response.Servicios });
        }

        public ActionResult verServcio(int Id) {
            OfertaRequest request = new OfertaRequest() {
                IdServicio = Id
            };
            OfertaResponse response = servicios.VerOferta(request);
            return Json(new { servicio = response.Servicio });
        }

        public ActionResult obtenerFotos(int Id) {
            ListarFotoRequest request = new ListarFotoRequest() {
                IdNegocio = Id
            };
            ListarFotoResponse response = servicios.ListarFotos(request);
            return Json(new { Fotos = response.Fotos });
        }

        public ActionResult verFoto(int Id) {
            FotoRequest request = new FotoRequest() {
                IdFoto = Id
            };
            FotoResponse response = servicios.VerFoto(request);
            return Json(new { Foto = response.Foto });
        }

        public ActionResult obtenerComentarios(int Id) {
            return Json(new { Comentarios = Id });
        }
    }
}
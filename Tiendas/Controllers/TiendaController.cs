using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tiendas.Controllers {
    public class TiendaController : Controller {

        private Models.TiendaModel getTienda(int id) {
            ViewData.Add("Id", id);
            return new Models.TiendaModel() {
                Id = id,
                Direccion = "abc def ghi jkl mno pqrs"
            };
        }
        private SernaSistemas.Core.Models.ContactoModel GetContacto(int idTienda) {
            ViewData.Add("Id", idTienda);
            return new SernaSistemas.Core.Models.ContactoModel();
        }
        private Models.OfertaModel getOferta(int idOferta, int idTipo, int idTienda) {
            ViewData.Add("Id", idTienda);
            return new Models.OfertaModel() {
                Id = idOferta,
                IdTienda = idTienda,
                IdTipoOferta = (Models.tipoOferta)idTipo,
                Breve = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. ",
                Descripcion = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus",
                Nombre = "Lorem ipsum ",
                Precio = 10M
            };
        }
        
        #region GET: Tienda
        public ActionResult AcercaDe(int id) {
            return View(getTienda(id));
        }
        public ActionResult Contacto(int id) {
            return PartialView(GetContacto(id));
        }
        public ActionResult Galeria(int id) {
            return View(getTienda(id));
        }
        public ActionResult Index(int id) {
            return View(getTienda(id));
        }
        public ActionResult loadMap(int id) {
            return PartialView(getTienda(id));
        }
        public ActionResult Productos(int id) {
            return View(getTienda(id));
        }
        public ActionResult Servicios(int id) {
            return View(getTienda(id));
        }
        public ActionResult verOferta(int idOferta, int tipo, int tienda) {
            return View(getOferta(idOferta, tipo, tienda));
        }
        #endregion
        #region POST: Tienda
        [HttpPost]
        public ActionResult doContacto(SernaSistemas.Core.Models.ContactoModel model) {
            return Redirect(Request.UrlReferrer.ToString());
        }
        #endregion
    }
}
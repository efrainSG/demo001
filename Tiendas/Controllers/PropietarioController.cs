using SernaSistemas.Core.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Tiendas.Controllers {
    public class PropietarioController : Controller {
        // GET: Propietario
        private LoginModel setData(int id, DateTime date) {
            ViewData.Add("Id", id);
            ViewData.Add("UltimoLogin", date.ToShortDateString());
            return new LoginModel("YO", "***", string.Empty) { IdUsuario = id, UltimoLogin = date };
        }

        public ActionResult Index(LoginModel model) {
            var data = setData(model.IdUsuario, model.UltimoLogin);
            return RedirectToAction("Inicio", new {
                id = model.IdUsuario, fecha = model.UltimoLogin.ToShortDateString()
            });
        }
        public ActionResult Inicio(int id, string fecha) {
            var data = setData(id, DateTime.Parse(fecha));
            return View();
        }
        public ActionResult Perfil(int id, string fecha) {
            var data = setData(id, DateTime.Parse(fecha));
            return View();
        }

        public ActionResult ListarTiendas(int id, string fecha) {
            return View();
        }
        public ActionResult ListarLocales(int id, string fecha) {
            return View();
        }
        public ActionResult ListarOfertas(int id, string fecha) {
            return View();
        }
        public ActionResult ListarContactos(int id, string fecha) {
            var data = setData(id, DateTime.Parse(fecha));
            List<SernaSistemas.Core.Models.ContactoModel> contactos = new List<ContactoModel>();
            contactos.Add(new ContactoModel() {
                Nombre = "nombre 1",
                Email = "correo1@dominio.com",
                Registrado = DateTime.Today,
                Telefono = "(123) 456-7890",
                Comentario = "..."
            });
            return View(contactos);
        }

        public ActionResult VerTienda(int id, string fecha) {
            var data = setData(id, DateTime.Parse(fecha));
            List<SernaSistemas.Core.Models.ContactoModel> contactos = new List<ContactoModel>();
            contactos.Add(new ContactoModel() {
                Nombre = "nombre 1",
                Email = "correo1@dominio.com",
                Registrado = DateTime.Today,
                Telefono = "(123) 456-7890",
                Comentario = "..."
            });
            return View(contactos);
        }
        public ActionResult VerLocal(int id, string fecha) {
            var data = setData(id, DateTime.Parse(fecha));
            List<SernaSistemas.Core.Models.ContactoModel> contactos = new List<ContactoModel>();
            contactos.Add(new ContactoModel() {
                Nombre = "nombre 1",
                Email = "correo1@dominio.com",
                Registrado = DateTime.Today,
                Telefono = "(123) 456-7890",
                Comentario = "..."
            });
            return View(contactos);
        }
        public ActionResult VerOferta(int id, string fecha) {
            var data = setData(id, DateTime.Parse(fecha));
            List<SernaSistemas.Core.Models.ContactoModel> contactos = new List<ContactoModel>();
            contactos.Add(new ContactoModel() {
                Nombre = "nombre 1",
                Email = "correo1@dominio.com",
                Registrado = DateTime.Today,
                Telefono = "(123) 456-7890",
                Comentario = "..."
            });
            return View(contactos);
        }
        public ActionResult VerContacto(int id, string fecha, int idcontacto) {
            var data = setData(id, DateTime.Parse(fecha));
            var model = new SernaSistemas.Core.Models.ContactoModel() {
                Nombre = "Nombre " + idcontacto.ToString(),
                Email = "contacto" + idcontacto.ToString() + "@dominio" + idcontacto.ToString() + ".com",
                Registrado = DateTime.Now,
                Telefono = "(123) 456-7890",
                Comentario = "Muy lejos, más allá de las montañas de palabras, alejados de los países de las vocales y las consonantes, viven los textos simulados. Viven aislados en casas de letras, en la costa de la semántica"
            };
            return View(model);
        }

        public ActionResult CrearTienda(int id, string fecha) {
            var data = setData(id, DateTime.Parse(fecha));
            return View();
        }
        public ActionResult CrearLocal(int id, string fecha) {
            var data = setData(id, DateTime.Parse(fecha));
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "item 1", Value = "1" });
            items.Add(new SelectListItem() { Text = "item 2", Value = "2" });
            items.Add(new SelectListItem() { Text = "item 3", Value = "3" });
            items.Add(new SelectListItem() { Text = "item 4", Value = "4" });
            ViewData.Add("Items", items);
            return View();
        }
        public ActionResult CrearOferta(int id, string fecha) {
            var data = setData(id, DateTime.Parse(fecha));
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "matríz", Value = "1" });
            items.Add(new SelectListItem() { Text = "local 2", Value = "2" });
            items.Add(new SelectListItem() { Text = "filial 3", Value = "3" });
            items.Add(new SelectListItem() { Text = "filial 4", Value = "4" });
            ViewData.Add("Locales", items);
            items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = Models.tipoOferta.Producto.ToString(), Value = "1" });
            items.Add(new SelectListItem() { Text = Models.tipoOferta.Servicio.ToString(), Value = "2" });
            ViewData.Add("Tipos", items);
            return View();
        }
        public ActionResult Responder(int id, string fecha) {
            var data = setData(id, DateTime.Parse(fecha));
            return View();
        }

        [HttpPost]
        public ActionResult GuardarDatos() {
            return View();
        }
        [HttpPost]
        public ActionResult GuardarTienda() {
            return View();
        }
        [HttpPost]
        public ActionResult GuardarLocal() {
            return View();
        }
        [HttpPost]
        public ActionResult GuardarOferta() {
            return View();
        }
        [HttpPost, ActionName("Responder")]
        public ActionResult enviarRespuesta() {
            return View();
        }
    }
}
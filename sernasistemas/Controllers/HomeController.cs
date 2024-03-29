﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using SernaSistemas.Core.Models;
using SernaSistemas.Models;
using WCFSernaSistemasLib;

namespace SernaSistemas.Controllers
{
    public class HomeController : Controller
    {
        const string URL_BLOGGER = "https://itcoffeecups.blogspot.com/";
        const string path = "Descargas/";

        private BloggerFeedModel GetPosts(string APIKey, string BlogID) {
            BloggerFeedModel model = new BloggerFeedModel();

            Google.Apis.Blogger.v3.BloggerService servicio = new Google.Apis.Blogger.v3.BloggerService(
                new Google.Apis.Services.BaseClientService.Initializer() {
                    ApiKey = APIKey
                });
            var r = servicio.Posts.List(BlogID);
            try {
                r.MaxResults = 10;
                var res = r.Execute();
                var ft = (from i in res.Items
                          select new {
                              i.Title,
                              i.Url,
                              i.Content
                          }).ToList();
                int k = 0;
                foreach (var item in ft) {
                    model.entries.Add(item.Title, item.Url);
                    if (k == 0) {
                        var c = item.Content.Substring(item.Content.IndexOf("<section>", 0), 200) + "...";
                        c = c.Replace("<section>", "").Replace("</section>", "").Replace("<p>", "").Replace("</p>", "").Replace("<p class=\"comentario\">", "").Replace("<code>", "").Replace("<br />", "");
                        model.topEntryContent = new KeyValuePair<string, string>(item.Title, c);
                    }
                    k++;
                }
            } catch (Exception ex) {
                model.MsgError = ex.Message;
            }
            return model;
        }

        public ActionResult Index(ContactoModel model) {
            var data = ViewBag;
            data = ViewData;
            return View(GetPosts(
                APIKey: "AIzaSyA9SEDz5J3h61m1xMkL2EPLyFWaCYqn2QA",
                BlogID: "3484139233446513265"
                ));
        }

        public ActionResult About() {
            return View();
        }

        public ActionResult Contact() {
            return View();
        }

        public ActionResult Servicios() {
            return View();
        }

        public ActionResult Productos() {
            return View();
        }

        public ActionResult Descargas() {
            return View();
        }

        public ActionResult Descargar(string archivo) {
            string ruta = AppDomain.CurrentDomain.BaseDirectory + path;
            byte[] fileBytes = System.IO.File.ReadAllBytes(ruta + archivo);

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, archivo);
        }

        //public ActionResult FormContacto() {
        //    return PartialView();
        //}

        //[HttpPost]
        //[ActionName("FormContacto")]
        //public ActionResult PostContacto(ContactoModel model) {
        //    model.Registrado = DateTime.Today;
        //    SernaSistemasServices servicio = new SernaSistemasServices();
        //    var response =
        //    servicio.registrarContacto(new ContactoRequest() {
        //        Nombre = model.Nombre,
        //        Telefono = model.Telefono,
        //        eMail = model.Email,
        //        Comentario = model.Comentario,
        //        FechaContacto = model.Registrado
        //    });
        //    ViewData.Add("mensaje", response.Mensaje);
        //    if (response.tieneError)
        //        return View("Error", response);
        //    return Redirect(Request.UrlReferrer.ToString());
        //}

        public JsonResult SendContacto(string nombre, string telefono, string correo, string comentario) {
            SernaSistemasServices servicio = new SernaSistemasServices();
            var response = servicio.registrarContacto(new ContactoRequest() {
                Nombre = nombre,
                Telefono = telefono,
                eMail = correo,
                Comentario = comentario,
                FechaContacto = DateTime.Today,
                Id = 0
            });
            if (response.tieneError)
                return Json(new { error = "SI", msg = response.Mensaje });
            return Json(new { error = "NO", msg = "Pronto me pondré en contacto contigo." });
        }

        public JsonResult ConsultaProyecto(int Folio) {
            SernaSistemasServices servicio = new SernaSistemasServices();
            var response = servicio.consultaProyecto(new ConsultaProyectoRequest() {
                Folio = Folio
            });
            if (response.tieneError)
                return Json(new { error = "SI", msg = response.Mensaje });
            return Json(new {
                error = "NO",
                msg = "Estado del proyecto",
                data = new {
                    Actividades = response.ActividadesRestantes,
                    Descripcion = response.Descripcion,
                    FechaTermino = response.FechaTermino.ToShortDateString(),
                    Proyecto = response.NombreProyecto,
                    Plataforma = response.Plataforma,
                    Sprint = response.Sprint
                }
            });
        }

        [HttpPost]
        public JsonResult Login(string usuario, string password, string  controller) {
            string token = Guid.NewGuid().ToString();
            Session.Add("token", token);
            Session.Add("Nombre", usuario);
            return Json(new {
                error = "NO",
                msg = "¡Bienvenido!",
                token = token
            });
        }

        [HttpPost]
        public JsonResult getApps() {
            return Json(new {
                error = "NO",
                msg = "",
                apps = "cotediv,biblioteca"
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SernaSistemas.Core.Models;
using SernaSistemas.Models;
using WCFSernaSistemasLib;

namespace SernaSistemas.Controllers {
    public class HomeController : Controller {
        const string URL_BLOGGER = "https://itcoffeecups.blogspot.com/";

        private BloggerFeedModel getPosts(string APIKey, string BlogID) {
            BloggerFeedModel model = new BloggerFeedModel();

            Google.Apis.Blogger.v3.BloggerService servicio = new Google.Apis.Blogger.v3.BloggerService(
                new Google.Apis.Services.BaseClientService.Initializer() {
                    ApiKey = APIKey
                });
            var r = servicio.Posts.List(BlogID);
            try {
                r.MaxResults = 10;
                var res = r.Execute();
                var ft = (from i in res.Items select new {
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
            return View(getPosts(
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

        public ActionResult FormContacto() {
            return PartialView();
        }

        [HttpPost]
        [ActionName("FormContacto")]
        public ActionResult postContacto(ContactoModel model) {
            model.Registrado = DateTime.Today;
            SernaSistemasServices servicio = new SernaSistemasServices();
            var response =
            servicio.registrarContacto(new ContactoRequest() {
                Nombre = model.Nombre,
                Telefono = model.Telefono,
                 eMail = model.Email,
                 Comentario = model.Comentario,
                 FechaContacto = model.Registrado
            });
            ViewData.Add("mensaje", response.Mensaje);
            if (response.tieneError)
                return View("Error", response);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
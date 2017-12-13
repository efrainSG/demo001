using System;
using System.Linq;
using System.Web.Mvc;
using SernaSistemas.Models;

namespace SernaSistemas.Controllers {
    public class HomeController : Controller {
        const string URL_BLOGGER = "https://itcoffeecups.blogspot.com/";

        public ActionResult Index() {
            BloggerFeedModel model = new BloggerFeedModel();
            Google.Apis.Blogger.v3.BloggerService servicio = new Google.Apis.Blogger.v3.BloggerService(
                new Google.Apis.Services.BaseClientService.Initializer() {
                    ApiKey = "AIzaSyA9SEDz5J3h61m1xMkL2EPLyFWaCYqn2QA"
                });
            var r = servicio.Posts.List("3484139233446513265");
            
            try {
                r.MaxResults = 10;
                var res = r.Execute();
                var ft = (from i in res.Items select i.Title).ToList();
                model.entries.AddRange(ft);
            } catch (Exception ex) {

            }
            return View(model);
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
        public ActionResult postContacto() {
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CoTeDiv {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {
                    controller = "Home", action = "Index", id = UrlParameter.Optional
                }
            );
            routes.MapRoute(
                name: "listarConceptoEstudiante",
                url: "Valorar/{id}/{valor}",
                defaults: new {
                    controller = "Estudiante",
                    action = "Valorar",
                    id = UrlParameter.Optional,
                    valor = UrlParameter.Optional
                }
                );
            routes.MapRoute(
                name: "listarConceptoExperto",
                url: "EvaluarConcepto/{id}/{valor}",
                defaults: new {
                    controller = "Estudiante",
                    action = "EvaluarConcepto",
                    id = UrlParameter.Optional,
                    valor = UrlParameter.Optional
                }
                );
        }
    }
}

using Google.GData.Blogger;
using Google.GData.Client;
using SernaSistemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SernaSistemas.Controllers
{
    public class BloggerController : Controller
    {
        // GET: Blogger
        public ActionResult Index()
        {
            
            return PartialView("feedBlogger");
        }
    }
}
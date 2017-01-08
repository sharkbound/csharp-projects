using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tutorial_asap_app.Controllers
{
    public class LinksController : Controller
    {
        // GET: Link
        public ActionResult Index()
        {
            return View();
        }
    }
}
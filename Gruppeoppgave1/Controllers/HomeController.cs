using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gruppeoppgave1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult registrer()
        {
            return View();
        }

        public ActionResult kjopBillet()
        {
            return View();
        }

        public ActionResult info()
        {
            return View();
        }
    }
}
using Gruppeoppgave1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gruppeoppgave1.Models;

namespace Gruppeoppgave1.Controllers
{
    public class HomeController : Controller
    {
		private DB db = new DB();

        // GET: Home
        public ActionResult Index()
        {
            DB db = new DB();
            return View();
        }

        public ActionResult Reisevalg ()
        {
            return View();
        }

        public ActionResult Kunde ()
        {
            return View();
        }

        public ActionResult Billett()
        {
            return View();
        }

    }
}
using Gruppeoppgave1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gruppeoppgave1.Controllers
{
    public class HomeController : Controller
    {
		private DB db = new DB();

        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(Reise innReise)
        {
            Session["Reise"] = innReise;
            return RedirectToAction("Reisevalg");
        }

        public ActionResult Reisevalg ()
        {
            return View();
        }

        public ActionResult Kunde ()
        {
            return View(Session["Reise"]);
        }
        [HttpPost]
        public ActionResult Kunde (Kunde innkunde)
        {
            Session["Kunde"] = innkunde;
            return RedirectToAction("Billet");
        }

        public ActionResult Billett()
        {
            return View();
        }

    }
}
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
            DB db = new DB();
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

        public ActionResult info2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult info2(Kunde innkune)
        {
            Session["Kunde"] = innkune; 
            return RedirectToAction("VisKunde");
        }

        public ActionResult VisKunde()
        {
            return View(Session["Kunde"]);
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
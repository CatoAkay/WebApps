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
        public ActionResult Index(KundeReise innReise)
        {
            
            Session["Reise"] = innReise;
            return RedirectToAction("Reiser");
        }

        public ActionResult Reisevalg ()
        {
            return View();
        }

        public ActionResult Kunde ()
        { 
             return View();
        }
        [HttpPost]
        public ActionResult Kunde (KundeReise innkunde)
        {
            Session["Kunde"] = innkunde;
            return RedirectToAction("dobbelModel");
        }

        public ActionResult Billett()
        {
            return View();
        }

        public ActionResult Reiser()
        { 
            return View(Session["Reise"]);
        }

        public ActionResult dobbelModel(KundeReise reise, KundeReise kunde)
        {
            Session["Kunde"] = kunde;
            Session["Reise"] = reise;
            return View();
        }

        public ActionResult KundeInfo()
        {
            
            return View(Session["Kunde"]);
        }

    }
}
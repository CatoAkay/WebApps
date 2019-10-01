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
            return RedirectToAction("dobbelModel");
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

        [HttpPost]
        public ActionResult dobbelModel(KundeReise innkunde, KundeReise kundeReise)
        {
            
            DB db = new DB();
            Billett billet = new Billett();
            
            kundeReise = (KundeReise)Session["Reise"];
            kundeReise.reise.Pris = 23;
            billet.Reise = kundeReise.reise;
            billet.Kunde = innkunde.kunde;
            db.Billett.Add(billet);
            db.Reise.Add(kundeReise.reise);
            db.Kunde.Add(innkunde.kunde);
            db.SaveChanges();
            
 
            return RedirectToAction("Billett") ;
        }

        public ActionResult dobbelModel()
        {
            return View(Session["Reise"]);
        }

        public ActionResult KundeInfo()
        {
      
            return View(Session["Kunde"]);
        }

    }
}

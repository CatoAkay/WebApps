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
        public ActionResult Index(KundeReise reiseInput)
        {
            
            Session["Reise"] = reiseInput;
            return RedirectToAction("ReiseInfo");
        }


        public ActionResult Kunde ()
        { 
             return View();
        }

        public ActionResult Reiser()
        { 
            return View(Session["Reise"]);
        }

        public ActionResult ReiseInfo()
        {
            return View(Session["Reise"]);
        }

        [HttpPost]
        public ActionResult ReiseInfo(KundeReise innkunde, KundeReise kundeReise)
        {
            Billett billet = new Billett();
            kundeReise = (KundeReise)Session["Reise"];
            kundeReise.reise.Pris = 23;
            billet.Reise = kundeReise.reise;
            billet.Kunde = innkunde.kunde;
            db.Billett.Add(billet);
            db.Reise.Add(kundeReise.reise);
            db.Kunde.Add(innkunde.kunde);
            db.SaveChanges();
            Session["ID"] = billet.ID;
           
            return RedirectToAction("Billett",Session["ID"]) ;
        }

        public ActionResult Billett()
        {
            var billettID = Session["ID"];
            DB db = new DB();
            var valgtBillett = db.Billett.Find(billettID);

            return View(valgtBillett);
        }

        /*  trenger den til reisevalg view fra cato
        public ActionResult Reisevalg ()
        {
            return View();
        }
        */

        /* brukes ikke enda
        public ActionResult KundeInfo()
        {
            return View(Session["Kunde"]);
        }
        */

        /* brukes ikke enda
        [HttpPost]
        public ActionResult Kunde (KundeReise innkunde)
        {
            Session["Kunde"] = innkunde;
            return RedirectToAction("ReiseInfo");
        }
        */

    }
}

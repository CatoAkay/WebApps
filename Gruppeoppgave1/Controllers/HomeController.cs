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
            return RedirectToAction("Reisevalg");
        }

        public ActionResult ReiseValg()
        {

            return View(Session["Reise"]);
        }

        public ActionResult Kunde ()
        { 
             return View();
        }

        public ActionResult Reiser()
        { 
            return View(Session["Reisen"]);
        }
        [HttpPost]
        public ActionResult ReiseInfo2()
        {
            return View(Session["Reisen"]);
        }

        [HttpPost]
        public ActionResult ReiseInfo(KundeReise info)
        {
            if (info.kunde == null)
            {
                var fra = Session["Fra"].ToString();
                var til = Session["Til"].ToString();
                var dato = Session["Dato"].ToString();
                var tid = Request["Tid"];
                double pris = Double.Parse(Request["Pris"]);
                var spor = Request["Spor"];
                var tog = Request["Tog"];
                int bytter = int.Parse(Request["Bytter"]);
                var avgang = Request["Avgang"];
                var ankomst = Request["Ankomst"];


                Reise reise = new Reise
                {

                    Fra = fra,
                    Til = til,
                    Dato = dato,
                    Tid = tid,
                    Pris = pris,
                    Spor = spor,
                    Tog = tog,
                    Bytter = bytter,
                    Avgang = avgang,
                    Ankomst = ankomst
                };

                KundeReise reisen = new KundeReise
                {
                    kunde = null,
                    reise = reise
                };
              

                Session["Reisen"] = reisen;

                return View(Session["Reisen"]);
            }


            Billett billet = new Billett();
            info.reise = ((KundeReise)Session["Reisen"]).reise;
            billet.Reise = info.reise;
            billet.Kunde = info.kunde;
            db.Billett.Add(billet);
            db.Reise.Add(info.reise);
            db.Kunde.Add(info.kunde);
            db.SaveChanges();
            Session["ID"] = billet.ID;

            return RedirectToAction("Billett", Session["ID"]);
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

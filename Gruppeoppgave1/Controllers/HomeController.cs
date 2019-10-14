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
        private Reise reise = new Reise();

        // GET: Home
        public ActionResult Index()
        {
            var tider = reise.getAlleTider();
            var reiseModel = new KundeReise();
            reiseModel.reiseTidene = reise.GetSelectListItems(tider);

            return View(reiseModel);
        }

        [HttpPost]
        public ActionResult Index(KundeReise reiseInput)
        {
            var tider = reise.getAlleTider();
            reiseInput.reiseTidene = reise.GetSelectListItems(tider);
            if (ModelState.IsValid)
            {
                Session["Reise"] = reiseInput;

                return RedirectToAction("Reisevalg");
            }
            return View(reiseInput);
        }

        public ActionResult ReiseValg()
        {
            return View(Session["Reise"]);
        }

        public ActionResult Kunde()
        {
            return View();
        }

        public ActionResult Reiser()
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

                 reise = new Reise
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

        public ActionResult Admin()
        {
            DB db = new DB();
            IEnumerable<Kunde> allebilleter = db.Kunde;
            return View(allebilleter);
        }

        public ActionResult SlettKunde(int ID)
        {
            DB db = new DB();
            Kunde valgkunde = db.Kunde.Find(ID);
            Reise valgtReise = db.Reise.Find(ID);
            Billett billett = db.Billett.Find(ID);
            Kredittkort kredidkort = db.Kredittkort.Find(ID);
            db.Kunde.Remove(valgkunde);
            db.Reise.Remove(valgtReise);
            db.Billett.Remove(billett);
            db.Kredittkort.Remove(kredidkort);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }

        public ActionResult EditKunde(int ID)
        {

            return View();
        }

        public ActionResult AdminReise(int ID)
        {
            DB db = new DB();
            Reise valgtreise = db.Reise.Find(ID);
            return View(valgtreise);
        }

        public ActionResult SlettReise(int ID)
        {
            DB db = new DB();
            Kunde valgkunde = db.Kunde.Find(ID);
            Reise valgtReise = db.Reise.Find(ID);
            Billett billett = db.Billett.Find(ID);
            Kredittkort kredidkort = db.Kredittkort.Find(ID);
            db.Kunde.Remove(valgkunde);
            db.Reise.Remove(valgtReise);
            db.Billett.Remove(billett);
            db.Kredittkort.Remove(kredidkort);

            db.SaveChanges();
            return RedirectToAction("Admin");
        }

    }
}

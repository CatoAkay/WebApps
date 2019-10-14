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
        Login admin = new Login();
        private Reise reise = new Reise();

        // GET: Home
        public ActionResult Index()
        {
            admin.Brukernavn = "admin";
            admin.ID = 1;
            admin.Passord = "admin";
            db.Login.Add(admin);
            db.SaveChanges();
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


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autorisasjon(Login admin)
        {
            using (DB db = new DB())
            {
                var adminDetail = db.Login.Where(x => x.Brukernavn == admin.Brukernavn && x.Passord == admin.Passord).FirstOrDefault();
                if (adminDetail == null)
                {
                    admin.loginMsgError = "Ikke gyldig brukernavn eller passord";
                    return View("Index", admin);
                }
                else
                {
                    Session["loginID"] = admin.ID;
                    return RedirectToAction("Index");
                }
            }
        }


    }


}

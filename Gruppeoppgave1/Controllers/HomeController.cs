using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace Gruppeoppgave1.Controllers
{
    public class HomeController : Controller
    {
        DatabaseLogikkBLL DB_bll = new DatabaseLogikkBLL();
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

        [HttpPost]
        public ActionResult ReiseInfo(KundeReise info)
        {
            if (info.kunde == null)
            {
                info.reise = new Reise
                {
                    Fra = Session["Fra"].ToString(),
                    Til = Session["Til"].ToString(),
                    Dato = Session["Dato"].ToString(),
                    Tid = Request["Tid"],
                    Pris = Double.Parse(Request["Pris"]),
                    Spor = Request["Spor"],
                    Tog = Request["Tog"],
                    Bytter = int.Parse(Request["Bytter"]),
                    Avgang = Request["Avgang"],
                    Ankomst = Request["Ankomst"]
                };
                Session["Reisen"] = info;
                return View(Session["Reisen"]);
            } 
            info.reise = ((KundeReise)Session["Reisen"]).reise; 
            var id = DB_bll.lagreBillett(info);
            Session["ID"] = id; 
            return RedirectToAction("Billett", Session["ID"]);
        }


        public ActionResult Billett()
        {
            var billettID = Session["ID"];
            var valgtBillett = DB_bll.getBillett((int)billettID);
            return View(valgtBillett);
        }
        
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Autorisasjon(Admin admin)
        { 
            if (DB_bll.Autorisasjon(admin))
            {
                return View("Login", admin); 
            }
            else
            {
                Session["loginID"] = admin.ID;
                return RedirectToAction("Index");
            }
        }

    }
}

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

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kunde()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegKunde (Models.Kunde innKunde)
        {
            using (var db = new Models.DB())
            {
                try
                {
                    db.Kunder.Add(innKunde);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
                return RedirectToAction("Liste");
            }
        }

        public ActionResult Liste()
        {
            using (var db = new Models.DB())
            {
                List<Models.Kunde> alleKunder = db.Kunder.ToList();
                return View(alleKunder);
            }
        }

        public ActionResult Slett (int Id)
        {
            using (var db = new Models.DB())
            {
                try
                {
                    Models.Kunde slettKunde = db.Kunder.Find(Id);
                    db.Kunder.Remove(slettKunde);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
                return RedirectToAction("Liste");
            }
        }
    }
}
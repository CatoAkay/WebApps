using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gruppeoppgave1.Models;

namespace Gruppeoppgave1.Controllers
{
    public class HomeController : Controller
    {
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
       
    }
}
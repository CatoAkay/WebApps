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
			DB Db = new DB();	
            return View();
        }

        public ActionResult Customer()
        {
            return View();
        }

        public ActionResult Destination()
        {
            return View();
        }

		public ActionResult Destination2()
		{
			return View();
		}


		public ActionResult Confirm()
        {
            return View();
        }


    }
}
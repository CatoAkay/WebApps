using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gruppeoppgave1.Controllers;
using BLL;
using DAL;
using Model;
using MvcContrib.TestHelper;

namespace Enhetstest
{

    /// Tester metoder i HomeController
    [TestClass]
    public class HomeControllerTest
    {
/*        [TestMethod]
        public void testIndex()
        {
            //Arrange
            var controller = new HomeController(new DatabaseLogikkBLL(new DatabaseLogikkStub()));
            Reise reise = new Reise
            {
                Ankomst = "14:00",
                Avgang = "12:00",
                Bytter = 1,
                Dato = "20.12.2019",
                Fra = "Asker",
                ID = 1,
                Pris = 159,
                Spor = "5",
                Tid = "2 t",
                Til = "Eidsvoll"
            };
            KundeReise kundeReise = new KundeReise
            {
                reise = reise
            };
            //Act
            var resultat = (RedirectToRouteResult) controller.Index();
            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "reiseModel");
        }*/
        
        [TestMethod]
        public void TestLoginView()
        {
            // Arrange
            var controller = new HomeController(new DatabaseLogikkBLL(new DatabaseLogikkStub()));
			
            // Act
            var result = (ViewResult) controller.Login();

            // Assert 
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void TestLagAdmin()
        {
			// Arrange
			Admin admin = new Admin
			{
				ID = 1,
				Brukernavn = "admin",
				Passord = "admin"
			};

			var controller = new HomeController(new DatabaseLogikkBLL(new DatabaseLogikkStub()));
			
			// Act
			var result = controller.lagAdmin(admin);
	        controller.listAdmin(admin);

			// Assert 
			var hei = 0;

        }

		[TestMethod]
        public void TestAutorisasjonFeil()
        {
            // Arrange
            Admin admin = new Admin
            {
                ID = 1,
                Brukernavn = "admin",
                Passord = ""
            };

            var controller = new HomeController(new DatabaseLogikkBLL(new DatabaseLogikkStub()));

            // act
            var result = (ViewResult) controller.Autorisasjon(admin);

            // Assert
            Assert.AreEqual(result.ViewName, "Login");
        }

        [TestMethod]
        public void TestAutorisasjonOk()
        {
            // Arrange
            Admin admin = new Admin
            {
                ID = 1,
                Brukernavn = "admin",
                Passord = "admin"
            };

            var controller = new HomeController(new DatabaseLogikkBLL(new DatabaseLogikkStub()));

            // act
            var result = (ViewResult)controller.Autorisasjon(admin);

            // Assert
            Assert.AreEqual(result.ViewName, "Login");
        }

        [TestMethod]
        public void TestLoggut()
        {
			// Arrange
			var SessionMock = new TestControllerBuilder(); 
			var controller = new HomeController(new DatabaseLogikkBLL(new DatabaseLogikkStub()));
			SessionMock.InitializeController(controller);
			controller.Session["idAdmin"] = 1;
			controller.Session["AdminNavn"] = "admin";
			
			// act
			var result = (RedirectToRouteResult)controller.Loggut();

			// Assert
			Assert.AreEqual(controller.Session["idAdmin"], null);
			Assert.AreEqual(controller.Session["AdminNavn"], null);
			Assert.AreEqual("", result.RouteName);

		}

        [TestMethod]
        public void TestAdminIngenAdgang()
        {
	        // Arrange
	        var SessionMock = new TestControllerBuilder();
	        var controller = new HomeController(new DatabaseLogikkBLL(new DatabaseLogikkStub()));
	        SessionMock.InitializeController(controller);
	        controller.Session["idAdmin"] = null;

	        // act
	        var result = (RedirectToRouteResult)controller.Admin();

	        // Assert
	        Assert.AreEqual("", result.RouteName);
		}

		[TestMethod]
		public void TestAdminSideOk()
		{
			// Arrange
			var SessionMock = new TestControllerBuilder();
			var controller = new HomeController(new DatabaseLogikkBLL(new DatabaseLogikkStub()));
			SessionMock.InitializeController(controller);
			controller.Session["idAdmin"] = 1;

			List<Kunde> alleKunder = new List<Kunde>();
			Kunde kunde = new Kunde
			{
				Email = "ole@hotmail.com",
				Etternavn = "Olavsen",
				Fornavn = "Ole",
				ID = 1,
				Telefon = "98765432"
			};
			Kunde kunde2 = new Kunde
			{
				Email = "knut@hotmail.com",
				Etternavn = "Bertilsen",
				Fornavn = "Knut",
				ID = 2,
				Telefon = "99765432"
			};
			Kunde kunde3 = new Kunde
			{
				Email = "knut@hotmail.com",
				Etternavn = "Bertilsen",
				Fornavn = "Knut",
				ID = 3,
				Telefon = "99965432"
			};
			alleKunder.Add(kunde);
			alleKunder.Add(kunde2);
			alleKunder.Add(kunde3);

			// act
			var result = (ViewResult)controller.Admin();
			var liste = (List<Kunde>) result.Model;


			// Assert
			Assert.AreEqual(result.ViewName, "");

			for (var i = 0; i < liste.Count; i++)
			{
				Assert.AreEqual(alleKunder[i].ID, liste[i].ID);
				Assert.AreEqual(alleKunder[i].Email, liste[i].Email);
				Assert.AreEqual(alleKunder[i].Fornavn, liste[i].Fornavn);
				Assert.AreEqual(alleKunder[i].Etternavn, liste[i].Etternavn);
				Assert.AreEqual(alleKunder[i].Telefon, liste[i].Telefon);
				
			}
		}

		[TestMethod]
        public void TestLoggs()
        {
	        // Removes milliseconds
	        var date = DateTime.Now;
	        date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind);

	        var controller = new HomeController(new DatabaseLogikkBLL(new DatabaseLogikkStub()));

	        var forventetResultat = new List<Logging>();
	        var logg = new Logging()
	        {
		        ID = 1,
		        DatoEndret = date,
		        Egenskap = "Egenskap",
		        Entitet = "Entitet",
		        GammelVerdi = "OldValue",
		        Nokkelverdi = "Verdi",
		        NyVerdi = "NyVerdi"

	        };
	        forventetResultat.Add(logg);
	        forventetResultat.Add(logg);
	        forventetResultat.Add(logg);
	        forventetResultat.Add(logg);
	        forventetResultat.Add(logg);

	        var resultat = (ViewResult)controller.Loggs();
	        var resultatListe = (List<Logging>)resultat.Model;

	        Assert.AreEqual(resultat.ViewName, "");

	        for (var i = 0; i < resultatListe.Count; i++)
	        {
		        Assert.AreEqual(forventetResultat[i].ID, resultatListe[i].ID);
		        Assert.AreEqual(forventetResultat[i].DatoEndret, resultatListe[i].DatoEndret);
		        Assert.AreEqual(forventetResultat[i].Egenskap, resultatListe[i].Egenskap);
		        Assert.AreEqual(forventetResultat[i].Entitet, resultatListe[i].Entitet);
		        Assert.AreEqual(forventetResultat[i].GammelVerdi, resultatListe[i].GammelVerdi);
		        Assert.AreEqual(forventetResultat[i].Nokkelverdi, resultatListe[i].Nokkelverdi);
		        Assert.AreEqual(forventetResultat[i].NyVerdi, resultatListe[i].NyVerdi);
	        }
        }
	}
}

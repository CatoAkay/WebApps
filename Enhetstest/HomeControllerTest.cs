using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gruppeoppgave1.Controllers;
using BLL;
using DAL;
using Model;

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
        public void TestAutorisasjonO()
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
            var result = (ViewResult)controller.Autorisasjon(admin);

            // Assert
            Assert.AreEqual(result.ViewName, "Login");
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

            var resultat = (ViewResult) controller.Loggs();
            var resultatListe = (List<Logging>)resultat.Model;

            Assert.AreEqual(resultat.ViewName,"");

            for (var i = 0; i< resultatListe.Count; i++)
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

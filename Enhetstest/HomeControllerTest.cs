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
        [TestMethod]
        public void TestIndexView()
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
            Kredittkort kredittkort = new Kredittkort
            {
                Cvc = "345",
                ID = 1,
                Kortnummer = "4444555566667777",
                Utlopsdato = "12/22"
            };
            Kunde kunde = new Kunde
            {
                Email = "ole@hotmail.com",
                Etternavn = "Olavsen",
                Fornavn = "Ole",
                ID = 1,
                Kredittkort = kredittkort,
                Telefon = "98765432"
            };
            KundeReise kundeReise = new KundeReise
            {
                kunde = kunde,
                reise = reise
            };
            //Act
            var index = controller.Index(kundeReise);
            //Assert
            Assert.Equals(index, kundeReise);
        }

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


    }
}

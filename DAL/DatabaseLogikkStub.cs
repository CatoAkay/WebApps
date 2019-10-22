using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DAL
{
    public class DatabaseLogikkStub : IDatabaseLogikkDAL
    {
        public void lagreBillett(KundeReise info)
        {
            List<Billett> alleBilletter = new List<Billett>();
            Billett billett = new Billett
            {
                ID = 1,
                Kunde = info.kunde,
                Reise = info.reise
            };
            alleBilletter.Add(billett);
        }

        public Billett getBillett(int id)
        {
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
            Billett billett = new Billett
            {
                Reise = reise, 
                Kunde = kunde,
                ID = id
            };
            return billett;
        }
        
        public IEnumerable<Kunde> getAlleKunder()
        {
            IEnumerable<Kunde> alleKunder = new List<Kunde>();
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
            alleKunder.Append(kunde);
            alleKunder.Append(kunde2);
            alleKunder.Append(kunde3);
            return alleKunder; 
        }         
        
        public IEnumerable<Admin> getAlleAdmin()
        {
            IEnumerable<Admin> alleAdmin = new List<Admin>();
            Admin admin = new Admin
            {
                Brukernavn = "Admin",
                ID = 1,
                Passord = "Admin"
            };            
            
            Admin admin2 = new Admin
            {
                Brukernavn = "Admin2",
                ID = 2,
                Passord = "Admin2"
            };
            alleAdmin.Append(admin);
            alleAdmin.Append(admin2);
            return alleAdmin;
        } 
        
        public void lagAdmin(Admin admin)
        {
            List<Admin> allAdmins = new List<Admin>();
            Admin nyAdmin = new Admin
            {
                Brukernavn = admin.Brukernavn,
                Passord = admin.Passord,
            };
            allAdmins.Add(nyAdmin);
        }

        public void slettAdmin(int ID)
        {
            List<Admin> allAdmins = new List<Admin>();
            Admin slettetAdmin = new Admin
            {
                Brukernavn = "Admin",
                Passord = "admin",
                ID = ID,
            };
            allAdmins.Add(slettetAdmin);
            allAdmins.Remove(slettetAdmin);
        }

        public void slettKunde(int ID)
        {
            List<Kunde> alleKunder = new List<Kunde>();
            Kunde kunde = new Kunde
            {
                Email = "ole@hotmail.com",
                Etternavn = "Olavsen",
                Fornavn = "Ole",
                ID = ID,
                Telefon = "98765432"
            };
            alleKunder.Add(kunde);
            alleKunder.Remove(kunde);
        }

        public Kunde editKunde(int ID)
        {
            Kunde kunde = new Kunde
            {
                Email = "ole@hotmail.com",
                Etternavn = "Olavsen",
                Fornavn = "Ole",
                ID = ID,
                Telefon = "98765432"
            };
            return kunde;
        }

        public void editKunde(Kunde kunde)
        {
            kunde.Fornavn = "Hans";
            kunde.Etternavn = "Kristian";
        }

        public Reise seReise(int ID)
        {
            Reise reise = new Reise
            {
                Ankomst = "14:00",
                Avgang = "12:00",
                Bytter = 1,
                Dato = "20.12.2019",
                Fra = "Asker",
                ID = ID,
                Pris = 159,
                Spor = "5",
                Tid = "2 t",
                Til = "Eidsvoll"
            };
            return reise;
        }

        public void seReise(Reise reise)
        {
            List<Reise> denReisen = new List<Reise>();
            Reise seReise = new Reise
            {
                Ankomst = reise.Ankomst,
                Avgang = reise.Avgang,
                Bytter = reise.Bytter,
                Dato = reise.Dato,
                Fra = reise.Fra,
                ID = reise.ID,
                Pris = reise.Pris,
                Spor = reise.Spor,
                Tid = reise.Tid,
                Til = reise.Til,
            };
            denReisen.Add(seReise);
        }

        public void slettReise(int ID)
        {
            List<Reise> alleReiser = new List<Reise>();
            Reise slettetReise = new Reise
            {
                Ankomst = "14:00",
                Avgang = "12:00",
                Bytter = 1,
                Dato = "20.12.2019",
                Fra = "Asker",
                ID = ID,
                Pris = 159,
                Spor = "5",
                Tid = "2 t",
                Til = "Eidsvoll"
            };
            alleReiser.Add(slettetReise);
            alleReiser.Remove(slettetReise);
        }
        
        public bool Autorisasjon(Admin admin)
        {
            throw new NotImplementedException("Ikke laget enda");
        }
    }
}
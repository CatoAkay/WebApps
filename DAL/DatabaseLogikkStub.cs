using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DAL
{
    public class DatabaseLogikkStub : IDatabaseLogikkDAL
    {
        private DB db = new DB();

        public DatabaseLogikkStub()
        {
            db.setAdmin();
        }

        public void lagreBillett(KundeReise info)
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
                Kunde = kunde
            };
        }

        public Billett getBillett(int id)
        {
            return db.Billett.Find(id);
        }
        
        public IEnumerable<Kunde> getAlleKunder()
        {
            IEnumerable<Kunde> allebilleter = db.Kunde;
            return allebilleter;
        }         
        
        public IEnumerable<Admin> getAlleAdmin()
        {
            IEnumerable<Admin> alleAdmin = db.Admin;
            return alleAdmin;
        } 
        
        public void lagAdmin(Admin admin)
        {
            DB db = new DB();
            db.Admin.Add(admin);
            db.SaveChanges();
        }

        public void slettAdmin(int ID)
        {
            DB db = new DB();
            Admin admin = db.Admin.Find(ID);
            db.Admin.Remove(admin);
            db.SaveChanges();
        }

        public void slettKunde(int ID)
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
        }

        public Kunde editKunde(int ID)
        {
            Kunde kunde = db.Kunde.Find(ID);
            return kunde;
        }

        public void editKunde(Kunde kunde)
        {
            db.Kunde.Attach(kunde);
            db.Entry(kunde).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Reise seReise(int ID)
        {
            Reise reise = db.Reise.Find(ID);
            return reise;
        }

        public void seReise(Reise reise)
        {
            db.Reise.Attach(reise);
            db.Entry(reise).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void slettReise(int ID)
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
        }
        
        public bool Autorisasjon(Admin admin)
        { 
            using (db)
            {
                var adminDetail = db.Admin.FirstOrDefault(x => x.Brukernavn == admin.Brukernavn && x.Passord == admin.Passord);
                if (adminDetail == null)
                { 
                    admin.loginMsgError = "Ikke gyldig brukernavn eller passord";
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }
    }
}
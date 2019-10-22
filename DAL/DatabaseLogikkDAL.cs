using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DAL
{
    public class DatabaseLogikkDAL : IDatabaseLogikkDAL
    {
        private DB db = new DB();

        public DatabaseLogikkDAL()
        {
            db.setAdmin();
        }

        public void lagreBillett(KundeReise info)
        {
            try
            {
                Billett billett = new Billett
                {
                    Reise = info.reise,
                    Kunde = info.kunde
                };
                db.Billett.Add(billett);

                db.Reise.Add(info.reise);
                db.Kunde.Add(info.kunde);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Logging.ErrorTilFil(e);
            }
            
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
            try
            {
                DB db = new DB();
                Admin admin = db.Admin.Find(ID);
                db.Admin.Remove(admin);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Logging.ErrorTilFil(e);
            }
            
        }

        public void slettKunde(int ID)
        {
            try
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
            catch (Exception e)
            {
                Logging.ErrorTilFil(e);
            }
           
        }

        public Kunde editKunde(int ID)
        {
            Kunde kunde = db.Kunde.Find(ID);
            return kunde;
        }

        public void editKunde(Kunde kunde)
        {
            try
            {
                db.Kunde.Attach(kunde);
                db.Entry(kunde).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Logging.ErrorTilFil(e);
            }
           
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
            try
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
            catch (Exception e)
            {
                Logging.ErrorTilFil(e);
            }
            
        }

        public bool Autorisasjon(Admin admin)
        {   
            using (db)
            {
                var adminDetail =
                    db.Admin.FirstOrDefault(x => x.Brukernavn == admin.Brukernavn && x.Passord == admin.Passord);
                if (adminDetail == null)
                {
                    admin.loginMsgError = "Ikke gyldig brukernavn eller passord";
                    return false;

                }
                else
                {
                    return true;
                }
            }
            
        }
    }
}
using System.Linq;
using Model;

namespace DAL
{
    public class DatabaseLogikkDAL
    {
        private DB db = new DB();

        public void lagreBillett(KundeReise info)
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

        public Billett getBillett(int id)
        {
            return db.Billett.Find(id);
        }
        
        public bool Autorisasjon(Admin admin)
        { 
            using (db)
            {
                var adminDetail = db.Login.FirstOrDefault(x => x.Brukernavn == admin.Brukernavn && x.Passord == admin.Passord);
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
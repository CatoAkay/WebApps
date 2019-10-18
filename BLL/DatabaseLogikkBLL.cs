using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public class DatabaseLogikkBLL
    {
        DatabaseLogikkDAL DBdal = new DatabaseLogikkDAL();
        public int lagreBillett(KundeReise info)
        { 
            DBdal.lagreBillett(info);
            return info.kunde.ID;
        }
        
        public Billett getBillett(int id)
        {
            return DBdal.getBillett(id);
        }

        public Admin Autorisasjon(Admin admin)
        {
            return DBdal.Autorisasjon(admin);
        }
        
        public IEnumerable<Kunde> getAlleKunder()
        {
            return DBdal.getAlleKunder();
        } 
        
        public IEnumerable<Admin> getAlleAdmin()
        {
            return DBdal.getAlleAdmin();
        }
        
        public void lagAdmin(Admin admin)
        {
            DBdal.lagAdmin(admin);
        }

        public void slettAdmin(int ID)
        {
            DBdal.slettAdmin(ID);
        }

        public void slettKunde(int ID)
        {
            DBdal.slettKunde(ID);
        }

        public Kunde editKunde(int ID)
        {
            return DBdal.editKunde(ID);
        }

        public void editKunde(Kunde kunde)
        {
            DBdal.editKunde(kunde);
        }

        public Reise seReise(int ID)
        {
            return DBdal.seReise(ID);
        }

        public void seReise(Reise reise)
        {
            DBdal.seReise(reise);
        }

        public void slettReise(int ID)
        {
            DBdal.slettReise(ID);
        }

    }
}
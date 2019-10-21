using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public class DatabaseLogikkBLL : IDatabaseLogikkBLL
    {
        private IDatabaseLogikkDAL _databaseLogikkDal;

        public DatabaseLogikkBLL()
        {
            _databaseLogikkDal = new DatabaseLogikkDAL();
        }

        public DatabaseLogikkBLL(IDatabaseLogikkDAL stub)
        {
            _databaseLogikkDal = stub;
        }
        public int lagreBillett(KundeReise info)
        { 
            _databaseLogikkDal.lagreBillett(info);
            return info.kunde.ID;
        }
        
        public Billett getBillett(int id)
        {
            return _databaseLogikkDal.getBillett(id);
        }

        public bool Autorisasjon(Admin admin)
        {
            return _databaseLogikkDal.Autorisasjon(admin);
        }
        
        public IEnumerable<Kunde> getAlleKunder()
        {
            return _databaseLogikkDal.getAlleKunder();
        } 
        
        public IEnumerable<Admin> getAlleAdmin()
        {
            return _databaseLogikkDal.getAlleAdmin();
        }
        
        public void lagAdmin(Admin admin)
        {
            _databaseLogikkDal.lagAdmin(admin);
        }

        public void slettAdmin(int ID)
        {
            _databaseLogikkDal.slettAdmin(ID);
        }

        public void slettKunde(int ID)
        {
            _databaseLogikkDal.slettKunde(ID);
        }

        public Kunde editKunde(int ID)
        {
            return _databaseLogikkDal.editKunde(ID);
        }

        public void editKunde(Kunde kunde)
        {
            _databaseLogikkDal.editKunde(kunde);
        }

        public Reise seReise(int ID)
        {
            return _databaseLogikkDal.seReise(ID);
        }

        public void seReise(Reise reise)
        {
            _databaseLogikkDal.seReise(reise);
        }

        public void slettReise(int ID)
        {
            _databaseLogikkDal.slettReise(ID);
        }

    }
}
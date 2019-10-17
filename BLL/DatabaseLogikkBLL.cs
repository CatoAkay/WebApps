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

        public bool Autorisasjon(Admin admin)
        {
            return DBdal.Autorisasjon(admin);
        }
    }
}
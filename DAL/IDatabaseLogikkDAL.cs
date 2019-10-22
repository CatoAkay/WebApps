using System.Collections.Generic;
using Model;

namespace DAL
{
    public interface IDatabaseLogikkDAL
    {
        void lagreBillett(KundeReise info);
        Billett getBillett(int id);
        IEnumerable<Kunde> getAlleKunder();
        IEnumerable<Admin> getAlleAdmin();
        void lagAdmin(Admin admin);
        void slettAdmin(int ID);
        void slettKunde(int ID);
        Kunde editKunde(int ID);
        void editKunde(Kunde kunde);
        Reise seReise(int ID);
        void seReise(Reise reise);
        void slettReise(int ID);
        Admin Autorisasjon(Admin admin);
        IEnumerable<Logging> getAlleLoggs();
    }
}
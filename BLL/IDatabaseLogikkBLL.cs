using System.Collections.Generic;
using Model;

namespace BLL
{
    public interface IDatabaseLogikkBLL
    {
        int lagreBillett(KundeReise info);
        Billett getBillett(int id);
        Admin Autorisasjon(Admin admin);
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
        IEnumerable<Logging> getAlleLoggs();
    }
}
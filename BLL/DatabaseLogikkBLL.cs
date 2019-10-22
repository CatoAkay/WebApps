using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            string skrevetPassord = admin.Passord;

            Admin admin2 = verifiserPassord(admin, skrevetPassord);
                

            return admin2;
        }

        public Admin AutorisasjonAdmin(Admin admin)
        {
            return DBdal.AutorisasjonAdmin(admin);
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
            admin.Passord = lageSikkertPassord(admin.Passord);
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

        public IEnumerable<Logging> getAlleLoggs()
        {
            return DBdal.getAlleLoggs();
        }

        public string lageSikkertPassord(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var rfc = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = rfc.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0,16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string lagtHashetPassord = Convert.ToBase64String(hashBytes);

            return lagtHashetPassord;
        }

        public Admin verifiserPassord(Admin innAdmin, string userPassord)
        {
            Admin admin = DBdal.Autorisasjon(innAdmin);
            string hashetPassord = admin.Passord;

            byte[] hashBytes = Convert.FromBase64String(hashetPassord);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes,0, salt, 0,16);

            var rfc = new Rfc2898DeriveBytes(userPassord, salt, 10000);
            byte[] hash = rfc.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return null;
                }
            }

            return admin;
        }

    }
}
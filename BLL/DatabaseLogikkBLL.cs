using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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

        public Admin Autorisasjon(Admin admin)
        {
            string skrevetPassord = admin.Passord;

            Admin admin2 = verifiserPassord(admin, skrevetPassord);
                

            return admin2;
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
            admin.Passord = lageSikkertPassord(admin.Passord);
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

        public IEnumerable<Logging> getAlleLoggs()
        {
            return _databaseLogikkDal.getAlleLoggs();
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
            
	        Admin admin = _databaseLogikkDal.Autorisasjon(innAdmin);
            if (admin == null)
            {
                return null;
            }

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
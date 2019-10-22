using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DAL
{
    public class DatabaseLogikkStub : IDatabaseLogikkDAL
    {

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
			throw new NotImplementedException();

		}

		public IEnumerable<Kunde> getAlleKunder()
        {
	        throw new NotImplementedException();
        }         
        
        public IEnumerable<Admin> getAlleAdmin()
        {
			throw new NotImplementedException();

		}

		public void lagAdmin(Admin admin)
        {
			throw new NotImplementedException();

		}

		public void slettAdmin(int ID)
        {
			throw new NotImplementedException();

		}

		public void slettKunde(int ID)
        {
			throw new NotImplementedException();

		}

		public Kunde editKunde(int ID)
        {
			throw new NotImplementedException();

		}

		public void editKunde(Kunde kunde)
        {
			throw new NotImplementedException();

		}

		public Reise seReise(int ID)
        {
			throw new NotImplementedException();

		}

		public void seReise(Reise reise)
        {
			throw new NotImplementedException();

		}

		public void slettReise(int ID)
        {
			throw new NotImplementedException();

		}

		public bool Autorisasjon(Admin admin)
        {
	        Admin dbAdmin = new Admin
	        {
		        ID = 1, 
				Brukernavn = "admin",
				Passord = "admin"
	        };

	        if (admin.Brukernavn == dbAdmin.Brukernavn && admin.Passord == dbAdmin.Passord)
	        {
		        admin.loginMsgError = "Ikke gyldig brukernavn eller passord";
		        return true;

			}
	        return false;

        }
	}
}
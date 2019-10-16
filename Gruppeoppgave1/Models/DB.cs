using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.EnterpriseServices;
using System.Linq;

namespace Gruppeoppgave1.Models
{
    public class DB : DbContext
    {
        public DB() : base("name=Vy")
        {
            Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void setAdmin()
        {
            DB db = new DB();
            if (db.Admin.Find(1) == null)
            {
                var admin = new Admin
                {
                    Brukernavn = "admin",
                    Passord = "admin",
                };
                db.Admin.Add(admin);
                db.SaveChanges();
            }
        }

		public DbSet<Kunde> Kunde { get; set; }
		public DbSet<Billett> Billett { get; set; }
        public DbSet<Reise> Reise { get; set; }
        public DbSet<Kredittkort> Kredittkort { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }

        

        
        
    }
}
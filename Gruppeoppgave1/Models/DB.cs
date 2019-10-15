using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gruppeoppgave1.Models
{
    public class DB : DbContext
    {
        private Admin lag = new Admin();
        public DB() : base("name=Vy")
        {
            Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                
              
        }

		public DbSet<Kunde> Kunde { get; set; }
		public DbSet<Billett> Billett { get; set; }
        public DbSet<Reise> Reise { get; set; }
        public DbSet<Kredittkort> Kredittkort { get; set; }
        public DbSet<Admin> Login { get; set; }

        
        
    }
}
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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

		public virtual DbSet<Kunde> Kunde { get; set; }
		public virtual DbSet<Billett> Billett { get; set; }
        public virtual DbSet<Reise> Reise { get; set; }
        public virtual DbSet<Kredittkort> Kredittkort { get; set; }
    }
}
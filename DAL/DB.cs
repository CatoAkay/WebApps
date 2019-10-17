using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Model;

namespace DAL
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

		public DbSet<Kunde> Kunde { get; set; }
		public DbSet<Billett> Billett { get; set; }
        public DbSet<Reise> Reise { get; set; }
        public DbSet<Kredittkort> Kredittkort { get; set; }
        public DbSet<Admin> Login { get; set; }
    }
}
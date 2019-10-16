using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified).ToList();
            var now = DateTime.UtcNow;

            foreach (var change in modifiedEntities)
            {
                var entityName = change.Entity.GetType().Name;
                var primaryKey = GetPrimaryKeyValue(change);

                foreach (var prop in change.OriginalValues.PropertyNames)
                {

                    // lagre orginalValue if currentvalue er ulik databasen sine verdier i entityName sin tabell. 
                    var orginalValue = change.OriginalValues[prop].ToString();
                    var currentValue = change.CurrentValues[prop].ToString();

                    if (orginalValue != currentValue)
                    {

                        var log = new Logging()
                        {
                            EntityName = entityName,
                            PrimaryKeyValue = primaryKey.ToString(),
                            PropertyName = prop,
                            OldValue = orginalValue,
                            NewValue = currentValue,
                            DateChanged = now
                        };
                        Logg.Add(log);
                    }
                }
            }
            return base.SaveChanges();
        } 

        object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry =
                ((IObjectContextAdapter) this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }

		public virtual DbSet<Kunde> Kunde { get; set; }
		public virtual DbSet<Billett> Billett { get; set; }
        public virtual DbSet<Reise> Reise { get; set; }
        public virtual DbSet<Kredittkort> Kredittkort { get; set; }
        public virtual DbSet<Logging> Logg { get; set; }
    }
}
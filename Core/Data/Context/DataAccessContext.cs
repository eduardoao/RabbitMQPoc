using Data.Migrations;
using Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.Context
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext() : base("DataAccessContextDb")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataAccessContext, Configuration>("DataAccessContextDb"));           

        }
        public DbSet<AplicationDomain> AplicationDomains { get; set; }        
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}


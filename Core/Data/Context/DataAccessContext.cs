//using Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
using Data.Mapping;
using Domain.Entities;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data.Entity;

namespace  Data.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataAccessContext: DbContext
    {
        //Todo 
        //Injeção de dependência      
        

        public DataAccessContext(DbConnection existingConnection, bool contextOwnsConnection)
        //: base(existingConnection, contextOwnsConnection)
        {
           
        }

        public DataAccessContext():base()
        {
         
        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AplicationDomain> AplicationDomains { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Usuario>(new UsuarioMap().Configure); .Map(;//.MapToStoredProcedures()
            modelBuilder.Entity<Usuario>().ToTable("User");
            modelBuilder.Entity<AplicationDomain>().ToTable("aplicationdomain");
        }

    }
}

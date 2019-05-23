using Domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace Data.Mapping
{
    internal class AplicationDomainMap : EntityTypeConfiguration<Usuario>
    {
        public AplicationDomainMap()
        {
          
        }

        //public void Configure(EntityTypeBuilder<Usuario> builder)
        //{
        //    builder.ToTable("Usuarios");
        //    builder.HasKey(u => u.Id);
        //    builder.Property(u => u.Login).HasColumnName("Login").HasMaxLength(30); 
        //}
    }
}
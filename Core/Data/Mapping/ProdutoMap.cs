using Domain.Entities;
using System.Data.Entity.ModelConfiguration;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    internal class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
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
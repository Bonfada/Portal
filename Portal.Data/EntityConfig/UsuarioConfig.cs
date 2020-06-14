using BD.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Portal.BD.EntityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nome).IsRequired().HasMaxLength(50);
            Property(c => c.Login).IsRequired().HasMaxLength(15);
            Property(c => c.Senha).IsRequired().HasMaxLength(8);
            Property(c => c.Email).IsRequired().HasMaxLength(50);
        }
    }
}

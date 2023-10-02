using ApiUsuarios.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Data.Configurations
{
    public class EscolaridadeConfiguration : IEntityTypeConfiguration<EscolaridadeEntity>
    {
        public void Configure(EntityTypeBuilder<EscolaridadeEntity> builder)
        {
            builder.HasKey(e => e.IdEscolaridade);

            builder.Property(e => e.Escolaridade)
              .HasMaxLength(40)
              .IsRequired();

            builder
             .HasMany(e => e.Usuarios)  // Uma Escolaridade pode ter muitos Usuarios
             .WithOne(u => u.Escolaridade) // Um Usuario pertence a uma Escolaridade
             .HasForeignKey(u => u.IdEscolaridade) // Chave estrangeira em Usuario que se relaciona com a chave primária em Escolaridade
             .OnDelete(DeleteBehavior.NoAction); // Ação de exclusão (no caso, você configurou para NoAction)
        }
    }
}

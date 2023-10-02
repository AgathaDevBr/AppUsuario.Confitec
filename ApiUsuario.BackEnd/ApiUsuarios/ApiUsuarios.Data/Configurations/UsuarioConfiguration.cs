using ApiUsuarios.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.HasKey(u => u.IdUsuario);

            builder.Property(u => u.Nome)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(u => u.SobreNome)
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.DataNascimento)
                .HasColumnType("Date")
                .IsRequired();


            builder.HasOne(c => c.Escolaridade) //Usuario PERTENCE A 1 Escolaridade
                  .WithMany(c => c.Usuarios) //Escolaridade TEM MUITAS Usuarios
                  .HasForeignKey(c => c.IdEscolaridade) //CHAVE ESTRANGEIRA
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

using ApiUsuarios.Data.Configurations;
using ApiUsuarios.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-E926I52;Initial Catalog=DbUsuarios.Confitec;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        /// <summary>
        /// Método para adicionar as classes de mapeamento do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EscolaridadeConfiguration());
        }

        /// <summary>
        /// Propriedade para fornecer os métodos do repositório
        /// </summary>
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<EscolaridadeEntity> Escolaridade { get; set; }
    }
}

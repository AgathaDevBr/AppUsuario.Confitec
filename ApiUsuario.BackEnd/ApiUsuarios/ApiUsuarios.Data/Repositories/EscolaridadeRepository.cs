using ApiUsuarios.Data.Contexts;
using ApiUsuarios.Data.Entities;
using ApiUsuarios.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Data.Repositories
{
    public class EscolaridadeRepository : IEscolaridadeRepository
    {
        public ICollection<EscolaridadeEntity> GetEscolaridade()
        {
            using (var context = new DataContext())
            {
                return context.Escolaridade.AsEnumerable().ToList();
            }
        }

        public EscolaridadeEntity GetEscolaridadeById(int? id)
        {
            using (var context = new DataContext())
            {
                return context.Escolaridade
                .FirstOrDefault(i => i.IdEscolaridade.Equals(id));
            }
        }
    }
}

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
    public class UsuarioRepository : IBaseRepository<UsuarioEntity>, IUsuarioRepository
    {
        public void Add(UsuarioEntity entity)
        {
            using (var context = new DataContext())
            {
                context.Usuarios.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(UsuarioEntity entity)
        {
            using (var context = new DataContext())
            {
                context.Usuarios.Remove(entity);
                context.SaveChanges();
            }
        }

        public List<UsuarioEntity> GetAll()
        {
            using (var context = new DataContext())
            {
               return context.Usuarios
                    .AsEnumerable().ToList();
            }
        }

        public UsuarioEntity GetByEmail(string email)
        {
            using (var context = new DataContext())
            {
                return context.Usuarios
                    .FirstOrDefault(i => i.Email.Equals(email));
            }
        }

        public UsuarioEntity GetById(int id)
        {
            using (var context = new DataContext())
            {
                return context.Usuarios
                    .FirstOrDefault(i => i.IdUsuario.Equals(id));
            }
        }

        public void Update(UsuarioEntity entity)
        {
            using (var context = new DataContext())
            {
                context.Usuarios.Update(entity);
                context.SaveChanges();
            }
        }
    }
}

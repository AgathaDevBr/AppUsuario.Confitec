using ApiUsuarios.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Data.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<UsuarioEntity>
    {
        UsuarioEntity GetByEmail(string email);
    }
}

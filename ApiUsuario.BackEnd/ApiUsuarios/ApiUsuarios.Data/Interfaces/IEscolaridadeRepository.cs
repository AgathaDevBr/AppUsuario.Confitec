using ApiUsuarios.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Data.Interfaces
{
    public interface IEscolaridadeRepository
    {
        EscolaridadeEntity GetEscolaridadeById(int? id);
        ICollection<EscolaridadeEntity> GetEscolaridade();
    }
}

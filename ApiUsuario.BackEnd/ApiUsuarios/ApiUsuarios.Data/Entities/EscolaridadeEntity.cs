using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Data.Entities
{
    public class EscolaridadeEntity
    {
        public int? IdEscolaridade { get; set; }
        public string? Escolaridade { get; set; }
        public ICollection<UsuarioEntity>? Usuarios { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Data.Entities
{
    public class UsuarioEntity
    {
        public int? IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? IdEscolaridade { get; set; }
        public EscolaridadeEntity? Escolaridade { get; set; }
    }
}

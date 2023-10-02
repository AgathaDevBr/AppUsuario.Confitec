using ApiUsuarios.Data.Entities;

namespace ApiUsuarios.Services.Models
{
    public class UsuarioViewModel
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

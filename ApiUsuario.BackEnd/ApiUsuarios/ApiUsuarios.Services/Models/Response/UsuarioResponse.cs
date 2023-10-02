namespace ApiUsuarios.Services.Models.Response
{
    public class UsuarioResponse
    {
        public int? Status { get; set; }
        public string? Mensagem { get; set; }
        public UsuarioViewModel? Usuario { get; set; }
    }
}

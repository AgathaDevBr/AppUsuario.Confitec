using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Services.Models.Request
{
    public class EscolaridadeCreateRequest
    {
        public int IdEscolaridade { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [RegularExpression(pattern: "^[A-Za-zÀ-Üà-ü\\s]{6,40}$", ErrorMessage = "Informe uma escolaridade válida " +
        "até 40 caracteres.")]
        public string? Escolaridade { get; set; }
    }
}

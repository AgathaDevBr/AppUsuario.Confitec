using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Services.Models.Request
{
    public class UsuarioUpdateRequest
    {
        [Required(ErrorMessage = "Escolaridade é obrigatório.")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Escolaridade é obrigatório.")]
        public int IdEscolaridade { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [RegularExpression(pattern: "^[A-Za-zÀ-Üà-ü\\s]{1,20}$", ErrorMessage = "Informe um nome válido " +
        "de 1 a 20 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório.")]
        [RegularExpression(pattern: "^[A-Za-zÀ-Üà-ü\\s]{1,100}$", ErrorMessage = "Informe um nome válido " +
        "de 1 a 100 caracteres.")]
        public string? Sobrenome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

    }
}

using ApiUsuarios.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Services.Models.Request
{
    public class UsuarioCreateRequest
    {
        public int IdEscolaridade { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MinLength(5, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório.")]
        [MinLength(5, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string? Sobrenome { get; set; }

        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatório.")]
        public DateTime? DataNascimento { get; set; }

    }
}

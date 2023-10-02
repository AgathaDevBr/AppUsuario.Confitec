using ApiUsuarios.Data.Contexts;
using ApiUsuarios.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Services.Models
{
    public class EscolaridadeViewModel
    {
        public int IdEscolaridade { get; set; }
        public string? Escolaridade { get; set; }
    }
}

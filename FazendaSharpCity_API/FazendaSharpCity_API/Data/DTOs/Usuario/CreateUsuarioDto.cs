using Microsoft.OpenApi.Extensions;
using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Usuario
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter no minimo 6 caracteres")]
        public string Password { get; set; }
    }
}

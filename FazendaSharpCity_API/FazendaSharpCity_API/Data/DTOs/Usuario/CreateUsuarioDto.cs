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
        public string Password { get; set; }
    }
}

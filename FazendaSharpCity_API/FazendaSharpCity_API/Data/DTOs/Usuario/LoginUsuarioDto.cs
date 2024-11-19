using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Usuario
{
    public class LoginUsuarioDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

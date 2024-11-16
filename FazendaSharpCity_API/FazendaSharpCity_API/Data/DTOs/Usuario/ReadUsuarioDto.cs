using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Usuario
{
    public class ReadUsuarioDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

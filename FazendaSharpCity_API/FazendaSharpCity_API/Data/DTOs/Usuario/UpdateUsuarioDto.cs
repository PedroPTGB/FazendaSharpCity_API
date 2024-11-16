using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Usuario
{
    public class UpdateUsuarioDto
    {
        [Required(ErrorMessage = "O login e obrigatorio.")]
        [MinLength(5, ErrorMessage = "O login deve ter pelo menos 5 caracteres.")]
        [MaxLength(15, ErrorMessage = "O login não pode exceder 15 caracteres.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha e obrigatoria.")]
        [MinLength(4, ErrorMessage = "A senha deve ter no minimo 4 caracteres.")]
        [MaxLength(10, ErrorMessage = "A senha não pode exceder 10 caracteres.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}

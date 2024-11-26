using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Funcionario
{
    public class UpdateFuncionarioDto
    {
        [Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 dígitos numéricos.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
        public string Email { get; set; }

        [RegularExpression(@"^\(?\d{2}\)?[\s-]?[\d]{4,5}-?[\d]{4}$", ErrorMessage = "O telefone deve estar em um formato válido (ex: (99) 99999-9999).")]
        public string TelefoneFuncionario { get; set; }

        [Required(ErrorMessage = "O id do endereco é obrigatório")]
        public int EnderecoId { get; set; }
    }
}

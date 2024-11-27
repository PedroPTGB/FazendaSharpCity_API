using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Models
{
    public class UpdateFornecedorDto
    {
        [Required(ErrorMessage = "A Razão Social é obrigatória.")]
        [StringLength(100, ErrorMessage = "A Razão Social não pode exceder 100 caracteres.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O Nome Fantasia é obrigatório.")]
        [StringLength(150, ErrorMessage = "O Nome Fantasia não pode exceder 150 caracteres.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve conter exatamente 14 dígitos numéricos.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve estar em um formato válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O id do endereco é obrigatório")]
        public int EnderecoId { get; set; }

        [RegularExpression(@"^\(?\d{2}\)?[\s-]?[\d]{4,5}-?[\d]{4}$", ErrorMessage = "O telefone deve estar em um formato válido (ex: (99) 99999-9999).")]
        public string Telefone { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Fornecedor
{
    public class CreateFornecedorDto
    {
        [Required(ErrorMessage = "A Razão Social é obrigatória.")]
        [MaxLength(100, ErrorMessage = "A Razão Social não pode exceder 100 caracteres.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O Nome Fantasia é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O Nome Fantasia não pode exceder 150 caracteres.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve conter exatamente 14 dígitos numéricos.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve estar em um formato válido.")]
        public string Email { get; set; }

        //[MaxLength(50, ErrorMessage = "O estado não pode exceder 50 caracteres.")]
        //public string Estado { get; set; }

        //[MaxLength(100, ErrorMessage = "A cidade não pode exceder 100 caracteres.")]
        //public string Cidade { get; set; }

        //[MaxLength(100, ErrorMessage = "O bairro não pode exceder 100 caracteres.")]
        //public string Bairro { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "O número deve ser maior que zero.")]
        //public int Numero { get; set; }

        //[MaxLength(100, ErrorMessage = "O complemento não pode exceder 100 caracteres.")]
        //public string Complemento { get; set; }

        //[RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP deve conter exatamente 8 dígitos numéricos.")]
        //public string Cep { get; set; }



        [RegularExpression(@"^\(?\d{2}\)?[\s-]?[\d]{4,5}-?[\d]{4}$", ErrorMessage = "O telefone deve estar em um formato válido (ex: (99) 99999-9999).")]
        public string TelefoneFornecedor { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FazendaSharpCity_API.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        [Required]
        public int Id { get; set; }

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
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        [RegularExpression(@"^\(?\d{2}\)?[\s-]?[\d]{4,5}-?[\d]{4}$", ErrorMessage = "O telefone deve estar em um formato válido (ex: (99) 99999-9999).")]
        public string TelefoneFornecedor { get; set; }
    }
}

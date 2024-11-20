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
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
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

        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        [RegularExpression(@"^\(?\d{2}\)?[\s-]?[\d]{4,5}-?[\d]{4}$", ErrorMessage = "O telefone deve estar em um formato válido (ex: (99) 99999-9999).")]
        public string TelefoneFornecedor { get; set; }
    }
}

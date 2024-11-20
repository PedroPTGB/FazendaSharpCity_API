    using System;
using System.ComponentModel.DataAnnotations;


namespace FazendaSharpCity_API.Models
{
    public class Funcionario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
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
        public string Endereco { get; set; }
        //public virtual Endereco Endereco { get; set; }
        public decimal Salario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string TelefoneFuncionario { get; set; }
    }
}
    using System;
using System.ComponentModel.DataAnnotations;


namespace FazendaSharpCity_API.Models
{
    public class Funcionario
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 dígitos numéricos.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
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

        [Required(ErrorMessage = "O salário é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O salário deve ser maior que zero.")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "O login é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O login não pode exceder 50 caracteres.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(100, ErrorMessage = "A senha não pode exceder 100 caracteres.")]
        public string Senha { get; set; }

        [RegularExpression(@"^\(?\d{2}\)?[\s-]?[\d]{4,5}-?[\d]{4}$", ErrorMessage = "O telefone deve estar em um formato válido (ex: (99) 99999-9999).")]
        public string TelefoneFuncionario { get; set; }
    }
}
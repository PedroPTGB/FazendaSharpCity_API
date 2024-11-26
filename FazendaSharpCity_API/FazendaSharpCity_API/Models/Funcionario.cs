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

        public string CPF { get; set; }
        
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O id do endereco é obrigatório")]
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public string TelefoneFuncionario { get; set; }
    }
}
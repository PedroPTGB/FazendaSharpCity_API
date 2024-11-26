using FazendaSharpCity_API.Models;
using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Cliente
{
    public class UpdateClienteDto
    {

        [Required(ErrorMessage = "O Nome do cliente é obrigatório")]
        [StringLength(100, ErrorMessage = "O Nome do cliente não pode exceder 100 caracteres")]
        public string Nome { get; set; }

        [RegularExpression(@"^\(?\d{2}\)?[\s-]?[\d]{4,5}-?[\d]{4}$", ErrorMessage = "O telefone deve estar em um formato válido (ex: (99) 99999-9999).")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
        public string Email { get; set; }

        [RegularExpression(@"\d{11}", ErrorMessage = "O CPF deve conter apenas números e possuir 11 caracteres")]
        public string? CPF { get; set; }

        [RegularExpression(@"\d{14}", ErrorMessage = "O CNPJ deve conter apenas números e possuir 14 caracteres")]
        public string? CNPJ { get; set; }

        [Required(ErrorMessage = "O id do endereco é obrigatório")]
        public int EnderecoId { get; set; }
    }
}

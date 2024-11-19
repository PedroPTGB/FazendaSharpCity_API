using FazendaSharpCity_API.Models;
using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Cliente
{
    public class CreateClienteDto
    {
        [Required(ErrorMessage = "O Nome do cliente é obrigatório")]
        [StringLength(100, ErrorMessage = "O Nome do cliente não pode exceder 100 caracteres")]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [RegularExpression(@"\d{11}", ErrorMessage = "O CPF deve conter apenas números e possuir 11 caracteres")]
        public string CPF { get; set; }

        //[Required(ErrorMessage = "O CNPJ é obrigatório")]
        [RegularExpression(@"\d{14}", ErrorMessage = "O CNPJ deve conter apenas números e possuir 14 caracteres")]
        public string? CNPJ { get; set; }

        [Required(ErrorMessage = "O Sexo é obrigatório")]
        [RegularExpression(@"^[M,F,I,m,f,i]", ErrorMessage = "O Sexo deve ser escolhido entre Masculino, feminino ou não binário")]
        public char Sexo { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [DisplayFormat(DataFormatString = "dd/mm/YYYY")]
        public DateTime DataNascimento { get; set; }

        public string Endereco { get; set; }

        public bool TipoPessoa { get; set; }

        public CreateClienteDto()
        {
            if (CPF != null)
                TipoPessoa = true;
            else
                TipoPessoa = false;
        }
    }
}

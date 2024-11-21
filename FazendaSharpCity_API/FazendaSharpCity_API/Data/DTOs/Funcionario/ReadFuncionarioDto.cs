using FazendaSharpCity_API.Data.DTOs.Endereco;
using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Funcionario
{
    public class ReadFuncionarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public decimal Salario { get; set; }
        public string TelefoneFuncionario { get; set; }
        public ReadEnderecoDto Endereco { get; set; }
    }
}

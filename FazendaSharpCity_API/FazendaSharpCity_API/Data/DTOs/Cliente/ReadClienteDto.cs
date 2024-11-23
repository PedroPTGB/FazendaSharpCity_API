using FazendaSharpCity_API.Data.DTOs.Endereco;
using FazendaSharpCity_API.Models;
using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Cliente
{
    public class ReadClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string? CNPJ { get; set; }
        public DateTime DataNascimento { get; set; }
        public ReadEnderecoDto Endereco { get; set; }
        public bool TipoPessoa { get; set; }
        public DateTime DtConsulta { get; set; } = DateTime.Now;
    }
}

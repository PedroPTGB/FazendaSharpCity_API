using FazendaSharpCity_API.Data.DTOs.Endereco;
using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Models
{
    public class ReadFornecedorDto
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string TelefoneFornecedor { get; set; }

        public ReadEnderecoDto Endereco { get; set; }
    }
}

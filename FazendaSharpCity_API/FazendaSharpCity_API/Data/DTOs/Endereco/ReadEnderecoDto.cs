using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Endereco
{
    public class ReadEnderecoDto
    {
        
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
    }
}

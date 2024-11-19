using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Endereco
{
    public class UpdateEnderecoDto
    {
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public int Numero { get; set; }
    }
}

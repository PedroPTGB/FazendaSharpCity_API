using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Models
{
    public class ReadFornecedorDto
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }        
        public string Cnpj { get; set; }        
        public string Email { get; set; }
        public string Estado { get; set; }        
        public string Cidade { get; set; }       
        public string Bairro { get; set; }        
        public int Numero { get; set; }       
        public string Complemento { get; set; }        
        public string Cep { get; set; }
        public string TelefoneFornecedor { get; set; }
    }
}

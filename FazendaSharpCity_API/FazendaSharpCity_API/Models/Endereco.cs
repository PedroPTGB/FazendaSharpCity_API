using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public int Numero { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual Fornecedor? Fornecedor { get; set; }
        public virtual Funcionario? Funcionario { get; set; }



    }

}



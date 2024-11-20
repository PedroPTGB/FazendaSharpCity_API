using FazendaSharpCity_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FazendaSharpCity_API.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string? CNPJ { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento { get; set; }

        public string Endereco { get; set; }

        public bool TipoPessoa { get; set; }
        
        //public virtual Endereco Endereco { get; set; }

        public Cliente()
        {
            if (CPF != null)
                TipoPessoa = true;
            else
                TipoPessoa = false;
        }
    }
}

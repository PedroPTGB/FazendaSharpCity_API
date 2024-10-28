using FazendaSharpCity_API.Models;
using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs
{
    public class ReadClienteDto
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public short Sexo { get; set; }
        public DateTime DtNasc { get; set; }
        public bool TipoPessoa { get; set; }
        Endereco endereco = new Endereco();
        public ReadClienteDto()
        {
            Endereco endereco = new Endereco();
            if (Cpf != "")
                TipoPessoa = true;
            else
                TipoPessoa = false;
        }
        public DateTime DtConsulta { get; set; } = DateTime.Now;
    }
}

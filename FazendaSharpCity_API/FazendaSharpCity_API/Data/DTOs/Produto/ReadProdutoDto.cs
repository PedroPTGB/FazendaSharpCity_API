using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Produto
{
    public class ReadProdutoDto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateOnly Validade { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
    }
}

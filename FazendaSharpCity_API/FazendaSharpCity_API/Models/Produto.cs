using System;
using System.ComponentModel.DataAnnotations;


namespace FazendaSharpCity_API.Models {
    public class Produto
    {
        [Key]
        [Required]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }
        public decimal? Preco { get; set; }
        public string Descricao { get; set; }

    }
}

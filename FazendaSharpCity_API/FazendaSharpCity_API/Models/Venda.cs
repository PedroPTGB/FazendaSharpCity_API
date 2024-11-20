using System;
using System.ComponentModel.DataAnnotations;


namespace FazendaSharpCity_API.Models
{
    public class Venda
    {
        [Key]
        [Required]
        public int IdVenda { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime DtVenda { get; set; }
        public string FormaDePagamento { get; set; }
        public int Quantidade { get; set; }
    }
}

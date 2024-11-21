using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Venda
{
    public class ReadVendaDto
    {
        public int IdVenda { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime DataDaVenda { get; set; }
        public string FormaDePagamento { get; set; }
        public int Quantidade { get; set; }
    }
}

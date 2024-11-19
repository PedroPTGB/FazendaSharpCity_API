using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Venda
{
    public class UpdateVendaDto
    {
        public int IdVenda { get; set; }
        public float PrecoUnitario { get; set; }
        public DateTime DataDaVenda { get; set; }
        public string FormaDePagamento { get; set; }
        public int Quantidade { get; set; }
    }
}

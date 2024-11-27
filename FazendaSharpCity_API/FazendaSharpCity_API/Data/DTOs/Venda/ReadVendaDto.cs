using FazendaSharpCity_API.Data.DTOs.Cliente;
using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Venda
{
    public class ReadVendaDto
    {
        public int IdVenda { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoCompra { get; set; }
        public DateOnly DataDaVenda { get; set; }
        public string FormaDePagamento { get; set; }
        public int Quantidade { get; set; }
        public ReadClienteDto ReadClienteDto { get; set; }
    }
}

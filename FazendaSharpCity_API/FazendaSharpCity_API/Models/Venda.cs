using System;
using System.ComponentModel.DataAnnotations;


namespace FazendaSharpCity_API.Models
{
    public class Venda
    {
        [Key]
        [Required]
        public int IdVenda { get; set; }
        [Required(ErrorMessage = "O preço unitário é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal PrecoUnitario { get; set; }

        [Required(ErrorMessage = "A data da venda é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtVenda { get; set; }

        [Required(ErrorMessage = "A forma de pagamento é obrigatória.")]
        [RegularExpression(@"^(Cartão|Dinheiro|Pix|Boleto)$", ErrorMessage = "A forma de pagamento deve ser Cartão, Dinheiro, Pix ou Boleto.")]
        [MaxLength(20, ErrorMessage = "A forma de pagamento não pode exceder 20 caracteres.")]
        public string FormaDePagamento { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Venda
{
    public class UpdateVendaDto: IValidatableObject
    {
        [Required(ErrorMessage = "O preço de venda é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal PrecoVenda { get; set; }

        [Required(ErrorMessage = "O preço de compra é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal PrecoCompra { get; set; }

        [Required(ErrorMessage = "A data da venda é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateOnly DataDaVenda { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataDaVenda > DateOnly.FromDateTime(DateTime.Today))
            {
                yield return new ValidationResult("Apenas pode ser registrada uma venda realizada, nesta data ou em uma data passada.", new[] { "DataDaVenda" });
            }
        }

        [Required(ErrorMessage = "A forma de pagamento é obrigatória.")]
        [RegularExpression(@"^(Cartão|Dinheiro|Pix|Boleto)$", ErrorMessage = "A forma de pagamento deve ser Cartão, Dinheiro, Pix ou Boleto.")]
        [StringLength(20, ErrorMessage = "A forma de pagamento não pode exceder 20 caracteres.")]
        public string FormaDePagamento { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "É necessario registrar para qual cliente a venda foi realizada")]
        public int ClienteId { get; set; }
    }
}

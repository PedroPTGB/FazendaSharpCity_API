using System;
using System.ComponentModel.DataAnnotations;


namespace FazendaSharpCity_API.Models {
    public class Produto : IValidatableObject
    {
        [Key]
        [Required]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do produto não pode exceder 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "A data de validade é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateOnly Validade { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Validade < DateOnly.FromDateTime(DateTime.Today))
            {
                yield return new ValidationResult("Não pode ser registrado um produto vencido.", new[] { "DataDaVenda" });
            }
        }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }
        
        [MaxLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres.")]
        public string? Descricao { get; set; }

    }
}

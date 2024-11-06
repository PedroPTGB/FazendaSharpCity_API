using System;
using System.ComponentModel.DataAnnotations;

public class Produto
{
    [Key]
    [Required]
    public int idProduto { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome do produto não pode exceder 100 caracteres.")]
    public string? nome { get; set; }

    [Required(ErrorMessage = "A quantidade é obrigatória.")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
    public int qtd { get; set; }

    [Required(ErrorMessage = "A data de validade é obrigatória.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime validade { get; set; }

    [Required(ErrorMessage = "O preço do produto é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal? preco { get; set; }

    [MaxLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres.")]
    public string? descricao { get; set; }

   
}

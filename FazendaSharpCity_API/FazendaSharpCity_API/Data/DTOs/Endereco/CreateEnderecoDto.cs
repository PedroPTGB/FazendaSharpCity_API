using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs.Endereco
{
    public class CreateEnderecoDto
    {
        [Required(ErrorMessage = "O logradouro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O logradouro não pode exceder 100 caracteres.")]
        public string Logradouro { get; set; }

        [StringLength(100, ErrorMessage = "O complemento não pode exceder 100 caracteres.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O bairro não pode exceder 100 caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(50, ErrorMessage = "O estado não pode exceder 50 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(100, ErrorMessage = "A cidade não pode exceder 100 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP deve conter exatamente 8 dígitos numéricos.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O número é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O número deve ser maior que zero.")]
        public int Num { get; set; }
    }
}

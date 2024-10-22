using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O título do filme é obrigatório")]
        [MaxLength(100, ErrorMessage = "O título do filme não pode exceder 100 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo de duração é obrigatório")]
        [Range(1, 360, ErrorMessage = "A duração deve ter no mínimo 1 minuto e no máximo 360")]
        public int Duracao { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
    }
}

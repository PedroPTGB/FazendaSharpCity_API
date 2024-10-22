using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Data.DTOs
{
    public class ReadClienteDto
    {
        public string Titulo { get; set; }

        public int Duracao { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public DateTime DtConsulta { get; set; } = DateTime.Now;
    }
}

namespace FazendaSharpCity_API.Models
{
    public class Endereco
    {
        public string Logradouro { get; set; }

        public string Complemento { get; set; }
        public string Bairro { get; set; }


        public string Estado { get; set; }


        public string Cidade { get; set; }


        public string Cep { get; set; }


        public int Num { get; set; }


        public Endereco(string Logradouro, string Complemento, string Bairro, string Estado, string Cidade, String Cep, int Num)
        {
            this.Logradouro = Logradouro;
            this.Complemento = Complemento;
            this.Bairro = Bairro;
            this.Estado = Estado;
            this.Cidade = Cidade;
            this.Cep = Cep;
            this.Num = Num;
        }
    }
}

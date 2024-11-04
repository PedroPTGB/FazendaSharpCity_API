namespace FazendaSharpCity_API.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro{ get; set; }
        public int Numero{ get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public decimal Salario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string TelefoneFuncionario { get; set; }

    }
}

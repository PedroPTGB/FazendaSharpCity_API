﻿using FazendaSharpCity_API.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O Nome do cliente é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Nome do cliente não pode exceder 100 caracteres")]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        //[MaxLength(11, ErrorMessage = "O CPF do cliente não pode exceder 11 caracteres")]
        //[MinLength(11, ErrorMessage = "O CPF do cliente não pode ser menor que 11 caracteres")]
        [RegularExpression(@"/^[0-9]{11}/", ErrorMessage ="O CPF deve conter apenas números e possuir 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [RegularExpression(@"/^[0-9]{14}/", ErrorMessage = "O CNPJ deve conter apenas números e possuir 14 caracteres")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O Sexo é obrigatório")]
        [RegularExpression(@"/^[1-3]/", ErrorMessage = "O Sexo deve ser escolhido entre Masculino (1), feminino (2) ou não binário(3)")]
        public short Sexo { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DtNasc { get; set; }

        public bool TipoPessoa { get; set; }
        [Required]
        Endereco endereco = new Endereco();

        public Cliente()
        {
            Endereco endereco = new Endereco();
            if (Cpf != "")
                TipoPessoa = true;
            else
                TipoPessoa = false;
        }
    }
}

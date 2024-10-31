﻿using FazendaSharpCity_API.Models;
using System.ComponentModel.DataAnnotations;

namespace FazendaSharpCity_API.Models
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
        [RegularExpression(@"\d{11}", ErrorMessage ="O CPF deve conter apenas números e possuir 11 caracteres")]
        public long Cpf { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [RegularExpression(@"\d{14}", ErrorMessage = "O CNPJ deve conter apenas números e possuir 14 caracteres")]
        public long Cnpj { get; set; }

        [Required(ErrorMessage = "O Sexo é obrigatório")]
        [RegularExpression(@"/^[M,F,I,m,f,i]/", ErrorMessage = "O Sexo deve ser escolhido entre Masculino (M), feminino (F) ou não binário(I)")]
        public char Sexo { get; set; }

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
            if (Cpf != null)
                TipoPessoa = true;
            else
                TipoPessoa = false;
        }
    }
}
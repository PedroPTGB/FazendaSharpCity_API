using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FazendaSharpCity_API.Migrations
{
    /// <inheritdoc />
    public partial class EnderecoECorrecoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Logradouro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Complemento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Num = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RazaoSocial = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NomeFantasia = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Complemento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    TelefoneFornecedor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Complemento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Salario = table.Column<decimal>(type: "numeric", nullable: false),
                    Login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TelefoneFuncionario = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Qtd = table.Column<int>(type: "integer", nullable: false),
                    Validade = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    IdVenda = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrecoUnit = table.Column<float>(type: "real", nullable: false),
                    DtVenda = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FormaPag = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Qtd = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.IdVenda);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    Cnpj = table.Column<long>(type: "bigint", nullable: false),
                    Sexo = table.Column<char>(type: "character(1)", nullable: false),
                    DtNasc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EnderecoId = table.Column<int>(type: "integer", nullable: false),
                    TipoPessoa = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FazendaSharpCity_API.Migrations
{
    /// <inheritdoc />
    public partial class Correcoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoUnit",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "Qtd",
                table: "Vendas",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "FormaPag",
                table: "Vendas",
                newName: "FormaDePagamento");

            migrationBuilder.RenameColumn(
                name: "Qtd",
                table: "Produtos",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Funcionarios",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "Enderecos",
                newName: "CEP");

            migrationBuilder.RenameColumn(
                name: "Num",
                table: "Enderecos",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Clientes",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "Clientes",
                newName: "CNPJ");

            migrationBuilder.RenameColumn(
                name: "DtNasc",
                table: "Clientes",
                newName: "DataNascimento");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnitario",
                table: "Vendas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Produtos",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoUnitario",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Vendas",
                newName: "Qtd");

            migrationBuilder.RenameColumn(
                name: "FormaDePagamento",
                table: "Vendas",
                newName: "FormaPag");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Produtos",
                newName: "Qtd");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Funcionarios",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "Enderecos",
                newName: "Cep");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Enderecos",
                newName: "Num");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Clientes",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "Clientes",
                newName: "Cnpj");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Clientes",
                newName: "DtNasc");

            migrationBuilder.AddColumn<float>(
                name: "PrecoUnit",
                table: "Vendas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Produtos",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Funcionarios",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Funcionarios",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FazendaSharpCity_API.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoGeral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Salario",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitario",
                table: "Vendas",
                newName: "PrecoVenda");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoCompra",
                table: "Vendas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Clientes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoCompra",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "PrecoVenda",
                table: "Vendas",
                newName: "PrecoUnitario");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Funcionarios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salario",
                table: "Funcionarios",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Clientes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

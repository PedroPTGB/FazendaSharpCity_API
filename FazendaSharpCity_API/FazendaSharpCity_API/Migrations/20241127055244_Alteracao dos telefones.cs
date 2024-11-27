using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FazendaSharpCity_API.Migrations
{
    /// <inheritdoc />
    public partial class Alteracaodostelefones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelefoneFuncionario",
                table: "Funcionarios",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "TelefoneFornecedor",
                table: "Fornecedores",
                newName: "Telefone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Funcionarios",
                newName: "TelefoneFuncionario");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Fornecedores",
                newName: "TelefoneFornecedor");
        }
    }
}

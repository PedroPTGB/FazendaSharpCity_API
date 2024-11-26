using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FazendaSharpCity_API.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoGeral1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPessoa",
                table: "Clientes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TipoPessoa",
                table: "Clientes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}

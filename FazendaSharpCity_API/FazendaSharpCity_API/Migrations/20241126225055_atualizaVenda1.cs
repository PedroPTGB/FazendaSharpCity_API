using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FazendaSharpCity_API.Migrations
{
    /// <inheritdoc />
    public partial class atualizaVenda1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DtVenda",
                table: "Vendas",
                newName: "DataDaVenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDaVenda",
                table: "Vendas",
                newName: "DtVenda");
        }
    }
}

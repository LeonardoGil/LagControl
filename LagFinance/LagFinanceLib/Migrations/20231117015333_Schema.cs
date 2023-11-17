using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagFinanceLib.Migrations
{
    /// <inheritdoc />
    public partial class Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "finance");

            migrationBuilder.RenameTable(
                name: "Movimentacao",
                newName: "Movimentacao",
                newSchema: "finance");

            migrationBuilder.RenameTable(
                name: "Conta",
                newName: "Conta",
                newSchema: "finance");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categoria",
                newSchema: "finance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Movimentacao",
                schema: "finance",
                newName: "Movimentacao");

            migrationBuilder.RenameTable(
                name: "Conta",
                schema: "finance",
                newName: "Conta");

            migrationBuilder.RenameTable(
                name: "Categoria",
                schema: "finance",
                newName: "Categoria");
        }
    }
}

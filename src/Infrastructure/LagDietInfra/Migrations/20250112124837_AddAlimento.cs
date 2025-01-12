using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagDietInfra.Migrations
{
    /// <inheritdoc />
    public partial class AddAlimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "diet");

            migrationBuilder.CreateTable(
                name: "Alimento",
                schema: "diet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kcal = table.Column<int>(type: "int", nullable: false),
                    Proteinas = table.Column<double>(type: "float", nullable: false),
                    Carboidratos = table.Column<double>(type: "float", nullable: false),
                    Gorduras = table.Column<double>(type: "float", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimento",
                schema: "diet");
        }
    }
}

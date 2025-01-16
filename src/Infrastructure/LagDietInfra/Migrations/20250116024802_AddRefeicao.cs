using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagDietInfra.Migrations
{
    /// <inheritdoc />
    public partial class AddRefeicao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Porcao",
                schema: "diet",
                table: "Alimento",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "UnidadeMedida",
                schema: "diet",
                table: "Alimento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Refeicao",
                schema: "diet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefeicaoAlimento",
                schema: "diet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlimentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefeicaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Refeicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Porcao = table.Column<double>(type: "float", nullable: false),
                    UnidadeMedida = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicaoAlimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefeicaoAlimento_Alimento_AlimentoId",
                        column: x => x.AlimentoId,
                        principalSchema: "diet",
                        principalTable: "Alimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefeicaoAlimento_Refeicao_RefeicaoId",
                        column: x => x.RefeicaoId,
                        principalSchema: "diet",
                        principalTable: "Refeicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefeicaoAlimento_AlimentoId",
                schema: "diet",
                table: "RefeicaoAlimento",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_RefeicaoAlimento_RefeicaoId",
                schema: "diet",
                table: "RefeicaoAlimento",
                column: "RefeicaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefeicaoAlimento",
                schema: "diet");

            migrationBuilder.DropTable(
                name: "Refeicao",
                schema: "diet");

            migrationBuilder.DropColumn(
                name: "Porcao",
                schema: "diet",
                table: "Alimento");

            migrationBuilder.DropColumn(
                name: "UnidadeMedida",
                schema: "diet",
                table: "Alimento");
        }
    }
}

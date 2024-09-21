using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LagFinanceInfra.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "finance");

            migrationBuilder.CreateTable(
                name: "Categoria",
                schema: "finance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                schema: "finance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacao",
                schema: "finance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoMovimentacao = table.Column<int>(type: "int", nullable: false),
                    Pendente = table.Column<bool>(type: "bit", nullable: false),
                    ContaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContaTransferenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalSchema: "finance",
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Conta_ContaId",
                        column: x => x.ContaId,
                        principalSchema: "finance",
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Conta_ContaTransferenciaId",
                        column: x => x.ContaTransferenciaId,
                        principalSchema: "finance",
                        principalTable: "Conta",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "finance",
                table: "Categoria",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { new Guid("1f7cce04-9ec5-4f43-bfdb-4ed1e478f1d4"), "Mercado" },
                    { new Guid("21bf5615-c004-4a31-99f8-b376afc573bc"), "Contas" },
                    { new Guid("42c74818-8ef2-45b9-9ab6-a7dcd6dcc36f"), "Lazer" },
                    { new Guid("88c747e2-45ad-4067-aab8-ab287ceed954"), "Farmacia" },
                    { new Guid("cf668fda-3d80-47c6-8352-6c04fb28c956"), "Restaurante" }
                });

            migrationBuilder.InsertData(
                schema: "finance",
                table: "Conta",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { new Guid("0ca05b72-4e7d-4afe-8bc9-c0b8cc860073"), "PicPay" },
                    { new Guid("60b44dcc-950e-45b1-bbb2-32c5deb9ec90"), "Banco do Brasil" },
                    { new Guid("64abc81e-dd01-40b8-983a-3dba10cfb7ab"), "Santander" },
                    { new Guid("9ab68e5a-a829-40b9-9d32-b9746d3134f5"), "Bradesco" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_CategoriaId",
                schema: "finance",
                table: "Movimentacao",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_ContaId",
                schema: "finance",
                table: "Movimentacao",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_ContaTransferenciaId",
                schema: "finance",
                table: "Movimentacao",
                column: "ContaTransferenciaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacao",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "Categoria",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "Conta",
                schema: "finance");
        }
    }
}

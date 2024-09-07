using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagFinanceLib.Migrations
{
    /// <inheritdoc />
    public partial class Melhoria_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContaTransferenciaId",
                schema: "finance",
                table: "Movimentacao",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Pendente",
                schema: "finance",
                table: "Movimentacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_ContaTransferenciaId",
                schema: "finance",
                table: "Movimentacao",
                column: "ContaTransferenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacao_Conta_ContaTransferenciaId",
                schema: "finance",
                table: "Movimentacao",
                column: "ContaTransferenciaId",
                principalSchema: "finance",
                principalTable: "Conta",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacao_Conta_ContaTransferenciaId",
                schema: "finance",
                table: "Movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacao_ContaTransferenciaId",
                schema: "finance",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "ContaTransferenciaId",
                schema: "finance",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "Pendente",
                schema: "finance",
                table: "Movimentacao");
        }
    }
}

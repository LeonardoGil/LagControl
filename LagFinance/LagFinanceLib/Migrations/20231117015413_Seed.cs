using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LagFinanceLib.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "finance",
                table: "Conta",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { new Guid("82396197-0500-4da9-ae7c-924530344a35"), "PicPay" },
                    { new Guid("c9977f49-1603-4190-964a-963af2d6ad7c"), "Santander" },
                    { new Guid("db99f530-d4e6-429a-a8b4-097a939d5870"), "Bradesco" },
                    { new Guid("e389e09e-fb13-4f58-846d-4e9d9fa00813"), "Banco do Brasil" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "finance",
                table: "Conta",
                keyColumn: "Id",
                keyValue: new Guid("82396197-0500-4da9-ae7c-924530344a35"));

            migrationBuilder.DeleteData(
                schema: "finance",
                table: "Conta",
                keyColumn: "Id",
                keyValue: new Guid("c9977f49-1603-4190-964a-963af2d6ad7c"));

            migrationBuilder.DeleteData(
                schema: "finance",
                table: "Conta",
                keyColumn: "Id",
                keyValue: new Guid("db99f530-d4e6-429a-a8b4-097a939d5870"));

            migrationBuilder.DeleteData(
                schema: "finance",
                table: "Conta",
                keyColumn: "Id",
                keyValue: new Guid("e389e09e-fb13-4f58-846d-4e9d9fa00813"));
        }
    }
}

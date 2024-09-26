using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagFinanceInfra.Migrations
{
    /// <inheritdoc />
    public partial class TipoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                schema: "finance",
                table: "Categoria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("1f7cce04-9ec5-4f43-bfdb-4ed1e478f1d4"),
                column: "Tipo",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("21bf5615-c004-4a31-99f8-b376afc573bc"),
                column: "Tipo",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("42c74818-8ef2-45b9-9ab6-a7dcd6dcc36f"),
                column: "Tipo",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("7e17e895-1f93-4dd7-8c55-cc1941999e30"),
                column: "Tipo",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("88c747e2-45ad-4067-aab8-ab287ceed954"),
                column: "Tipo",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("8afb4bec-0b6d-479c-bdd6-7ba7880ebb38"),
                column: "Tipo",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("cf668fda-3d80-47c6-8352-6c04fb28c956"),
                column: "Tipo",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                schema: "finance",
                table: "Categoria");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagFinanceInfra.Migrations
{
    /// <inheritdoc />
    public partial class BaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                schema: "finance",
                table: "Movimentacao",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                schema: "finance",
                table: "Movimentacao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                schema: "finance",
                table: "Conta",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                schema: "finance",
                table: "Conta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                schema: "finance",
                table: "Categoria",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                schema: "finance",
                table: "Categoria",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("1f7cce04-9ec5-4f43-bfdb-4ed1e478f1d4"),
                columns: new[] { "DataAtualizacao", "DataCriacao" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("21bf5615-c004-4a31-99f8-b376afc573bc"),
                columns: new[] { "DataAtualizacao", "DataCriacao" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("42c74818-8ef2-45b9-9ab6-a7dcd6dcc36f"),
                columns: new[] { "DataAtualizacao", "DataCriacao" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("7e17e895-1f93-4dd7-8c55-cc1941999e30"),
                columns: new[] { "DataAtualizacao", "DataCriacao" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("88c747e2-45ad-4067-aab8-ab287ceed954"),
                columns: new[] { "DataAtualizacao", "DataCriacao" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("8afb4bec-0b6d-479c-bdd6-7ba7880ebb38"),
                columns: new[] { "DataAtualizacao", "DataCriacao" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("cf668fda-3d80-47c6-8352-6c04fb28c956"),
                columns: new[] { "DataAtualizacao", "DataCriacao" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Conta",
                keyColumn: "Id",
                keyValue: new Guid("0ca05b72-4e7d-4afe-8bc9-c0b8cc860073"),
                columns: new[] { "DataAtualizacao", "DataCriacao" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Conta",
                keyColumn: "Id",
                keyValue: new Guid("60b44dcc-950e-45b1-bbb2-32c5deb9ec90"),
                columns: new[] { "DataAtualizacao", "DataCriacao" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Conta",
                keyColumn: "Id",
                keyValue: new Guid("64abc81e-dd01-40b8-983a-3dba10cfb7ab"),
                columns: new[] { "DataAtualizacao", "DataCriacao" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "finance",
                table: "Conta",
                keyColumn: "Id",
                keyValue: new Guid("9ab68e5a-a829-40b9-9d32-b9746d3134f5"),
                columns: new[] { "DataAtualizacao", "DataCriacao" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                schema: "finance",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                schema: "finance",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                schema: "finance",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                schema: "finance",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                schema: "finance",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                schema: "finance",
                table: "Categoria");
        }
    }
}

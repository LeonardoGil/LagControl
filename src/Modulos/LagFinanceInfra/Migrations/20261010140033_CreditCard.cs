using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagFinanceInfra.Migrations
{
    /// <inheritdoc />
    public partial class CreditCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCard",
                schema: "finance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HolderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClosingDay = table.Column<int>(type: "int", nullable: false),
                    DueDay = table.Column<int>(type: "int", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCard_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "finance",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardInvoice",
                schema: "finance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceMonth = table.Column<int>(type: "int", nullable: false),
                    ReferenceYear = table.Column<int>(type: "int", nullable: false),
                    OpeningDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ClosingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreditCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardInvoice_CreditCard_CreditCardId",
                        column: x => x.CreditCardId,
                        principalSchema: "finance",
                        principalTable: "CreditCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditCardInvoice_Transaction_PaymentId",
                        column: x => x.PaymentId,
                        principalSchema: "finance",
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardTransaction",
                schema: "finance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Pending = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Installments = table.Column<int>(type: "int", nullable: true),
                    InstallmentNumber = table.Column<int>(type: "int", nullable: true),
                    CreditCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardTransaction_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "finance",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditCardTransaction_CreditCardInvoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "finance",
                        principalTable: "CreditCardInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditCardTransaction_CreditCard_CreditCardId",
                        column: x => x.CreditCardId,
                        principalSchema: "finance",
                        principalTable: "CreditCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_AccountId",
                schema: "finance",
                table: "CreditCard",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardInvoice_CreditCardId",
                schema: "finance",
                table: "CreditCardInvoice",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardInvoice_CreditCardId_ReferenceYear_ReferenceMonth",
                schema: "finance",
                table: "CreditCardInvoice",
                columns: new[] { "CreditCardId", "ReferenceYear", "ReferenceMonth" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardInvoice_PaymentId",
                schema: "finance",
                table: "CreditCardInvoice",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardTransaction_CategoryId",
                schema: "finance",
                table: "CreditCardTransaction",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardTransaction_CreditCardId",
                schema: "finance",
                table: "CreditCardTransaction",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardTransaction_InvoiceId",
                schema: "finance",
                table: "CreditCardTransaction",
                column: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCardTransaction",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "CreditCardInvoice",
                schema: "finance");

            migrationBuilder.DropTable(
                name: "CreditCard",
                schema: "finance");
        }
    }
}

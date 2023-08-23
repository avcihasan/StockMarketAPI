using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMarket.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptocurrencyPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CryptocurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptocurrencyPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CryptocurrencyPrices_Cryptocurrencies_CryptocurrencyId",
                        column: x => x.CryptocurrencyId,
                        principalTable: "Cryptocurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 5,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 6,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 7,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 8,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 9,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 10,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 11,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 12,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 13,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 14,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 15,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 16,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 17,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 18,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 19,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 20,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 21,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 22,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 23,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 24,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 25,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.CreateIndex(
                name: "IX_CryptocurrencyPrices_CryptocurrencyId",
                table: "CryptocurrencyPrices",
                column: "CryptocurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptocurrencyPrices");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "UnitPrice",
                value: 21m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnitPrice",
                value: 22m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "UnitPrice",
                value: 23m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "UnitPrice",
                value: 24m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 5,
                column: "UnitPrice",
                value: 25m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 6,
                column: "UnitPrice",
                value: 26m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 7,
                column: "UnitPrice",
                value: 27m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 8,
                column: "UnitPrice",
                value: 28m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 9,
                column: "UnitPrice",
                value: 29m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 10,
                column: "UnitPrice",
                value: 30m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 11,
                column: "UnitPrice",
                value: 31m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 12,
                column: "UnitPrice",
                value: 32m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 13,
                column: "UnitPrice",
                value: 33m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 14,
                column: "UnitPrice",
                value: 34m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 15,
                column: "UnitPrice",
                value: 35m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 16,
                column: "UnitPrice",
                value: 36m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 17,
                column: "UnitPrice",
                value: 37m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 18,
                column: "UnitPrice",
                value: 38m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 19,
                column: "UnitPrice",
                value: 39m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 20,
                column: "UnitPrice",
                value: 40m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 21,
                column: "UnitPrice",
                value: 41m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 22,
                column: "UnitPrice",
                value: 42m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 23,
                column: "UnitPrice",
                value: 43m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 24,
                column: "UnitPrice",
                value: 44m);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 25,
                column: "UnitPrice",
                value: 45m);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMarket.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CryptocurrencyPrices",
                columns: new[] { "Id", "CryptocurrencyId", "Date", "Price" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3348), 100m },
                    { 2, 2, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3386), 100m },
                    { 3, 3, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3388), 100m },
                    { 4, 4, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3390), 100m },
                    { 5, 5, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3391), 100m },
                    { 6, 6, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3397), 100m },
                    { 7, 7, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3399), 100m },
                    { 8, 8, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3400), 100m },
                    { 9, 9, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3402), 100m },
                    { 10, 10, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3406), 100m },
                    { 11, 11, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3407), 100m },
                    { 12, 12, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3409), 100m },
                    { 13, 13, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3410), 100m },
                    { 14, 14, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3412), 100m },
                    { 15, 15, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3414), 100m },
                    { 16, 16, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3415), 100m },
                    { 17, 17, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3417), 100m },
                    { 18, 18, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3420), 100m },
                    { 19, 19, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3422), 100m },
                    { 20, 20, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3423), 100m },
                    { 21, 21, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3425), 100m },
                    { 22, 22, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3427), 100m },
                    { 23, 23, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3428), 100m },
                    { 24, 24, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3430), 100m },
                    { 25, 25, new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3431), 100m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 25);
        }
    }
}

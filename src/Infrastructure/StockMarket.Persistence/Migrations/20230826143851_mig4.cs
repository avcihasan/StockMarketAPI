using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMarket.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Cryptocurrencies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "c1");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "c2");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: "c3");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Code",
                value: "c4");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Code",
                value: "c5");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Code",
                value: "c6");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Code",
                value: "c7");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Code",
                value: "c8");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Code",
                value: "c9");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 10,
                column: "Code",
                value: "c10");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 11,
                column: "Code",
                value: "c11");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 12,
                column: "Code",
                value: "c12");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 13,
                column: "Code",
                value: "c13");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 14,
                column: "Code",
                value: "c14");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 15,
                column: "Code",
                value: "c15");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 16,
                column: "Code",
                value: "c16");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 17,
                column: "Code",
                value: "c17");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 18,
                column: "Code",
                value: "c18");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 19,
                column: "Code",
                value: "c19");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 20,
                column: "Code",
                value: "c20");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 21,
                column: "Code",
                value: "c21");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 22,
                column: "Code",
                value: "c22");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 23,
                column: "Code",
                value: "c23");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 24,
                column: "Code",
                value: "c24");

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 25,
                column: "Code",
                value: "c25");

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4063));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4096));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4098));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4106));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4122));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4124));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4128));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4134));

            migrationBuilder.CreateIndex(
                name: "IX_Cryptocurrencies_Code",
                table: "Cryptocurrencies",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cryptocurrencies_Code",
                table: "Cryptocurrencies");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Cryptocurrencies");

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3348));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3386));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3397));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3399));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3402));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3406));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3407));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3412));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3417));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3422));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3427));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "CryptocurrencyPrices",
                keyColumn: "Id",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2023, 8, 23, 15, 49, 49, 325, DateTimeKind.Local).AddTicks(3431));
        }
    }
}

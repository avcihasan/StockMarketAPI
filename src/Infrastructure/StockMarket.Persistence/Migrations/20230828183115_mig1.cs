using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMarket.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cryptocurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptocurrencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cryptocurrencies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kategori Deneme", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Cryptocurrencies",
                columns: new[] { "Id", "CategoryId", "Code", "CreatedDate", "Name", "Stock", "UnitPrice", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, "c1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-1", 50, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "c2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-2", 100, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, "c3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-3", 150, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, "c4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-4", 200, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, "c5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-5", 250, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, "c6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-6", 300, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, "c7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-7", 350, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, "c8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-8", 400, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, "c9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-9", 450, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, "c10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-10", 500, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, "c11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-11", 550, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, "c12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-12", 600, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, "c13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-13", 650, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, "c14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-14", 700, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 1, "c15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-15", 750, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, "c16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-16", 800, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, "c17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-17", 850, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 1, "c18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-18", 900, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, "c19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-19", 950, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 1, "c20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-20", 1000, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, "c21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-21", 1050, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 1, "c22", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-22", 1100, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 1, "c23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-23", 1150, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 1, "c24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-24", 1200, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 1, "c25", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency-25", 1250, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CryptocurrencyPrices",
                columns: new[] { "Id", "CryptocurrencyId", "Date", "Price" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8110), 100m },
                    { 2, 2, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8176), 100m },
                    { 3, 3, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8179), 100m },
                    { 4, 4, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8182), 100m },
                    { 5, 5, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8184), 100m },
                    { 6, 6, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8210), 100m },
                    { 7, 7, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8212), 100m },
                    { 8, 8, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8215), 100m },
                    { 9, 9, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8217), 100m },
                    { 10, 10, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8223), 100m },
                    { 11, 11, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8226), 100m },
                    { 12, 12, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8228), 100m },
                    { 13, 13, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8231), 100m },
                    { 14, 14, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8233), 100m },
                    { 15, 15, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8236), 100m },
                    { 16, 16, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8238), 100m },
                    { 17, 17, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8240), 100m },
                    { 18, 18, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8466), 100m },
                    { 19, 19, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8469), 100m },
                    { 20, 20, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8472), 100m },
                    { 21, 21, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8474), 100m },
                    { 22, 22, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8477), 100m },
                    { 23, 23, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8479), 100m },
                    { 24, 24, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8482), 100m },
                    { 25, 25, new DateTime(2023, 8, 28, 21, 31, 14, 766, DateTimeKind.Local).AddTicks(8484), 100m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cryptocurrencies_CategoryId",
                table: "Cryptocurrencies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cryptocurrencies_Code",
                table: "Cryptocurrencies",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CryptocurrencyPrices_CryptocurrencyId",
                table: "CryptocurrencyPrices",
                column: "CryptocurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CryptocurrencyPrices");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cryptocurrencies");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockMarket.Persistence.Contexts;

#nullable disable

namespace StockMarket.Persistence.Migrations
{
    [DbContext(typeof(StockMartketDbContext))]
    [Migration("20230826143851_mig4")]
    partial class mig4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StockMarket.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kategori Deneme",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("StockMarket.Domain.Entities.Cryptocurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.ToTable("Cryptocurrencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Code = "c1",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-1",
                            Stock = 50,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Code = "c2",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-2",
                            Stock = 100,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Code = "c3",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-3",
                            Stock = 150,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Code = "c4",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-4",
                            Stock = 200,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Code = "c5",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-5",
                            Stock = 250,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Code = "c6",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-6",
                            Stock = 300,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Code = "c7",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-7",
                            Stock = 350,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            Code = "c8",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-8",
                            Stock = 400,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Code = "c9",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-9",
                            Stock = 450,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            Code = "c10",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-10",
                            Stock = 500,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 1,
                            Code = "c11",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-11",
                            Stock = 550,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 1,
                            Code = "c12",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-12",
                            Stock = 600,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 1,
                            Code = "c13",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-13",
                            Stock = 650,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 1,
                            Code = "c14",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-14",
                            Stock = 700,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 1,
                            Code = "c15",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-15",
                            Stock = 750,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 1,
                            Code = "c16",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-16",
                            Stock = 800,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 1,
                            Code = "c17",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-17",
                            Stock = 850,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 1,
                            Code = "c18",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-18",
                            Stock = 900,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 1,
                            Code = "c19",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-19",
                            Stock = 950,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 1,
                            Code = "c20",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-20",
                            Stock = 1000,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 1,
                            Code = "c21",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-21",
                            Stock = 1050,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 1,
                            Code = "c22",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-22",
                            Stock = 1100,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 1,
                            Code = "c23",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-23",
                            Stock = 1150,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 1,
                            Code = "c24",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-24",
                            Stock = 1200,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 1,
                            Code = "c25",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cryptocurrency-25",
                            Stock = 1250,
                            UnitPrice = 100m,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("StockMarket.Domain.Entities.CryptocurrencyPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CryptocurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CryptocurrencyId");

                    b.ToTable("CryptocurrencyPrices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CryptocurrencyId = 1,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4000),
                            Price = 100m
                        },
                        new
                        {
                            Id = 2,
                            CryptocurrencyId = 2,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4060),
                            Price = 100m
                        },
                        new
                        {
                            Id = 3,
                            CryptocurrencyId = 3,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4063),
                            Price = 100m
                        },
                        new
                        {
                            Id = 4,
                            CryptocurrencyId = 4,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4066),
                            Price = 100m
                        },
                        new
                        {
                            Id = 5,
                            CryptocurrencyId = 5,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4068),
                            Price = 100m
                        },
                        new
                        {
                            Id = 6,
                            CryptocurrencyId = 6,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4091),
                            Price = 100m
                        },
                        new
                        {
                            Id = 7,
                            CryptocurrencyId = 7,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4094),
                            Price = 100m
                        },
                        new
                        {
                            Id = 8,
                            CryptocurrencyId = 8,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4096),
                            Price = 100m
                        },
                        new
                        {
                            Id = 9,
                            CryptocurrencyId = 9,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4098),
                            Price = 100m
                        },
                        new
                        {
                            Id = 10,
                            CryptocurrencyId = 10,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4102),
                            Price = 100m
                        },
                        new
                        {
                            Id = 11,
                            CryptocurrencyId = 11,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4104),
                            Price = 100m
                        },
                        new
                        {
                            Id = 12,
                            CryptocurrencyId = 12,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4106),
                            Price = 100m
                        },
                        new
                        {
                            Id = 13,
                            CryptocurrencyId = 13,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4108),
                            Price = 100m
                        },
                        new
                        {
                            Id = 14,
                            CryptocurrencyId = 14,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4110),
                            Price = 100m
                        },
                        new
                        {
                            Id = 15,
                            CryptocurrencyId = 15,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4112),
                            Price = 100m
                        },
                        new
                        {
                            Id = 16,
                            CryptocurrencyId = 16,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4114),
                            Price = 100m
                        },
                        new
                        {
                            Id = 17,
                            CryptocurrencyId = 17,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4116),
                            Price = 100m
                        },
                        new
                        {
                            Id = 18,
                            CryptocurrencyId = 18,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4120),
                            Price = 100m
                        },
                        new
                        {
                            Id = 19,
                            CryptocurrencyId = 19,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4122),
                            Price = 100m
                        },
                        new
                        {
                            Id = 20,
                            CryptocurrencyId = 20,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4124),
                            Price = 100m
                        },
                        new
                        {
                            Id = 21,
                            CryptocurrencyId = 21,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4126),
                            Price = 100m
                        },
                        new
                        {
                            Id = 22,
                            CryptocurrencyId = 22,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4128),
                            Price = 100m
                        },
                        new
                        {
                            Id = 23,
                            CryptocurrencyId = 23,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4130),
                            Price = 100m
                        },
                        new
                        {
                            Id = 24,
                            CryptocurrencyId = 24,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4132),
                            Price = 100m
                        },
                        new
                        {
                            Id = 25,
                            CryptocurrencyId = 25,
                            Date = new DateTime(2023, 8, 26, 17, 38, 51, 380, DateTimeKind.Local).AddTicks(4134),
                            Price = 100m
                        });
                });

            modelBuilder.Entity("StockMarket.Domain.Entities.Cryptocurrency", b =>
                {
                    b.HasOne("StockMarket.Domain.Entities.Category", "Category")
                        .WithMany("Cryptocurrencies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("StockMarket.Domain.Entities.CryptocurrencyPrice", b =>
                {
                    b.HasOne("StockMarket.Domain.Entities.Cryptocurrency", "Cryptocurrency")
                        .WithMany("CryptocurrencyPrices")
                        .HasForeignKey("CryptocurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cryptocurrency");
                });

            modelBuilder.Entity("StockMarket.Domain.Entities.Category", b =>
                {
                    b.Navigation("Cryptocurrencies");
                });

            modelBuilder.Entity("StockMarket.Domain.Entities.Cryptocurrency", b =>
                {
                    b.Navigation("CryptocurrencyPrices");
                });
#pragma warning restore 612, 618
        }
    }
}

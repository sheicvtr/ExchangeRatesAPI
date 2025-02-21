﻿// <auto-generated />
using System;
using ExchangeRatesAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExchangeRatesAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240726192300_InicioCreate")]
    partial class InicioCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExchangeRatesAPI.Modelos.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("ExchangeRatesAPI.Modelos.ExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaseCurrency")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TargetCurrency")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BaseCurrency");

                    b.HasIndex("TargetCurrency");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("ExchangeRatesAPI.Modelos.ExchangeRate", b =>
                {
                    b.HasOne("ExchangeRatesAPI.Modelos.Currency", "BaseCurrencyNavigation")
                        .WithMany("ExchangeRatesAsBaseCurrency")
                        .HasForeignKey("BaseCurrency")
                        .HasPrincipalKey("Symbol")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExchangeRatesAPI.Modelos.Currency", "TargetCurrencyNavigation")
                        .WithMany("ExchangeRatesAsTargetCurrency")
                        .HasForeignKey("TargetCurrency")
                        .HasPrincipalKey("Symbol")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BaseCurrencyNavigation");

                    b.Navigation("TargetCurrencyNavigation");
                });

            modelBuilder.Entity("ExchangeRatesAPI.Modelos.Currency", b =>
                {
                    b.Navigation("ExchangeRatesAsBaseCurrency");

                    b.Navigation("ExchangeRatesAsTargetCurrency");
                });
#pragma warning restore 612, 618
        }
    }
}

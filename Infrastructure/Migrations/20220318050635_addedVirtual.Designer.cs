﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(BBBankContext))]
    [Migration("20220318050635_addedVirtual")]
    partial class addedVirtual
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<string>("AccountTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CurrentBalance")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            AccountNumber = "0001-1001",
                            AccountStatus = 0,
                            AccountTitle = "Raas Masood",
                            CurrentBalance = 3500m
                        });
                });

            modelBuilder.Entity("Entities.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("TransactionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = "bb1b5fda-d345-45fa-b711-f3ab5370de83",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = 3000m,
                            TransactionDate = new DateTime(2022, 3, 19, 0, 6, 35, 52, DateTimeKind.Local).AddTicks(3786),
                            TransactionType = 0
                        },
                        new
                        {
                            Id = "531515b6-b1dd-406a-95ca-2d00387124f2",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = -500m,
                            TransactionDate = new DateTime(2021, 3, 18, 0, 6, 35, 52, DateTimeKind.Local).AddTicks(3813),
                            TransactionType = 1
                        },
                        new
                        {
                            Id = "eada2808-d48d-4fa1-a783-72bce6be7593",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = 1000m,
                            TransactionDate = new DateTime(2020, 3, 18, 0, 6, 35, 52, DateTimeKind.Local).AddTicks(3817),
                            TransactionType = 0
                        });
                });

            modelBuilder.Entity("Entities.Transaction", b =>
                {
                    b.HasOne("Entities.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Entities.Account", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(BBBankContext))]
    partial class BBBankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            AccountNumber = "0001-1001",
                            AccountStatus = 1,
                            AccountTitle = "Raas Masood",
                            CurrentBalance = 3500m,
                            UserId = "aa45e3c9-261d-41fe-a1b0-5b4dcf79cfd3"
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
                            Id = "6229aee2-1705-4b0a-aa76-63585bd37697",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = 3000m,
                            TransactionDate = new DateTime(2022, 8, 31, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9574),
                            TransactionType = 0
                        },
                        new
                        {
                            Id = "c6944fed-6355-4314-8555-3c2a7987bc8a",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = -500m,
                            TransactionDate = new DateTime(2021, 9, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9595),
                            TransactionType = 1
                        },
                        new
                        {
                            Id = "6eb03692-38f5-4554-9e6d-ee276778b24c",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = 1000m,
                            TransactionDate = new DateTime(2020, 9, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9599),
                            TransactionType = 0
                        },
                        new
                        {
                            Id = "f037a503-a130-41fe-8e08-9d9bcabbbedf",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = 500m,
                            TransactionDate = new DateTime(2022, 6, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9601),
                            TransactionType = 0
                        },
                        new
                        {
                            Id = "9a9d9faa-6332-4ba0-9b32-ee035b327935",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = -200m,
                            TransactionDate = new DateTime(2022, 5, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9604),
                            TransactionType = 1
                        },
                        new
                        {
                            Id = "3696c924-55e4-4f42-af4b-5dafd11fd652",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = 500m,
                            TransactionDate = new DateTime(2022, 4, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9607),
                            TransactionType = 0
                        },
                        new
                        {
                            Id = "0456e45e-9d29-4cbf-8c4a-710c2b1083f6",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = 200m,
                            TransactionDate = new DateTime(2022, 3, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9609),
                            TransactionType = 0
                        },
                        new
                        {
                            Id = "9fa02682-07c2-4701-b408-cbce6f9ff11a",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = -300m,
                            TransactionDate = new DateTime(2022, 2, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9611),
                            TransactionType = 1
                        },
                        new
                        {
                            Id = "8dc25789-1aac-48dd-ba52-aceb5449aeb4",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = -100m,
                            TransactionDate = new DateTime(2022, 1, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9616),
                            TransactionType = 1
                        },
                        new
                        {
                            Id = "8588b0b9-2c8f-489d-b72c-efd0958bdd38",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = 200m,
                            TransactionDate = new DateTime(2021, 12, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9619),
                            TransactionType = 0
                        },
                        new
                        {
                            Id = "7e9e100b-75bf-4c7a-ac87-b1e82c033b3d",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = -500m,
                            TransactionDate = new DateTime(2021, 11, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9621),
                            TransactionType = 1
                        },
                        new
                        {
                            Id = "3a144dcf-e7fe-430a-b8b6-efcbc412872c",
                            AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            TransactionAmount = 900m,
                            TransactionDate = new DateTime(2021, 10, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9624),
                            TransactionType = 0
                        });
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "aa45e3c9-261d-41fe-a1b0-5b4dcf79cfd3",
                            Email = "rassmasood@hotmail.com",
                            FirstName = "Raas",
                            LastName = "Masood",
                            ProfilePicUrl = "https://res.cloudinary.com/demo/image/upload/w_400,h_400,c_crop,g_face,r_max/w_200/lady.jpg"
                        });
                });

            modelBuilder.Entity("Entities.Account", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("Entities.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

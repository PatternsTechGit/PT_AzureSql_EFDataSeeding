using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "ProfilePicUrl" },
                values: new object[] { "aa45e3c9-261d-41fe-a1b0-5b4dcf79cfd3", "rassmasood@hotmail.com", "Raas", "Masood", "https://res.cloudinary.com/demo/image/upload/w_400,h_400,c_crop,g_face,r_max/w_200/lady.jpg" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountStatus", "AccountTitle", "CurrentBalance", "UserId" },
                values: new object[] { "37846734-172e-4149-8cec-6f43d1eb3f60", "0001-1001", 1, "Raas Masood", 3500m, "aa45e3c9-261d-41fe-a1b0-5b4dcf79cfd3" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "TransactionAmount", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { "0456e45e-9d29-4cbf-8c4a-710c2b1083f6", "37846734-172e-4149-8cec-6f43d1eb3f60", 200m, new DateTime(2022, 3, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9609), 0 },
                    { "3696c924-55e4-4f42-af4b-5dafd11fd652", "37846734-172e-4149-8cec-6f43d1eb3f60", 500m, new DateTime(2022, 4, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9607), 0 },
                    { "3a144dcf-e7fe-430a-b8b6-efcbc412872c", "37846734-172e-4149-8cec-6f43d1eb3f60", 900m, new DateTime(2021, 10, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9624), 0 },
                    { "6229aee2-1705-4b0a-aa76-63585bd37697", "37846734-172e-4149-8cec-6f43d1eb3f60", 3000m, new DateTime(2022, 8, 31, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9574), 0 },
                    { "6eb03692-38f5-4554-9e6d-ee276778b24c", "37846734-172e-4149-8cec-6f43d1eb3f60", 1000m, new DateTime(2020, 9, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9599), 0 },
                    { "7e9e100b-75bf-4c7a-ac87-b1e82c033b3d", "37846734-172e-4149-8cec-6f43d1eb3f60", -500m, new DateTime(2021, 11, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9621), 1 },
                    { "8588b0b9-2c8f-489d-b72c-efd0958bdd38", "37846734-172e-4149-8cec-6f43d1eb3f60", 200m, new DateTime(2021, 12, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9619), 0 },
                    { "8dc25789-1aac-48dd-ba52-aceb5449aeb4", "37846734-172e-4149-8cec-6f43d1eb3f60", -100m, new DateTime(2022, 1, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9616), 1 },
                    { "9a9d9faa-6332-4ba0-9b32-ee035b327935", "37846734-172e-4149-8cec-6f43d1eb3f60", -200m, new DateTime(2022, 5, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9604), 1 },
                    { "9fa02682-07c2-4701-b408-cbce6f9ff11a", "37846734-172e-4149-8cec-6f43d1eb3f60", -300m, new DateTime(2022, 2, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9611), 1 },
                    { "c6944fed-6355-4314-8555-3c2a7987bc8a", "37846734-172e-4149-8cec-6f43d1eb3f60", -500m, new DateTime(2021, 9, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9595), 1 },
                    { "f037a503-a130-41fe-8e08-9d9bcabbbedf", "37846734-172e-4149-8cec-6f43d1eb3f60", 500m, new DateTime(2022, 6, 1, 17, 15, 25, 294, DateTimeKind.Utc).AddTicks(9601), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountHolderIdNumber = table.Column<int>(type: "int", maxLength: 13, nullable: false),
                    AccountHolderFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountHolderLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    AccountType = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    AccountStatus = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    AccountBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccount");
        }
    }
}

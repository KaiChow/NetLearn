using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("3dfd2cae-abc4-473b-8ab5-e17adac2bbd9"), 24, "Kevin" },
                    { new Guid("560264fa-7a0d-4c91-a7c0-9e1c7d82dbd0"), 34, "Tommas" },
                    { new Guid("d04c259c-703c-4098-83b2-4b4bf8bfc8e4"), 26, "Alex" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}

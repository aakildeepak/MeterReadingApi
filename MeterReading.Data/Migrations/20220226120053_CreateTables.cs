using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeterReading.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeterReading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadingValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterReading", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterReading_UserAccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserAccount",
                columns: new[] { "Id", "AccountId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 2344, "Tommy", "Test" },
                    { 25, 1246, "Jo", "Test" },
                    { 24, 1245, "Neville", "Test" },
                    { 23, 1244, "Tony", "Test" },
                    { 22, 1243, "Graham", "Test" },
                    { 21, 1242, "Tim", "Test" },
                    { 20, 1241, "Lara", "Test" },
                    { 19, 1240, "Archie", "Test" },
                    { 18, 1239, "Noddy", "Test" },
                    { 17, 1234, "Freya", "Test" },
                    { 16, 4534, "JOSH", "Test" },
                    { 15, 6776, "Laura", "Test" },
                    { 26, 1247, "Jim", "Test" },
                    { 14, 2356, "Craig", "Test" },
                    { 12, 2353, "Tony", "Test" },
                    { 11, 2352, "Greg", "Test" },
                    { 10, 2351, "Gladys", "Test" },
                    { 9, 2350, "Colin", "Test" },
                    { 8, 2349, "Simon", "Test" },
                    { 7, 2348, "Tammy", "Test" },
                    { 6, 2347, "Tara", "Test" },
                    { 5, 2346, "Ollie", "Test" },
                    { 4, 2345, "Jerry", "Test" },
                    { 3, 8766, "Sally", "Test" },
                    { 2, 2233, "Barry", "Test" },
                    { 13, 2355, "Arthur", "Test" },
                    { 27, 1248, "Pam", "Test" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterReading_UserAccountId",
                table: "MeterReading",
                column: "UserAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeterReading");

            migrationBuilder.DropTable(
                name: "UserAccount");
        }
    }
}

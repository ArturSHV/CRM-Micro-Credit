using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Micro_Credit.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SocialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidityPeriod = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    House = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Work = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revenue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalCity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValidationCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationCodes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AdditionalCity", "AdditionalPhone", "AdditionalRegion", "Appartment", "Area", "City", "DayOfBirth", "Education", "Email", "Firstname", "Gender", "House", "LastName", "MaritalStatus", "Middlename", "Mobile", "PassportNumber", "PlaceOfBirth", "Region", "Revenue", "Role", "SocialNumber", "Street", "ValidityPeriod", "Work" },
                values: new object[] { 2, "", "", "", "", "", "", new DateTime(2023, 3, 9, 13, 28, 7, 925, DateTimeKind.Local).AddTicks(2842), "", "mail@mail.ru", "", "", "", "", "", "", "8999", "", "", "", "", "Users", "", "", new DateTime(2023, 3, 9, 13, 28, 7, 925, DateTimeKind.Local).AddTicks(2858), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ValidationCodes");
        }
    }
}

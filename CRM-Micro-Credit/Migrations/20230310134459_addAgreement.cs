using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Micro_Credit.Migrations
{
    /// <inheritdoc />
    public partial class addAgreement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Настоящие условия использования сервиса", "Agreements/Terms" },
                    { 2, "Политика конфиденциальности сервиса", "Agreements/Policy" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DayOfBirth", "ValidityPeriod" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 44, 59, 45, DateTimeKind.Local).AddTicks(2642), new DateTime(2023, 3, 10, 16, 44, 59, 45, DateTimeKind.Local).AddTicks(2652) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DayOfBirth", "ValidityPeriod" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 33, 19, 274, DateTimeKind.Local).AddTicks(9232), new DateTime(2023, 3, 10, 16, 33, 19, 274, DateTimeKind.Local).AddTicks(9245) });
        }
    }
}

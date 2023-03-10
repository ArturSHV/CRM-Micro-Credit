using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Micro_Credit.Migrations
{
    /// <inheritdoc />
    public partial class migr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_Users_UserId",
                table: "Agreements");

            migrationBuilder.DropIndex(
                name: "IX_Agreements_UserId",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Agreements");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DayOfBirth", "ValidityPeriod" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 33, 19, 274, DateTimeKind.Local).AddTicks(9232), new DateTime(2023, 3, 10, 16, 33, 19, 274, DateTimeKind.Local).AddTicks(9245) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Agreements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DayOfBirth", "ValidityPeriod" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 31, 34, 216, DateTimeKind.Local).AddTicks(5591), new DateTime(2023, 3, 10, 16, 31, 34, 216, DateTimeKind.Local).AddTicks(5608) });

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_UserId",
                table: "Agreements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_Users_UserId",
                table: "Agreements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

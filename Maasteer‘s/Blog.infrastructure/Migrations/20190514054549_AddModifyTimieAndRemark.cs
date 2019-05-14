using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.infrastructure.Migrations
{
    public partial class AddModifyTimieAndRemark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastModeify",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Articles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 5, 14, 13, 45, 48, 243, DateTimeKind.Local).AddTicks(3116));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2019, 5, 14, 13, 45, 48, 246, DateTimeKind.Local).AddTicks(4968));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModeify",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 23, 17, 41, 46, 490, DateTimeKind.Local).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2019, 4, 23, 17, 41, 46, 490, DateTimeKind.Local).AddTicks(8532));
        }
    }
}

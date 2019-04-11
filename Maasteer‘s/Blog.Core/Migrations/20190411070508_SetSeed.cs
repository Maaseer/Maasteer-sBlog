using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Core.Migrations
{
    public partial class SetSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Auther", "Context", "Date", "Title" },
                values: new object[] { 1, "admin", "This is my first Article", new DateTime(2019, 4, 11, 15, 5, 8, 5, DateTimeKind.Local).AddTicks(2310), "First Welcome Article" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

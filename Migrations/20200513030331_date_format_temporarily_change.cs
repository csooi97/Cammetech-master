using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace v3x.Migrations
{
    public partial class date_format_temporarily_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Attendance",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Attendance",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}

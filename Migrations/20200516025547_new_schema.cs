using Microsoft.EntityFrameworkCore.Migrations;

namespace v3x.Migrations
{
    public partial class new_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "SalaryModification");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "SalaryModification",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "PaySlip",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobId",
                table: "SalaryModification");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PaySlip");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "SalaryModification",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

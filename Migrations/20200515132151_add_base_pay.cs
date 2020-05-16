using Microsoft.EntityFrameworkCore.Migrations;

namespace v3x.Migrations
{
    public partial class add_base_pay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BasePay",
                table: "Job",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasePay",
                table: "Job");
        }
    }
}

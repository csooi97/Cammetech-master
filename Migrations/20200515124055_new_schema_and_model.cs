using Microsoft.EntityFrameworkCore.Migrations;

namespace v3x.Migrations
{
    public partial class new_schema_and_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "People",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateOfBirth",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "People",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EPF",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeRate = table.Column<double>(nullable: false),
                    EmployerRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    PeopleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "PaySlip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(nullable: true),
                    SalaryModificationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaySlip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryModification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(nullable: true),
                    Bonus = table.Column<double>(nullable: false),
                    TotalRate = table.Column<double>(nullable: false),
                    EPFId = table.Column<int>(nullable: false),
                    SocsoId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryModification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scheme = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socso", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EPF");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "PaySlip");

            migrationBuilder.DropTable(
                name: "SalaryModification");

            migrationBuilder.DropTable(
                name: "Socso");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "People");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

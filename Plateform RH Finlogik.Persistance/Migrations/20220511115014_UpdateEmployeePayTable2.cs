using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class UpdateEmployeePayTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mounth",
                table: "EmployeePay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "EmployeePay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mounth",
                table: "EmployeePay");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "EmployeePay");
        }
    }
}

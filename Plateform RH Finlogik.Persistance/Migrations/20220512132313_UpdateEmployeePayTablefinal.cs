using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class UpdateEmployeePayTablefinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Prime",
                table: "EmployeePay",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Prime",
                table: "EmployeePay",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}

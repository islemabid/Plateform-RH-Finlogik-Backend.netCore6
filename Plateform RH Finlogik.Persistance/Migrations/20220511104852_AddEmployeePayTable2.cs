using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class AddEmployeePayTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePay_Employees_EmployeeId",
                table: "EmployeePay");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePay_EmployeeId",
                table: "EmployeePay");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeePay");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePay_IdEmployee",
                table: "EmployeePay",
                column: "IdEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePay_Employees_IdEmployee",
                table: "EmployeePay",
                column: "IdEmployee",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePay_Employees_IdEmployee",
                table: "EmployeePay");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePay_IdEmployee",
                table: "EmployeePay");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "EmployeePay",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePay_EmployeeId",
                table: "EmployeePay",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePay_Employees_EmployeeId",
                table: "EmployeePay",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

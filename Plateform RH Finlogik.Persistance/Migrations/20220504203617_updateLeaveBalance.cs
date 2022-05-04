using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class updateLeaveBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveBalance_Employees_EmployeeId",
                table: "LeaveBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveBalance_LeaveType_LeaveTypeId",
                table: "LeaveBalance");

            migrationBuilder.DropIndex(
                name: "IX_LeaveBalance_EmployeeId",
                table: "LeaveBalance");

            migrationBuilder.DropIndex(
                name: "IX_LeaveBalance_LeaveTypeId",
                table: "LeaveBalance");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "LeaveBalance");

            migrationBuilder.DropColumn(
                name: "LeaveTypeId",
                table: "LeaveBalance");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalance_IdEmployee",
                table: "LeaveBalance",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalance_IdLeaveType",
                table: "LeaveBalance",
                column: "IdLeaveType");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveBalance_Employees_IdEmployee",
                table: "LeaveBalance",
                column: "IdEmployee",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveBalance_LeaveType_IdLeaveType",
                table: "LeaveBalance",
                column: "IdLeaveType",
                principalTable: "LeaveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveBalance_Employees_IdEmployee",
                table: "LeaveBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveBalance_LeaveType_IdLeaveType",
                table: "LeaveBalance");

            migrationBuilder.DropIndex(
                name: "IX_LeaveBalance_IdEmployee",
                table: "LeaveBalance");

            migrationBuilder.DropIndex(
                name: "IX_LeaveBalance_IdLeaveType",
                table: "LeaveBalance");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "LeaveBalance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeaveTypeId",
                table: "LeaveBalance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalance_EmployeeId",
                table: "LeaveBalance",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalance_LeaveTypeId",
                table: "LeaveBalance",
                column: "LeaveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveBalance_Employees_EmployeeId",
                table: "LeaveBalance",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveBalance_LeaveType_LeaveTypeId",
                table: "LeaveBalance",
                column: "LeaveTypeId",
                principalTable: "LeaveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Sick leave" });

            migrationBuilder.InsertData(
                table: "LeaveType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Paid leave" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

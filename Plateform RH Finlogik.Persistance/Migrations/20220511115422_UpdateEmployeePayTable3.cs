using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class UpdateEmployeePayTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TciketPassGift",
                table: "EmployeePay",
                newName: "TicketPassGift");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketPassGift",
                table: "EmployeePay",
                newName: "TciketPassGift");
        }
    }
}

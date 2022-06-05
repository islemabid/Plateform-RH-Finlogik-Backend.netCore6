using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class updateHolidayTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Holidays",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Holidays",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Holidays",
                newName: "End");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Holidays",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Holidays",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Holidays",
                newName: "EndDate");
        }
    }
}

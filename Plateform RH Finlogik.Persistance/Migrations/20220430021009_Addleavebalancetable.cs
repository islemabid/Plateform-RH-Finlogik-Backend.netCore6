using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class Addleavebalancetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndDatePart",
                table: "TimeOffBalances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndDateQuantity",
                table: "TimeOffBalances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartDatePart",
                table: "TimeOffBalances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartDateQuantity",
                table: "TimeOffBalances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDatePart",
                table: "TimeOffBalances");

            migrationBuilder.DropColumn(
                name: "EndDateQuantity",
                table: "TimeOffBalances");

            migrationBuilder.DropColumn(
                name: "StartDatePart",
                table: "TimeOffBalances");

            migrationBuilder.DropColumn(
                name: "StartDateQuantity",
                table: "TimeOffBalances");
        }
    }
}

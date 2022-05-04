using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class updateTimeOffBalancesFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDatePart",
                table: "TimeOffBalances");

            migrationBuilder.DropColumn(
                name: "StartDatePart",
                table: "TimeOffBalances");

            migrationBuilder.AlterColumn<string>(
                name: "StartDateQuantity",
                table: "TimeOffBalances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EndDateQuantity",
                table: "TimeOffBalances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StartDateQuantity",
                table: "TimeOffBalances",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EndDateQuantity",
                table: "TimeOffBalances",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EndDatePart",
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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class addHistoryContratDateFin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "HistoryContrat",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "HistoryContrat");
        }
    }
}

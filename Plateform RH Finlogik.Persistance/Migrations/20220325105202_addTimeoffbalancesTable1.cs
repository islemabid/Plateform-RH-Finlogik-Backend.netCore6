using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class addTimeoffbalancesTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departement_IdDepartement",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departement",
                table: "Departement");

            migrationBuilder.RenameTable(
                name: "Departement",
                newName: "Departements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departements",
                table: "Departements",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TimeOffBalances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeOffBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeOffBalances_Employees_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeOffBalances_IdEmployee",
                table: "TimeOffBalances",
                column: "IdEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departements_IdDepartement",
                table: "Employees",
                column: "IdDepartement",
                principalTable: "Departements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departements_IdDepartement",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "TimeOffBalances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departements",
                table: "Departements");

            migrationBuilder.RenameTable(
                name: "Departements",
                newName: "Departement");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departement",
                table: "Departement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departement_IdDepartement",
                table: "Employees",
                column: "IdDepartement",
                principalTable: "Departement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

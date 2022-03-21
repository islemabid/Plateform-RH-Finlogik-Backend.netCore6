using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class addHistoryContrat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contrat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoryContrat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContrat = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryContrat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryContrat_Contrat_IdContrat",
                        column: x => x.IdContrat,
                        principalTable: "Contrat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryContrat_Employees_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryContrat_IdContrat",
                table: "HistoryContrat",
                column: "IdContrat");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryContrat_IdEmployee",
                table: "HistoryContrat",
                column: "IdEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryContrat");

            migrationBuilder.DropTable(
                name: "Contrat");
        }
    }
}

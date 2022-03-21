using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class addDepartementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDepartement",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdDepartement",
                table: "Employees",
                column: "IdDepartement");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departement_IdDepartement",
                table: "Employees",
                column: "IdDepartement",
                principalTable: "Departement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departement_IdDepartement",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Departement");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IdDepartement",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IdDepartement",
                table: "Employees");
        }
    }
}

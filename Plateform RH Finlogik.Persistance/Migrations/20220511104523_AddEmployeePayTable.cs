using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class AddEmployeePayTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeePay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FixedSalary = table.Column<long>(type: "bigint", nullable: false),
                    MealTicket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TciketPassGift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePay_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePay_EmployeeId",
                table: "EmployeePay",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePay");
        }
    }
}

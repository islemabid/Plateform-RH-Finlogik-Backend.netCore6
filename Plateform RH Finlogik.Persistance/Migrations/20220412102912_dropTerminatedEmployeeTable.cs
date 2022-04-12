using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    public partial class dropTerminatedEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TermiantedEmployees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TermiantedEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CNSSNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cin = table.Column<long>(type: "bigint", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diplome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoursPerWeek = table.Column<float>(type: "real", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonnelEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonnelPhone = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPhone = table.Column<int>(type: "int", nullable: false),
                    postalCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermiantedEmployees", x => x.Id);
                });
        }
    }
}

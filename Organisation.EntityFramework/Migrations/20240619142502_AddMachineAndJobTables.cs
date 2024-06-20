using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organisation.EntityFramework.Migrations
{
    public partial class AddMachineAndJobTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineName = table.Column<string>(type: "TEXT", nullable: false),
                    MachineNumber = table.Column<int>(type: "INTEGER", maxLength: 8, nullable: false),
                    MachineImage = table.Column<string>(type: "TEXT", nullable: true),
                    ProductionSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    ManufacturingDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}

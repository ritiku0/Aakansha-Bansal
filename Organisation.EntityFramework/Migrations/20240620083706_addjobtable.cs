using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organisation.EntityFramework.Migrations
{
    public partial class addjobtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobName = table.Column<string>(type: "TEXT", nullable: false),
                    JobLength = table.Column<int>(type: "INTEGER", nullable: false),
                    JobStartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JobEndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalProduction = table.Column<int>(type: "INTEGER", nullable: false),
                    MachineNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}

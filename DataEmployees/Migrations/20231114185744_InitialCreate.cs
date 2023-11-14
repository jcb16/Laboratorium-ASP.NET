using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataEmployees.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Pesel = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Stanowisko = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    Hire = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fire = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employee_id);
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "employee_id", "Created", "Department", "Fire", "Hire", "Name", "Pesel", "Stanowisko", "Surname" },
                values: new object[] { 1, new DateTime(2012, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", new DateTime(2015, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam", "11111111111", "CyberSecEngineer", "Kowalski" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}

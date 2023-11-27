using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataEmployees.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.ID);
                });

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
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrganizationID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_employees_organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "organizations",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 101, "Uczelnia", "WSEI" },
                    { 102, "Koło studenckie", "Koło studenckie WSEI" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_OrganizationID",
                table: "employees",
                column: "OrganizationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "organizations");
        }
    }
}

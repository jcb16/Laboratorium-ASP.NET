using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
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
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    contact_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Birth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OrganizationID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.contact_id);
                    table.ForeignKey(
                        name: "FK_contacts_organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "organizations",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "ID", "Description", "Name", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[,]
                {
                    { 101, "Uczelnia", "WSEI", "Kraków", "31-150", "Św. Filipa 17" },
                    { 102, "Koło studenckie", "Koło studenckie WSEI", "Kraków", "31-150", "Św. Filipa 17, pok. 12" }
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "contact_id", "Birth", "Email", "Name", "OrganizationID", "Phone" },
                values: new object[,]
                {
                    { 1, null, "adam@onet.pl", "Adam", 102, "111222333" },
                    { 2, null, "kasia@onet.pl", "Kasia", 101, "444555666" },
                    { 3, null, "ada@onet.pl", "Ada", 102, "777888999" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationID",
                table: "contacts",
                column: "OrganizationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "organizations");
        }
    }
}

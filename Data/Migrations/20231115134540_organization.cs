using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class organization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationID",
                table: "contacts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrganizationEntity",
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
                    table.PrimaryKey("PK_OrganizationEntity", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "OrganizationEntity",
                columns: new[] { "ID", "Description", "Name", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[,]
                {
                    { 101, "Uczelnia", "WSEI", "Kraków", "31-150", "Św. Filipa 17" },
                    { 102, "Koło studenckie", "Koło studenckie WSEI", "Kraków", "31-150", "Św. Filipa 17, pok. 12" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "contact_id",
                keyValue: 1,
                column: "OrganizationID",
                value: 102);

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "contact_id",
                keyValue: 2,
                column: "OrganizationID",
                value: 101);

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "contact_id",
                keyValue: 3,
                column: "OrganizationID",
                value: 102);

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationID",
                table: "contacts",
                column: "OrganizationID");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_OrganizationEntity_OrganizationID",
                table: "contacts",
                column: "OrganizationID",
                principalTable: "OrganizationEntity",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_OrganizationEntity_OrganizationID",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "OrganizationEntity");

            migrationBuilder.DropIndex(
                name: "IX_contacts_OrganizationID",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "OrganizationID",
                table: "contacts");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class PieHabil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactoItems",
                table: "ContactoItems");

            migrationBuilder.RenameTable(
                name: "ContactoItems",
                newName: "Contactos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contactos",
                table: "Contactos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contactos",
                table: "Contactos");

            migrationBuilder.RenameTable(
                name: "Contactos",
                newName: "ContactoItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactoItems",
                table: "ContactoItems",
                column: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class Paises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Provincia",
                table: "Provincias",
                newName: "Provincias");

            migrationBuilder.RenameColumn(
                name: "Pais",
                table: "Paises",
                newName: "Paises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Provincias",
                table: "Provincias",
                newName: "Provincia");

            migrationBuilder.RenameColumn(
                name: "Paises",
                table: "Paises",
                newName: "Pais");
        }
    }
}

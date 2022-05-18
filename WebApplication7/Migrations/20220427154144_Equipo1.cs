using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class Equipo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipos",
                table: "Equipos");

            migrationBuilder.RenameTable(
                name: "Equipos",
                newName: "Equipo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo");

            migrationBuilder.RenameTable(
                name: "Equipo",
                newName: "Equipos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipos",
                table: "Equipos",
                column: "Id");
        }
    }
}

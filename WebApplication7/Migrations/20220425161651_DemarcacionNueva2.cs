using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class DemarcacionNueva2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Jugadores",
                table: "Jugadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Demarcaciones",
                table: "Demarcaciones");

            migrationBuilder.RenameTable(
                name: "Jugadores",
                newName: "Jugador");

            migrationBuilder.RenameTable(
                name: "Demarcaciones",
                newName: "Demarcacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jugador",
                table: "Jugador",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Demarcacion",
                table: "Demarcacion",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Jugador",
                table: "Jugador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Demarcacion",
                table: "Demarcacion");

            migrationBuilder.RenameTable(
                name: "Jugador",
                newName: "Jugadores");

            migrationBuilder.RenameTable(
                name: "Demarcacion",
                newName: "Demarcaciones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jugadores",
                table: "Jugadores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Demarcaciones",
                table: "Demarcaciones",
                column: "Id");
        }
    }
}

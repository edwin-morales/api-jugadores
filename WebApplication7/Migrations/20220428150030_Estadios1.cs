using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class Estadios1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Estadios",
                table: "Estadios");

            migrationBuilder.RenameTable(
                name: "Estadios",
                newName: "Estadio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estadio",
                table: "Estadio",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Estadio",
                table: "Estadio");

            migrationBuilder.RenameTable(
                name: "Estadio",
                newName: "Estadios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estadios",
                table: "Estadios",
                column: "Id");
        }
    }
}

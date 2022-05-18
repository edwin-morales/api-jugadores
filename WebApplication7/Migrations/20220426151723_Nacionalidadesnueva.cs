using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class Nacionalidadesnueva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Nacionalidades",
                table: "Nacionalidades");

            migrationBuilder.RenameTable(
                name: "Nacionalidades",
                newName: "Nacionalidad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nacionalidad",
                table: "Nacionalidad",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Nacionalidad",
                table: "Nacionalidad");

            migrationBuilder.RenameTable(
                name: "Nacionalidad",
                newName: "Nacionalidades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nacionalidades",
                table: "Nacionalidades",
                column: "Id");
        }
    }
}

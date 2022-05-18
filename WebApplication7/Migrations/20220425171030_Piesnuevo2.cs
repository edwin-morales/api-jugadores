using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class Piesnuevo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pies",
                table: "Pies");

            migrationBuilder.RenameTable(
                name: "Pies",
                newName: "Pie");

            migrationBuilder.RenameColumn(
                name: "Pies",
                table: "Pie",
                newName: "Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pie",
                table: "Pie",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pie",
                table: "Pie");

            migrationBuilder.RenameTable(
                name: "Pie",
                newName: "Pies");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Pies",
                newName: "Pies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pies",
                table: "Pies",
                column: "Id");
        }
    }
}

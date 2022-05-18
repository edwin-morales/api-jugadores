using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class ActualizacionPais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Paises",
                table: "Paises");

            migrationBuilder.RenameTable(
                name: "Paises",
                newName: "Pais");

            migrationBuilder.RenameColumn(
                name: "Paises",
                table: "Pais",
                newName: "Nombre");

            migrationBuilder.AlterColumn<string>(
                name: "Abreviatura",
                table: "Pais",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Pais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Poblacion",
                table: "Pais",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pais",
                table: "Pais",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pais",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "Poblacion",
                table: "Pais");

            migrationBuilder.RenameTable(
                name: "Pais",
                newName: "Paises");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Paises",
                newName: "Paises");

            migrationBuilder.AlterColumn<string>(
                name: "Abreviatura",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paises",
                table: "Paises",
                column: "Id");
        }
    }
}

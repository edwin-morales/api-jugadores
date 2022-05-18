using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class Representante1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Representantes",
                table: "Representantes");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Nacionalidad");

            migrationBuilder.RenameTable(
                name: "Representantes",
                newName: "Representante");

            migrationBuilder.AlterColumn<string>(
                name: "Situacion",
                table: "Nacionalidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "Representante",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Representante",
                table: "Representante",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Representante",
                table: "Representante");

            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "Representante");

            migrationBuilder.RenameTable(
                name: "Representante",
                newName: "Representantes");

            migrationBuilder.AlterColumn<string>(
                name: "Situacion",
                table: "Nacionalidad",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Nacionalidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Representantes",
                table: "Representantes",
                column: "Id");
        }
    }
}

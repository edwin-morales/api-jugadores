using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class MigracionJugadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreFutbolistico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LugarDeNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincia = table.Column<int>(type: "int", nullable: false),
                    Pais = table.Column<int>(type: "int", nullable: false),
                    Pie = table.Column<int>(type: "int", nullable: false),
                    Demarcacion = table.Column<int>(type: "int", nullable: false),
                    Situacion = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Cantera = table.Column<int>(type: "int", nullable: false),
                    Internacional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Representante = table.Column<int>(type: "int", nullable: false),
                    PaisNacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Retirado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugadores");
        }
    }
}

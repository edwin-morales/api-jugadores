using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class Equipos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreOficial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincia = table.Column<int>(type: "int", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionInternet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peñas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtrasSecciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaFundacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estadio = table.Column<int>(type: "int", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipos");
        }
    }
}

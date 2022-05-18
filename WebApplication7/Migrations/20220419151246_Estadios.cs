using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class Estadios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estadios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inauguracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Propietario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimensiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtrasInstalaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estadios");
        }
    }
}

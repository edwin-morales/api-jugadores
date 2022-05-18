using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class VIDEOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Provincias",
                table: "Provincias");

            migrationBuilder.RenameTable(
                name: "Provincias",
                newName: "Provincia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provincia",
                table: "Provincia",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuthorVideo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorVideo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorVideo");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provincia",
                table: "Provincia");

            migrationBuilder.RenameTable(
                name: "Provincia",
                newName: "Provincias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provincias",
                table: "Provincias",
                column: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CarApp.Migrations
{
    public partial class CarrApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rok = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Silnik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paliwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skrzynia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}

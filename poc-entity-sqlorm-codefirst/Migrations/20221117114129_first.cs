using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace poc_voya_entity.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "crypto",
                columns: table => new
                {
                    cryptoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    cryptoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priceUSD = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crypto", x => x.cryptoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crypto");
        }
    }
}

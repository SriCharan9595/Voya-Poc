using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace poc_voya_entity.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cryptoDescription",
                table: "crypto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cryptoDescription",
                table: "crypto");
        }
    }
}

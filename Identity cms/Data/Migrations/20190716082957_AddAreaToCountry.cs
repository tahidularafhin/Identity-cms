using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity_cms.Data.Migrations
{
    public partial class AddAreaToCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "Countries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Countries");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuroTrip2.Migrations
{
    public partial class addIOTA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IOTA",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IOTA",
                table: "Places");
        }
    }
}

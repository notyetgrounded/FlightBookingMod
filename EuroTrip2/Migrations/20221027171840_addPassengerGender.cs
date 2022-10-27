using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuroTrip2.Migrations
{
    public partial class addPassengerGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "PassengerGender",
                table: "Bookings",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengerGender",
                table: "Bookings");
        }
    }
}

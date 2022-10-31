using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuroTrip2.Migrations
{
    public partial class pendingMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passenger_PassengerId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passenger",
                table: "Passenger");

            migrationBuilder.RenameTable(
                name: "Passenger",
                newName: "Passengers");

            migrationBuilder.RenameColumn(
                name: "PassengerGender",
                table: "Passengers",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "PassengerAge",
                table: "Passengers",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "PassagerName",
                table: "Passengers",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "Passenger");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Passenger",
                newName: "PassagerName");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Passenger",
                newName: "PassengerGender");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Passenger",
                newName: "PassengerAge");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passenger",
                table: "Passenger",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passenger_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuroTrip2.Migrations
{
    public partial class PassengerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassagerName",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PassengerGender",
                table: "Tickets",
                newName: "Passenger_Id");

            migrationBuilder.RenameColumn(
                name: "PassengerAge",
                table: "Tickets",
                newName: "PassengerId");

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassagerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerAge = table.Column<int>(type: "int", nullable: false),
                    PassengerGender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passenger_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passenger_PassengerId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Passenger_Id",
                table: "Tickets",
                newName: "PassengerGender");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "Tickets",
                newName: "PassengerAge");

            migrationBuilder.AddColumn<string>(
                name: "PassagerName",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuroTrip2.Migrations
{
    public partial class addedTicketsAndSeatStatusinContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatStatus_Seats_Seat_Id",
                table: "SeatStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatStatus_Trips_Trip_Id",
                table: "SeatStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Bookings_Booking_Id",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Seats_Seat_Id",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeatStatus",
                table: "SeatStatus");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "SeatStatus",
                newName: "SeatStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Seat_Id",
                table: "Tickets",
                newName: "IX_Tickets_Seat_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Booking_Id",
                table: "Tickets",
                newName: "IX_Tickets_Booking_Id");

            migrationBuilder.RenameIndex(
                name: "IX_SeatStatus_Trip_Id",
                table: "SeatStatuses",
                newName: "IX_SeatStatuses_Trip_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeatStatuses",
                table: "SeatStatuses",
                columns: new[] { "Seat_Id", "Trip_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_SeatStatuses_Seats_Seat_Id",
                table: "SeatStatuses",
                column: "Seat_Id",
                principalTable: "Seats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatStatuses_Trips_Trip_Id",
                table: "SeatStatuses",
                column: "Trip_Id",
                principalTable: "Trips",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Bookings_Booking_Id",
                table: "Tickets",
                column: "Booking_Id",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_Seat_Id",
                table: "Tickets",
                column: "Seat_Id",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatStatuses_Seats_Seat_Id",
                table: "SeatStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatStatuses_Trips_Trip_Id",
                table: "SeatStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Bookings_Booking_Id",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_Seat_Id",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeatStatuses",
                table: "SeatStatuses");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "SeatStatuses",
                newName: "SeatStatus");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Seat_Id",
                table: "Ticket",
                newName: "IX_Ticket_Seat_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Booking_Id",
                table: "Ticket",
                newName: "IX_Ticket_Booking_Id");

            migrationBuilder.RenameIndex(
                name: "IX_SeatStatuses_Trip_Id",
                table: "SeatStatus",
                newName: "IX_SeatStatus_Trip_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeatStatus",
                table: "SeatStatus",
                columns: new[] { "Seat_Id", "Trip_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_SeatStatus_Seats_Seat_Id",
                table: "SeatStatus",
                column: "Seat_Id",
                principalTable: "Seats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatStatus_Trips_Trip_Id",
                table: "SeatStatus",
                column: "Trip_Id",
                principalTable: "Trips",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Bookings_Booking_Id",
                table: "Ticket",
                column: "Booking_Id",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Seats_Seat_Id",
                table: "Ticket",
                column: "Seat_Id",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

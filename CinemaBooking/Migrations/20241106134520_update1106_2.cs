using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    public partial class update1106_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showtime_Room",
                table: "Showtime");

            migrationBuilder.DropForeignKey(
                name: "FK__ticket_fi__room___440B1D61",
                table: "TicketMovieAssignments");

            migrationBuilder.DropIndex(
                name: "IX_TicketMovieAssignments_RoomId",
                table: "TicketMovieAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Showtime_RoomId",
                table: "Showtime");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "TicketMovieAssignments");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Showtime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "TicketMovieAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Showtime",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketMovieAssignments_RoomId",
                table: "TicketMovieAssignments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Showtime_RoomId",
                table: "Showtime",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtime_Room",
                table: "Showtime",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK__ticket_fi__room___440B1D61",
                table: "TicketMovieAssignments",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId");
        }
    }
}

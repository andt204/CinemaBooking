using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    public partial class update1024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ticket_fi__event__44FF419A",
                table: "TicketMovieAssignments");

            migrationBuilder.DropIndex(
                name: "IX_TicketMovieAssignments_ShowtimeMovieId",
                table: "TicketMovieAssignments");

            migrationBuilder.DropColumn(
                name: "ShowtimeMovieId",
                table: "TicketMovieAssignments");

            migrationBuilder.AddColumn<int>(
                name: "ShowtimeId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Showtime",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ShowtimeId",
                table: "Ticket",
                column: "ShowtimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Showtime",
                table: "Ticket",
                column: "ShowtimeId",
                principalTable: "Showtime",
                principalColumn: "ShowtimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Showtime",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_ShowtimeId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ShowtimeId",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "ShowtimeMovieId",
                table: "TicketMovieAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Showtime",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMovieAssignments_ShowtimeMovieId",
                table: "TicketMovieAssignments",
                column: "ShowtimeMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK__ticket_fi__event__44FF419A",
                table: "TicketMovieAssignments",
                column: "ShowtimeMovieId",
                principalTable: "ShowtimeMovieAssignments",
                principalColumn: "ShowtimeMovieId");
        }
    }
}

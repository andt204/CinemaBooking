using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    public partial class update1026_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ticket__seat_id__3E52440B",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_SeatId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Ticket");

            migrationBuilder.CreateTable(
                name: "TicketSeatAssignments",
                columns: table => new
                {
                    TicketSeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    SeatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSeatAssignments", x => x.TicketSeatId);
                    table.ForeignKey(
                        name: "FK_TicketSeatAssignments_Seat",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "SeatId");
                    table.ForeignKey(
                        name: "FK_TicketSeatAssignments_Ticket",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "TicketId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketSeatAssignments_SeatId",
                table: "TicketSeatAssignments",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSeatAssignments_TicketId",
                table: "TicketSeatAssignments",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketSeatAssignments");

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SeatId",
                table: "Ticket",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK__ticket__seat_id__3E52440B",
                table: "Ticket",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "SeatId");
        }
    }
}

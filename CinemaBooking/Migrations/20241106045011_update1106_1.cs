using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    public partial class update1106_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TheaterId",
                table: "Room",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Ticket",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "TicketId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_TheaterId",
                table: "Room",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_TicketId",
                table: "Payment",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Theater",
                table: "Room",
                column: "TheaterId",
                principalTable: "Theater",
                principalColumn: "TheaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Theater",
                table: "Room");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Room_TheaterId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "TheaterId",
                table: "Room");
        }
    }
}

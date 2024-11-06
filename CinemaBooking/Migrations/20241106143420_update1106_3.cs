using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    public partial class update1106_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showtime_Theater",
                table: "Showtime");

            migrationBuilder.DropIndex(
                name: "IX_Showtime_TheaterId",
                table: "Showtime");

            migrationBuilder.DropColumn(
                name: "TheaterId",
                table: "Showtime");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Showtime",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Account",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showtime_Room",
                table: "Showtime");

            migrationBuilder.DropIndex(
                name: "IX_Showtime_RoomId",
                table: "Showtime");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Showtime");

            migrationBuilder.AddColumn<int>(
                name: "TheaterId",
                table: "Showtime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Account",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Showtime_TheaterId",
                table: "Showtime",
                column: "TheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtime_Theater",
                table: "Showtime",
                column: "TheaterId",
                principalTable: "Theater",
                principalColumn: "TheaterId");
        }
    }
}

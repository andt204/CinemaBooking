using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    public partial class update1020_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TheaterId",
                table: "Showtime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Theater",
                columns: table => new
                {
                    TheaterId = table.Column<int>(type: "int", nullable: false),
                    TheaterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theater", x => x.TheaterId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showtime_Theater",
                table: "Showtime");

            migrationBuilder.DropTable(
                name: "Theater");

            migrationBuilder.DropIndex(
                name: "IX_Showtime_TheaterId",
                table: "Showtime");

            migrationBuilder.DropColumn(
                name: "TheaterId",
                table: "Showtime");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    public partial class update1107 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TheaterId",
                table: "Theater",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Theater",
                type: "tinyint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Theater");

            migrationBuilder.AlterColumn<int>(
                name: "TheaterId",
                table: "Theater",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    public partial class update_moviecategory_04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__ticket_f__0ABAC5AB0860D343",
                table: "TicketMovieAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__event_fi__173260FA7EF6F97D",
                table: "ShowtimeMovieAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "MovieCategoryId",
                table: "MovieCategoryAssignments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__TicketMo__B0219649CD2155D3",
                table: "TicketMovieAssignments",
                column: "TicketMovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Showtime__F66869A03E122DE4",
                table: "ShowtimeMovieAssignments",
                column: "ShowtimeMovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__TicketMo__B0219649CD2155D3",
                table: "TicketMovieAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Showtime__F66869A03E122DE4",
                table: "ShowtimeMovieAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "MovieCategoryId",
                table: "MovieCategoryAssignments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ticket_f__0ABAC5AB0860D343",
                table: "TicketMovieAssignments",
                column: "TicketMovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__event_fi__173260FA7EF6F97D",
                table: "ShowtimeMovieAssignments",
                column: "ShowtimeMovieId");
        }
    }
}

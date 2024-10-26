using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    public partial class update1026 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__comment__account__48CFD27E",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK__comment__movie_i__47DBAE45",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK__ticket__price_id__3F466844",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketPrice");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_PriceId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SeatType");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RoomType");

            migrationBuilder.AddColumn<decimal>(
                name: "TicketPrice",
                table: "Ticket",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Showtime",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "SeatPrice",
                table: "SeatType",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Row",
                table: "Seat",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfColumn",
                table: "RoomType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRow",
                table: "RoomType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeat",
                table: "RoomType",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "Comment",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Account",
                table: "Comment",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Movie",
                table: "Comment",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Account",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Movie",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SeatPrice",
                table: "SeatType");

            migrationBuilder.DropColumn(
                name: "NumberOfColumn",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "NumberOfRow",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "NumberOfSeat",
                table: "RoomType");

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
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

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "SeatType",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<int>(
                name: "Row",
                table: "Seat",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "RoomType",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Comment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TicketPrice",
                columns: table => new
                {
                    TicketPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPrice", x => x.TicketPriceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PriceId",
                table: "Ticket",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK__comment__account__48CFD27E",
                table: "Comment",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK__comment__movie_i__47DBAE45",
                table: "Comment",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK__ticket__price_id__3F466844",
                table: "Ticket",
                column: "PriceId",
                principalTable: "TicketPrice",
                principalColumn: "TicketPriceId");
        }
    }
}

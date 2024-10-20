using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    public partial class update1020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCategoryAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MovieAct__EEA9AABEAA76A3E9",
                table: "ActorMovieAssignments");

            migrationBuilder.AddColumn<int>(
                name: "ActorMovieId",
                table: "ActorMovieAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__MovieAct__EEA9AABEAA76A3E9",
                table: "ActorMovieAssignments",
                column: "ActorMovieId");

            migrationBuilder.CreateTable(
                name: "MovieCategoryAssignments",
                columns: table => new
                {
                    MovieCategoryId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategoryAssignments", x => x.MovieCategoryId);
                    table.ForeignKey(
                        name: "FK_MovieCategoryAssignments_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_MovieCategoryAssignments_Movie",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovieAssignments_MovieId",
                table: "ActorMovieAssignments",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategoryAssignments_CategoryId",
                table: "MovieCategoryAssignments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategoryAssignments_MovieId",
                table: "MovieCategoryAssignments",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCategoryAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MovieAct__EEA9AABEAA76A3E9",
                table: "ActorMovieAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ActorMovieAssignments_MovieId",
                table: "ActorMovieAssignments");

            migrationBuilder.DropColumn(
                name: "ActorMovieId",
                table: "ActorMovieAssignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MovieAct__EEA9AABEAA76A3E9",
                table: "ActorMovieAssignments",
                columns: new[] { "MovieId", "ActorId" });

            migrationBuilder.CreateTable(
                name: "MovieCategoryAssignment",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategoryAssignment", x => new { x.MovieId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_MovieCategoryAssignment_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_MovieCategoryAssignment_Movie",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategoryAssignment_CategoryId",
                table: "MovieCategoryAssignment",
                column: "CategoryId");
        }
    }
}

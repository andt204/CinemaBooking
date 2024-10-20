﻿// <auto-generated />
using System;
using CinemaBooking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaBooking.Migrations
{
    [DbContext(typeof(CinemaBookingContext))]
    [Migration("20241020043555_update1020")]
    partial class update1020
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CinemaBooking.Data.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "FullName" }, "UQ__account__F3DBC57261217132")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActorId"), 1L, 1);

                    b.Property<string>("ActorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ActorId");

                    b.ToTable("Actor", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.ActorMovieAssignment", b =>
                {
                    b.Property<int>("ActorMovieId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("ActorMovieId")
                        .HasName("PK__MovieAct__EEA9AABEAA76A3E9");

                    b.HasIndex("ActorId");

                    b.HasIndex("MovieId");

                    b.ToTable("ActorMovieAssignments");
                });

            modelBuilder.Entity("CinemaBooking.Data.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<byte>("CommentType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("CommentId");

                    b.HasIndex("AccountId");

                    b.HasIndex("MovieId");

                    b.HasIndex("PostId");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.Director", b =>
                {
                    b.Property<int>("DirectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DirectorId"), 1L, 1);

                    b.Property<string>("DirectorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DirectorId");

                    b.ToTable("Director", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<int>("AgeLimit")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ImageBackground")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("datetime");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VideoTrailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarningText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movie", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.MovieCategoryAssignment", b =>
                {
                    b.Property<int>("MovieCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("MovieCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCategoryAssignments");
                });

            modelBuilder.Entity("CinemaBooking.Data.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PostId");

                    b.HasIndex("AccountId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"), 1L, 1);

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("RoomId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.RoomType", b =>
                {
                    b.Property<int>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomTypeId"), 1L, 1);

                    b.Property<string>("RoomTypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("RoomTypeId");

                    b.ToTable("RoomType", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"), 1L, 1);

                    b.Property<int>("Column")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<int>("SeatTypeId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("SeatId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SeatTypeId");

                    b.ToTable("Seat", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.SeatType", b =>
                {
                    b.Property<int>("SeatTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatTypeId"), 1L, 1);

                    b.Property<string>("SeatTypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("SeatTypeId");

                    b.ToTable("SeatType", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.Showtime", b =>
                {
                    b.Property<int>("ShowtimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShowtimeId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("StartHour")
                        .HasColumnType("time");

                    b.HasKey("ShowtimeId");

                    b.ToTable("Showtime", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.ShowtimeMovieAssignment", b =>
                {
                    b.Property<int>("ShowtimeMovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShowtimeMovieId"), 1L, 1);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ShowtimeId")
                        .HasColumnType("int");

                    b.HasKey("ShowtimeMovieId")
                        .HasName("PK__event_fi__173260FA7EF6F97D");

                    b.HasIndex("MovieId");

                    b.HasIndex("ShowtimeId");

                    b.ToTable("ShowtimeMovieAssignments");
                });

            modelBuilder.Entity("CinemaBooking.Data.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("datetime");

                    b.Property<int>("PriceId")
                        .HasColumnType("int");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("TicketId");

                    b.HasIndex("AccountId");

                    b.HasIndex("PriceId");

                    b.HasIndex("SeatId");

                    b.ToTable("Ticket", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.TicketMovieAssignment", b =>
                {
                    b.Property<int>("TicketMovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketMovieId"), 1L, 1);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("ShowtimeMovieId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("TicketMovieId")
                        .HasName("PK__ticket_f__0ABAC5AB0860D343");

                    b.HasIndex("MovieId");

                    b.HasIndex("RoomId");

                    b.HasIndex("ShowtimeMovieId");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketMovieAssignments");
                });

            modelBuilder.Entity("CinemaBooking.Data.TicketPrice", b =>
                {
                    b.Property<int>("TicketPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketPriceId"), 1L, 1);

                    b.Property<decimal>("TicketPrice1")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("TicketPrice");

                    b.HasKey("TicketPriceId");

                    b.ToTable("TicketPrice", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.Vote", b =>
                {
                    b.Property<int>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoteId"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("VoteDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("VoteId");

                    b.HasIndex("AccountId");

                    b.HasIndex("MovieId");

                    b.ToTable("Vote", (string)null);
                });

            modelBuilder.Entity("CinemaBooking.Data.Account", b =>
                {
                    b.HasOne("CinemaBooking.Data.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__account__role_id__300424B4");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CinemaBooking.Data.ActorMovieAssignment", b =>
                {
                    b.HasOne("CinemaBooking.Data.Actor", "Actor")
                        .WithMany("ActorMovieAssignments")
                        .HasForeignKey("ActorId")
                        .IsRequired()
                        .HasConstraintName("FK__MovieActo__Actor__6C190EBB");

                    b.HasOne("CinemaBooking.Data.Movie", "Movie")
                        .WithMany("ActorMovieAssignments")
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK__MovieActo__Movie__6B24EA82");

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("CinemaBooking.Data.Comment", b =>
                {
                    b.HasOne("CinemaBooking.Data.Account", "Account")
                        .WithMany("Comments")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK__comment__account__48CFD27E");

                    b.HasOne("CinemaBooking.Data.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK__comment__movie_i__47DBAE45");

                    b.HasOne("CinemaBooking.Data.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_Comment_Post");

                    b.Navigation("Account");

                    b.Navigation("Movie");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("CinemaBooking.Data.Movie", b =>
                {
                    b.HasOne("CinemaBooking.Data.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .IsRequired()
                        .HasConstraintName("FK_Movie_Director");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("CinemaBooking.Data.MovieCategoryAssignment", b =>
                {
                    b.HasOne("CinemaBooking.Data.Category", "Category")
                        .WithMany("MovieCategoryAssignments")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_MovieCategoryAssignments_Category");

                    b.HasOne("CinemaBooking.Data.Movie", "Movie")
                        .WithMany("MovieCategoryAssignments")
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK_MovieCategoryAssignments_Movie");

                    b.Navigation("Category");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("CinemaBooking.Data.Post", b =>
                {
                    b.HasOne("CinemaBooking.Data.Account", "Account")
                        .WithMany("Posts")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Post_Account");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("CinemaBooking.Data.Room", b =>
                {
                    b.HasOne("CinemaBooking.Data.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__room__room_type___2C3393D0");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("CinemaBooking.Data.Seat", b =>
                {
                    b.HasOne("CinemaBooking.Data.Room", "Room")
                        .WithMany("Seats")
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("FK__seat__room_id__398D8EEE");

                    b.HasOne("CinemaBooking.Data.SeatType", "SeatType")
                        .WithMany("Seats")
                        .HasForeignKey("SeatTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__seat__seat_type___38996AB5");

                    b.Navigation("Room");

                    b.Navigation("SeatType");
                });

            modelBuilder.Entity("CinemaBooking.Data.ShowtimeMovieAssignment", b =>
                {
                    b.HasOne("CinemaBooking.Data.Movie", "Movie")
                        .WithMany("ShowtimeMovieAssignments")
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK__event_fil__movie__35BCFE0A");

                    b.HasOne("CinemaBooking.Data.Showtime", "Showtime")
                        .WithMany("ShowtimeMovieAssignments")
                        .HasForeignKey("ShowtimeId")
                        .IsRequired()
                        .HasConstraintName("FK__event_fil__event__34C8D9D1");

                    b.Navigation("Movie");

                    b.Navigation("Showtime");
                });

            modelBuilder.Entity("CinemaBooking.Data.Ticket", b =>
                {
                    b.HasOne("CinemaBooking.Data.Account", "Account")
                        .WithMany("Tickets")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Ticket_Account");

                    b.HasOne("CinemaBooking.Data.TicketPrice", "Price")
                        .WithMany("Tickets")
                        .HasForeignKey("PriceId")
                        .IsRequired()
                        .HasConstraintName("FK__ticket__price_id__3F466844");

                    b.HasOne("CinemaBooking.Data.Seat", "Seat")
                        .WithMany("Tickets")
                        .HasForeignKey("SeatId")
                        .IsRequired()
                        .HasConstraintName("FK__ticket__seat_id__3E52440B");

                    b.Navigation("Account");

                    b.Navigation("Price");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("CinemaBooking.Data.TicketMovieAssignment", b =>
                {
                    b.HasOne("CinemaBooking.Data.Movie", "Movie")
                        .WithMany("TicketMovieAssignments")
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK__ticket_fi__movie__4316F928");

                    b.HasOne("CinemaBooking.Data.Room", "Room")
                        .WithMany("TicketMovieAssignments")
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("FK__ticket_fi__room___440B1D61");

                    b.HasOne("CinemaBooking.Data.ShowtimeMovieAssignment", "ShowtimeMovie")
                        .WithMany("TicketMovieAssignments")
                        .HasForeignKey("ShowtimeMovieId")
                        .IsRequired()
                        .HasConstraintName("FK__ticket_fi__event__44FF419A");

                    b.HasOne("CinemaBooking.Data.Ticket", "Ticket")
                        .WithMany("TicketMovieAssignments")
                        .HasForeignKey("TicketId")
                        .IsRequired()
                        .HasConstraintName("FK__ticket_fi__ticke__4222D4EF");

                    b.Navigation("Movie");

                    b.Navigation("Room");

                    b.Navigation("ShowtimeMovie");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("CinemaBooking.Data.Vote", b =>
                {
                    b.HasOne("CinemaBooking.Data.Account", "Account")
                        .WithMany("Votes")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Vote_Account");

                    b.HasOne("CinemaBooking.Data.Movie", "Movie")
                        .WithMany("Votes")
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK_Vote_Movie");

                    b.Navigation("Account");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("CinemaBooking.Data.Account", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");

                    b.Navigation("Tickets");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("CinemaBooking.Data.Actor", b =>
                {
                    b.Navigation("ActorMovieAssignments");
                });

            modelBuilder.Entity("CinemaBooking.Data.Category", b =>
                {
                    b.Navigation("MovieCategoryAssignments");
                });

            modelBuilder.Entity("CinemaBooking.Data.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("CinemaBooking.Data.Movie", b =>
                {
                    b.Navigation("ActorMovieAssignments");

                    b.Navigation("Comments");

                    b.Navigation("MovieCategoryAssignments");

                    b.Navigation("ShowtimeMovieAssignments");

                    b.Navigation("TicketMovieAssignments");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("CinemaBooking.Data.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("CinemaBooking.Data.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("CinemaBooking.Data.Room", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("TicketMovieAssignments");
                });

            modelBuilder.Entity("CinemaBooking.Data.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("CinemaBooking.Data.Seat", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("CinemaBooking.Data.SeatType", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("CinemaBooking.Data.Showtime", b =>
                {
                    b.Navigation("ShowtimeMovieAssignments");
                });

            modelBuilder.Entity("CinemaBooking.Data.ShowtimeMovieAssignment", b =>
                {
                    b.Navigation("TicketMovieAssignments");
                });

            modelBuilder.Entity("CinemaBooking.Data.Ticket", b =>
                {
                    b.Navigation("TicketMovieAssignments");
                });

            modelBuilder.Entity("CinemaBooking.Data.TicketPrice", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CinemaBooking.Models
{
    public partial class CinemaBookingContext : DbContext
    {
        public CinemaBookingContext()
        {
        }

        public CinemaBookingContext(DbContextOptions<CinemaBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;
        public virtual DbSet<Seat> Seats { get; set; } = null!;
        public virtual DbSet<SeatType> SeatTypes { get; set; } = null!;
        public virtual DbSet<Showtime> Showtimes { get; set; } = null!;
        public virtual DbSet<ShowtimeMovieAssignment> ShowtimeMovieAssignments { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<TicketMovieAssignment> TicketMovieAssignments { get; set; } = null!;
        public virtual DbSet<TicketPrice> TicketPrices { get; set; } = null!;
        public virtual DbSet<Vote> Votes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-8CQ6BQH\\SQLEXPRESS;database=CinemaBooking;uid=sa;pwd=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.RoleId, "IX_Account_RoleId");

                entity.HasIndex(e => e.FullName, "UQ__account__F3DBC57261217132")
                    .IsUnique();

                entity.Property(e => e.Avatar).HasMaxLength(255);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__account__role_id__300424B4");
            });

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");

                entity.Property(e => e.ActorName).HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.HasIndex(e => e.AccountId, "IX_Comment_AccountId");

                entity.HasIndex(e => e.MovieId, "IX_Comment_MovieId");

                entity.HasIndex(e => e.PostId, "IX_Comment_PostId");

                entity.Property(e => e.CommentType).HasDefaultValueSql("(CONVERT([tinyint],(0)))");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.000')");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comment__account__48CFD27E");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__comment__movie_i__47DBAE45");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Comment_Post");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("Director");

                entity.Property(e => e.DirectorName).HasMaxLength(100);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.HasIndex(e => e.DirectorId, "IX_Movie_DirectorId");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.ImageBackground).HasMaxLength(255);

                entity.Property(e => e.PublishTime).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.VideoTrailer).HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Director");

                entity.HasMany(d => d.Actors)
                    .WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "ActorMovieAssignment",
                        l => l.HasOne<Actor>().WithMany().HasForeignKey("ActorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__MovieActo__Actor__6C190EBB"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__MovieActo__Movie__6B24EA82"),
                        j =>
                        {
                            j.HasKey("MovieId", "ActorId").HasName("PK__MovieAct__EEA9AABEAA76A3E9");

                            j.ToTable("ActorMovieAssignments");

                            j.HasIndex(new[] { "ActorId" }, "IX_ActorMovieAssignments_ActorId");
                        });

                entity.HasMany(d => d.Categories)
                    .WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieCategoryAssignment",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieCategoryAssignment_Category"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieCategoryAssignment_Movie"),
                        j =>
                        {
                            j.HasKey("MovieId", "CategoryId");

                            j.ToTable("MovieCategoryAssignment");

                            j.HasIndex(new[] { "CategoryId" }, "IX_MovieCategoryAssignment_CategoryId");
                        });
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.HasIndex(e => e.AccountId, "IX_Post_AccountId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Account");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName).HasMaxLength(100);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.HasIndex(e => e.RoomTypeId, "IX_Room_RoomTypeId");

                entity.Property(e => e.RoomName).HasMaxLength(100);

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__room__room_type___2C3393D0");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("RoomType");

                entity.Property(e => e.RoomTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("Seat");

                entity.HasIndex(e => e.RoomId, "IX_Seat_RoomId");

                entity.HasIndex(e => e.SeatTypeId, "IX_Seat_SeatTypeId");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__seat__room_id__398D8EEE");

                entity.HasOne(d => d.SeatType)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.SeatTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__seat__seat_type___38996AB5");
            });

            modelBuilder.Entity<SeatType>(entity =>
            {
                entity.ToTable("SeatType");

                entity.Property(e => e.SeatTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Showtime>(entity =>
            {
                entity.ToTable("Showtime");

                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<ShowtimeMovieAssignment>(entity =>
            {
                entity.HasKey(e => e.ShowtimeMovieId)
                    .HasName("PK__event_fi__173260FA7EF6F97D");

                entity.HasIndex(e => e.MovieId, "IX_ShowtimeMovieAssignments_MovieId");

                entity.HasIndex(e => e.ShowtimeId, "IX_ShowtimeMovieAssignments_ShowtimeId");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.ShowtimeMovieAssignments)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__event_fil__movie__35BCFE0A");

                entity.HasOne(d => d.Showtime)
                    .WithMany(p => p.ShowtimeMovieAssignments)
                    .HasForeignKey(d => d.ShowtimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__event_fil__event__34C8D9D1");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.HasIndex(e => e.AccountId, "IX_Ticket_AccountId");

                entity.HasIndex(e => e.PriceId, "IX_Ticket_PriceId");

                entity.HasIndex(e => e.SeatId, "IX_Ticket_SeatId");

                entity.Property(e => e.BookingTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.000')");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Account");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticket__price_id__3F466844");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticket__seat_id__3E52440B");
            });

            modelBuilder.Entity<TicketMovieAssignment>(entity =>
            {
                entity.HasKey(e => e.TicketMovieId)
                    .HasName("PK__ticket_f__0ABAC5AB0860D343");

                entity.HasIndex(e => e.MovieId, "IX_TicketMovieAssignments_MovieId");

                entity.HasIndex(e => e.RoomId, "IX_TicketMovieAssignments_RoomId");

                entity.HasIndex(e => e.ShowtimeMovieId, "IX_TicketMovieAssignments_ShowtimeMovieId");

                entity.HasIndex(e => e.TicketId, "IX_TicketMovieAssignments_TicketId");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.TicketMovieAssignments)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticket_fi__movie__4316F928");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.TicketMovieAssignments)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticket_fi__room___440B1D61");

                entity.HasOne(d => d.ShowtimeMovie)
                    .WithMany(p => p.TicketMovieAssignments)
                    .HasForeignKey(d => d.ShowtimeMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticket_fi__event__44FF419A");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TicketMovieAssignments)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ticket_fi__ticke__4222D4EF");
            });

            modelBuilder.Entity<TicketPrice>(entity =>
            {
                entity.ToTable("TicketPrice");

                entity.Property(e => e.TicketPrice1)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("TicketPrice");
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.ToTable("Vote");

                entity.HasIndex(e => e.AccountId, "IX_Vote_AccountId");

                entity.HasIndex(e => e.MovieId, "IX_Vote_MovieId");

                entity.Property(e => e.VoteDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vote_Account");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vote_Movie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

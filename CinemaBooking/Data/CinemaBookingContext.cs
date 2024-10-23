using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CinemaBooking.Data
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
        public virtual DbSet<ActorMovieAssignment> ActorMovieAssignments { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MovieCategoryAssignment> MovieCategoryAssignments { get; set; } = null!;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectStr = config.GetConnectionString("CinemaBooking");
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(connectStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.Email, "UQ__account__F3DBC57261217132")
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

            modelBuilder.Entity<ActorMovieAssignment>(entity =>
            {
                entity.HasKey(e => e.ActorMovieId)
                    .HasName("PK__MovieAct__EEA9AABEAA76A3E9");

                entity.Property(e => e.ActorMovieId).ValueGeneratedNever();

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorMovieAssignments)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovieActo__Actor__6C190EBB");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.ActorMovieAssignments)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MovieActo__Movie__6B24EA82");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

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

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.ImageBackground).HasMaxLength(255);

                entity.Property(e => e.PublishTime).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Director");
            });

            modelBuilder.Entity<MovieCategoryAssignment>(entity =>
            {
                entity.HasKey(e => e.MovieCategoryId);

                entity.Property(e => e.MovieCategoryId).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.MovieCategoryAssignments)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCategoryAssignments_Category");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieCategoryAssignments)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCategoryAssignments_Movie");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

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

                entity.Property(e => e.BookingTime).HasColumnType("datetime");

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

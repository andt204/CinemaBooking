using CinemaBooking.Data;
using CinemaBooking.Repositories;
using CinemaBooking.Repositories.Movie;
using CinemaBooking.Repositories.Role;
using CinemaBooking.Repositories.Room;
using CinemaBooking.Repositories.Seat;
using CinemaBooking.Repositories.Showtime;
using CinemaBooking.Repositories.Ticket;
using CinemaBooking.Repositories.TicketMovie;
using CinemaBooking.Repositories.TicketPrice;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
          
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<ISeatRepository, SeatRepository>();
            builder.Services.AddScoped<ITicketPriceRepository, TicketPriceRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IShowtimeRepository, ShowtimeRepository>();
            builder.Services.AddScoped<ITicketMovieRepository, TicketMovieRepository>();
            
            builder.Services.AddDbContext<CinemaBookingContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CinemaBooking")));
            
            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
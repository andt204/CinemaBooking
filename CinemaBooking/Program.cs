using CinemaBooking.Data;
using CinemaBooking.Repositories;
using CinemaBooking.Repositories.Role;
using CinemaBooking.Services; // Add this line for service namespace
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			// Register your repositories
			builder.Services.AddScoped<IAccountRepository, AccountRepository>();
			builder.Services.AddScoped<IRoleRepository, RoleRepository>();

			// Register your service
			builder.Services.AddScoped<CinemaSelectionService>(); // Register CinemaSelectionService

			// Configure DbContext with SQL Server
			builder.Services.AddDbContext<CinemaBookingContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("CinemaBooking")));

			// Add services to the container
			builder.Services.AddRazorPages();

			var app = builder.Build();

			// Configure the HTTP request pipeline
			if (!app.Environment.IsDevelopment()) {
				app.UseExceptionHandler("/Error");
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
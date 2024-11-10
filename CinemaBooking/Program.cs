using CinemaBooking.AutoMapper;
using CinemaBooking.Helper;
using CinemaBooking.Repositories;
using CinemaBooking.Repositories.Comment;
using CinemaBooking.Repositories.Role;
using CinemaBooking.Repositories.Vote;
using CinemaBooking.Services; // Add this line for service namespace
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CinemaBooking.Repositories.Movie;
using CinemaBooking.Repositories.Room;
using CinemaBooking.Repositories.Seat;
using CinemaBooking.Repositories.Showtime;
using CinemaBooking.Repositories.Theater;
using CinemaBooking.Repositories.Ticket;
using CinemaBooking.Repositories.TicketMovie;
using CinemaBooking.Repositories.TicketSeat;
using CinemaBooking.Data;
using CinemaBooking.EmailModels;

namespace CinemaBooking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IVoteRepository, VoteRepository>();

            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddRazorPages();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession();


            builder.Services.AddDbContext<CinemaBookingContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CinemaBooking")));

            // Add JWT Authentication services
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            // Trỏ đến trang 404 nếu chưa xác thực
                            context.HandleResponse();
                            context.Response.Redirect("/Customer/Account/Login");
                            return Task.CompletedTask;
                        },
                        OnForbidden = context =>
                        {
                            // Trỏ đến trang 403 nếu không đủ quyền
                            context.Response.Redirect("/Customer/Account/Login");
                            return Task.CompletedTask;
                        }
                    };
                });

            // Register your repositories
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IVoteRepository, VoteRepository>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<ISeatRepository, SeatRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IShowtimeRepository, ShowtimeRepository>();
            builder.Services.AddScoped<ITicketMovieRepository, TicketMovieRepository>();
            builder.Services.AddScoped<ITheaterRepository, TheaterRepository>();
            builder.Services.AddScoped<ITicketSeatRepository, TicketSeatRepository>();
            // Register your service
            builder.Services.AddScoped<CinemaSelectionService>(); // Register CinemaSelectionService
            builder.Services.AddScoped<SeatSelectionService>();
            builder.Services.AddScoped<TheaterService>();
            builder.Services.AddScoped<RoomService>();
            builder.Services.AddScoped<RoomTypeService>();
            builder.Services.AddScoped<SeatService>();
            builder.Services.AddScoped<SeatTypeService>();
            //builder.Services.AddSingleton<IVnPayService, VnPayService>();
            builder.Services.AddScoped<IVnPayService, VnPayService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("SMTPConfig"));
            builder.Services.AddHostedService<PendingTicketMonitorService>();

            builder.Services.AddScoped<MovieInteractionService>();
            builder.Services.AddScoped<BlogService>();
            // Configure DbContext with SQL Server
            builder.Services.AddDbContext<CinemaBookingContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CinemaBooking")));

            // Add services to the container
            builder.Services.AddRazorPages();
            // Add auto mapper
            builder.Services.AddAutoMapper(typeof(MovieProfile));
            builder.Services.AddAutoMapper(typeof(TheaterProfile));
            builder.Services.AddAutoMapper(typeof(ShowtimeProfile));
            builder.Services.AddAutoMapper(typeof(RoomProfile));

            builder.Services.AddAutoMapper(typeof(SeatProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseRouting();
            // Thêm middleware tùy chỉnh để thêm JWT token từ cookie vào header
            app.UseMiddleware<JwtTokenMiddleware>();
            app.UseAuthentication();
            _ = app.UseAuthorization();

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); //Routes for pages
                endpoints.MapControllers(); //Routes for my API controllers
            });


            app.Use(async (context, next) =>
            {
                var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                logger.LogInformation("Request Headers:");
                foreach (var header in context.Request.Headers)
                {
                    logger.LogInformation($"{header.Key}: {header.Value}");
                }

                await next();
            });


            app.MapRazorPages();
            app.Run();
        }
    }
}
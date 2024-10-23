﻿using CinemaBooking.Data;
using CinemaBooking.Helper;
using CinemaBooking.Repositories;
using CinemaBooking.Repositories.Role;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CinemaBooking {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<IAccountRepository, AccountRepository>();

            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddRazorPages();
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
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            // Trỏ đến trang 404 nếu chưa xác thực
                            context.HandleResponse();
                            context.Response.Redirect("/404");
                            return Task.CompletedTask;
                        },
                        OnForbidden = context =>
                        {
                            // Trỏ đến trang 403 nếu không đủ quyền
                            context.Response.Redirect("/403");
                            return Task.CompletedTask;
                        }
                    };
                });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseRouting();

            // Thêm middleware tùy chỉnh để thêm JWT token từ cookie vào header
            app.UseMiddleware<JwtTokenMiddleware>();
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseStaticFiles();

            app.MapRazorPages();
            app.Run();
        }
    }
}
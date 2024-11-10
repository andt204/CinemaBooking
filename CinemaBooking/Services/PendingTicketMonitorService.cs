using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CinemaBooking.Data;
using CinemaBooking.Enum;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Services
{
    public class PendingTicketMonitorService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public PendingTicketMonitorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await MonitorPendingTicketsAsync();
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken); // Adjust interval as needed
            }
        }

        private async Task MonitorPendingTicketsAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CinemaBookingContext>();

            var thresholdTime = DateTime.Now.AddMinutes(-20);

            // Fetch tickets pending for more than 20 minutes
            var expiredTickets = await context.Tickets
                .Where(t => t.Status == (byte)TicketStatus.Pending && t.BookingTime <= thresholdTime)
                .Include(t => t.TicketSeatAssignments)
                .ToListAsync();

            foreach (var ticket in expiredTickets)
            {
                ticket.Status = (byte)TicketStatus.Cancelled;

                // Update each assigned seat to Available
                foreach (var seatAssignment in ticket.TicketSeatAssignments)
                {
                    var seat = await context.Seats.FindAsync(seatAssignment.SeatId);
                    if (seat != null)
                    {
                        seat.Status = (byte)SeatStatus.Available;
                    }
                }
            }

            await context.SaveChangesAsync();
        }
    }
}

using CinemaBooking.Data;
using CinemaBooking.ViewModels;
using Microsoft.EntityFrameworkCore;

public class AdminTicketService
{
    private readonly CinemaBookingContext _context;

    public AdminTicketService(CinemaBookingContext context)
    {
        _context = context;
    }

    public async Task<List<AdminTicketDto>> GetAllTicketsAsync(
    string movieName = "",
    string status = "",
    DateTime? fromDate = null,
    DateTime? toDate = null)
    {
        var query = from t in _context.Tickets
                    join s in _context.Showtimes on t.ShowtimeId equals s.ShowtimeId
                    join m in _context.Movies on s.MovieId equals m.MovieId
                    join a in _context.Accounts on t.AccountId equals a.AccountId
                    join r in _context.Rooms on s.RoomId equals r.RoomId
                    join tsa in _context.TicketSeatAssignments on t.TicketId equals tsa.TicketId
                    join seat in _context.Seats on tsa.SeatId equals seat.SeatId
                    group new { seat.Row, seat.Column } by new
                    {
                        t.TicketId,
                        m.Title,
                        a.FullName,
                        t.TicketPrice,
                        t.Status,
                        t.BookingTime,
                        s.Date,
                        s.StartHour,
                        r.RoomName
                    } into ticketGroup
                    select new AdminTicketDto
                    {
                        TicketId = ticketGroup.Key.TicketId,
                        MovieName = ticketGroup.Key.Title,
                        CustomerName = ticketGroup.Key.FullName,
                        SeatInfo = ticketGroup.Select(seat => seat.Row + seat.Column.ToString()).ToList(),
                        TicketPrice = ticketGroup.Key.TicketPrice,
                        Status = ticketGroup.Key.Status == 1 ? "Active" :
                                 ticketGroup.Key.Status == 2 ? "Cancelled" :
                                 ticketGroup.Key.Status == 3 ? "Used" : "Pending",
                        BookingTime = ticketGroup.Key.BookingTime,
                        ShowDate = ticketGroup.Key.Date,
                        ShowTime = ticketGroup.Key.StartHour,
                        RoomName = ticketGroup.Key.RoomName
                    };

        if (!string.IsNullOrEmpty(movieName))
        {
            query = query.Where(t => t.MovieName.Contains(movieName));
        }

        if (!string.IsNullOrEmpty(status))
        {
            query = query.Where(t => t.Status == status);
        }

        if (fromDate.HasValue)
        {
            query = query.Where(t => t.BookingTime.Date >= fromDate.Value.Date);
        }

        if (toDate.HasValue)
        {
            query = query.Where(t => t.BookingTime.Date <= toDate.Value.Date);
        }

        return await query
            .OrderByDescending(t => t.BookingTime)
            .ToListAsync();
    }


    public async Task<List<string>> GetAllStatusesAsync()
    {
        return new List<string> { "Active", "Used", "Cancelled", "Pending"};
    }

    public async Task<List<string>> GetAllMovieNamesAsync()
    {
        return await _context.Movies
            .Where(m => m.Status == 1)
            .Select(m => m.Title)
            .ToListAsync();
    }
}
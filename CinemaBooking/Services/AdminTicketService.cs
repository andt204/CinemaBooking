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
                    select new AdminTicketDto
                    {
                        TicketId = t.TicketId,
                        MovieName = m.Title,
                        CustomerName = a.FullName,
                        SeatInfo = seat.Row + seat.Column.ToString(),
                        TicketPrice = t.TicketPrice,
                        Status = t.Status == 1 ? "Active" :
                                t.Status == 2 ? "Used" :
                                t.Status == 0 ? "Cancelled" : "Unknown",
                        BookingTime = t.BookingTime,
                        ShowDate = s.Date,
                        ShowTime = s.StartHour,
                        RoomName = r.RoomName
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
        return new List<string> { "Active", "Used", "Cancelled" };
    }

    public async Task<List<string>> GetAllMovieNamesAsync()
    {
        return await _context.Movies
            .Where(m => m.Status == 1)
            .Select(m => m.Title)
            .ToListAsync();
    }
}
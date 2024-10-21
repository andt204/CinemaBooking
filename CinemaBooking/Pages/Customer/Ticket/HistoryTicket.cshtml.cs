using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBooking.Pages.Customer.Ticket
{
    public class HistoryTicketModel : PageModel
    {
        private readonly CinemaBookingContext _context;

        public HistoryTicketModel(CinemaBookingContext context)
        {
            _context = context;
        }

        public List<TicketHistoryViewModel> TicketHistories { get; set; }

        public async Task<IActionResult> OnGetAsync(int idAccount)
        {
            TicketHistories = await _context.Tickets
    .Where(t => t.AccountId == idAccount)
    .Include(t => t.Seat)
    .ThenInclude(s => s.Room)
    .ThenInclude(r => r.RoomType)
    .Include(t => t.TicketMovieAssignments)
    .ThenInclude(tma => tma.Movie)
    .Include(t => t.Price)
    .Select(t => new TicketHistoryViewModel
    {
        TicketId = t.TicketId,
        MovieTitle = t.TicketMovieAssignments.FirstOrDefault().Movie.Title,
        Seat = t.Seat.Row.ToString() + t.Seat.Column.ToString(),
        RoomName = t.Seat.Room.RoomName,
        Showtime = t.TicketMovieAssignments.FirstOrDefault().ShowtimeMovie.Showtime.StartHour.ToString(),
        Date = t.TicketMovieAssignments.FirstOrDefault().ShowtimeMovie.Showtime.Date.ToString(),
        TicketPrice = t.Price.TicketPrice1, 
        Status = t.Status.ToString()
    })
    .ToListAsync();


            return Page();
        }

        public class TicketHistoryViewModel
        {
            public int TicketId { get; set; }
            public string MovieTitle { get; set; }
            public string Seat { get; set; }
            public string RoomName { get; set; }
            public string Showtime { get; set; }
            public string Date { get; set; }
            public decimal TicketPrice { get; set; }
            public string Status { get; set; }
        }
    }
}

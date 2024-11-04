using CinemaBooking.Data;
using CinemaBooking.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace CinemaBooking.Pages.Customer.Ticket
{
    public class HistoryTicketModel : PageModel
    {
        private readonly CinemaBookingContext _context;
        public Data.Account account { get; set; }

        public HistoryTicketModel(CinemaBookingContext context)
        {
            _context = context;
        }

        public List<TicketHistoryViewModel> TicketHistories { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            int idAccount = 0;
            var token = Request.Cookies["jwtToken"];
            if (token != null)
            {
                var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
                if (email != null)
                {
                    account = _context.Accounts.FirstOrDefault(x => x.AccountId == Int32.Parse(email));
                    idAccount = account.AccountId;
                    ViewData["Account"] = account; // Pass account data to ViewData
                }
            }

            var ticketDetails = await _context.Tickets
                .Where(t => t.AccountId == idAccount)
                .Join(
                    _context.TicketSeatAssignments,
                    t => t.TicketId,
                    tsa => tsa.TicketId,
                    (t, tsa) => new { Ticket = t, TicketSeatAssignment = tsa }
                )
                .Join(
                    _context.Seats,
                    combined => combined.TicketSeatAssignment.SeatId,
                    s => s.SeatId,
                    (combined, s) => new { combined.Ticket, combined.TicketSeatAssignment, Seat = s }
                )
                .Join(
                    _context.Rooms,
                    combined => combined.Seat.RoomId,
                    r => r.RoomId,
                    (combined, r) => new { combined.Ticket, combined.TicketSeatAssignment, combined.Seat, Room = r }
                )
                .Join(
                    _context.RoomTypes,
                    combined => combined.Room.RoomTypeId,
                    rt => rt.RoomTypeId,
                    (combined, rt) => new
                        { combined.Ticket, combined.TicketSeatAssignment, combined.Seat, combined.Room, RoomType = rt }
                )
                // .Join(
                //     _context.TicketMovieAssignments,
                //     combined => combined.Ticket.TicketId,
                //     tms => tms.TicketId,
                //     (combined, tms) => new
                //     {
                //         combined.Ticket, combined.TicketSeatAssignment, combined.Seat, combined.Room, combined.RoomType,
                //         TicketMovieAssignment = tms
                //     }
                // )
                // .Join(
                //     _context.Movies,
                //     combined => combined.TicketMovieAssignment.MovieId,
                //     m => m.MovieId,
                //     (combined, m) => new
                //     {
                //         combined.Ticket, combined.TicketSeatAssignment, combined.Seat, combined.Room, combined.RoomType,
                //         combined.TicketMovieAssignment, Movie = m
                //     }
                // )
                .Join(
                    _context.Showtimes,
                    combined => combined.Room.RoomId,
                    st => st.RoomId,
                    (combined, st) => new
                    {
                        combined.Ticket, combined.TicketSeatAssignment, combined.Seat, combined.Room, combined.RoomType,
                    }
                )
                .Select(t => new TicketHistoryViewModel
                {
                    TicketId = t.Ticket.TicketId,
                    // AccountId = t.AccountId,
                    // MovieTitle = t.Movie.Title,
                    // Seat = t.Seat.Row ,
                    // RoomName = t.Room.RoomName,
                    // Hour = t.Showtime.Date.ToString("HH:mm"),
                    // Date = t.Showtime.Date.ToString("dd/MM/yyyy"),
                    // TicketPrice = t.Ticket.TicketPrice ?? 0,
                    // Status = t.Ticket.Status.ToString()
                })
                .ToListAsync();
            TicketHistories = ticketDetails;
            Console.WriteLine($"Ticket Histories Count: {TicketHistories.Count}");
            foreach (var ticket in TicketHistories)
            {
                Console.WriteLine($"Ticket Histories price: {ticket.TicketId}");
                // Console.WriteLine($"Ticket Histories id: {ticket.TicketPrice}");
                //
                // Console.WriteLine($"Ticket Histories stats: {ticket.Status}");
            }
            
            return Page();
        }

        public class TicketHistoryViewModel
        {
            public int TicketId { get; set; }
            public string MovieTitle { get; set; }
            public string Seat { get; set; }
            public string RoomName { get; set; }
            public string Hour { get; set; }
            public string Date { get; set; }
            public decimal TicketPrice { get; set; }
            public string Status { get; set; }
        }
    }
}